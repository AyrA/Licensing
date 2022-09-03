//Dumps additional information to the console
//#define LIC_VERBOSE

#include <stdbool.h>

//Number of segments in a license and their length.
//Adjusting these may need serious rework of the licensing system
#define LIC_SEGMENT_LENGTH 5
#define LIC_SEGMENT_COUNT 5

//The number of days that have to be added or subtracted to get a unix time stamp
//This is off by one because the license contains the time stamp of the last day that's still valid,
//But we likely want the date it's no longer valid due to the time component always being 00:00:00.
#define LIC_UNIX_OFFSET (-719162)

//Field indexes for information
#define LIC_FIELD_RANDOM 0
#define LIC_FIELD_EXPIRATION 1
#define LIC_FIELD_APPID 2
#define LIC_FIELD_FLAGS 3 //also install counter
#define LIC_FIELD_CHECKSUM 4

//Total length of a license
#define LIC_LENGTH (LIC_SEGMENT_LENGTH*LIC_SEGMENT_COUNT+LIC_SEGMENT_COUNT-1)
//Length of the alphabet
#define LIC_ALPHABET_SIZE 32

//License result
struct lic_Result {
	//Checksum pass. Other fields may contain garbage if this is false.
	bool checksumPass;
	//Expiration date (Days since 1970-01-01 UTC)
	int  expires;
	//Flags
	int  flags;
	//Number of permitted installs
	int  installs;
	//Decoded application id
	int  appId;
} lic_result;

//License functions. Detailed description can be found at every implementation
//lic_validate is likely the only one you want to use

bool lic_checkLicense(const char*,const char*,const char);
int lic_indexOf(const char*, const char);
struct lic_Result lic_validate(const char*,const char*,const char*,const char*,const char);
bool lic_validateAlphabet(const char*,const char);
int lic_segmentToNumber(const char*,const char*);

//Poor man's debugger
#ifdef LIC_VERBOSE
#define LIC_DBG(...) fprintf(stderr,"[%s:%s:%i] ",__FILE__,__FUNCTION__,__LINE__);fprintf(stderr, __VA_ARGS__ );fprintf(stderr,"\n");
#else
#define LIC_DBG(...)
#endif

//Checks general license format and conformity to the alphabet
bool lic_checkLicense(const char* licenseKey,const char* alphabet,const char separator){
	if(licenseKey==NULL || alphabet==NULL){
		LIC_DBG("NULL check failed");
		return false;
	}
	int separatorOffset=LIC_SEGMENT_LENGTH;
	for(int i=0;i<LIC_LENGTH;i++){
		if(licenseKey[i]=='\0'){
			LIC_DBG("Detected NULL in license key");
			return false;
		}
		//Skip the separator
		if(i==separatorOffset && licenseKey[i]==separator){
			separatorOffset+=LIC_SEGMENT_LENGTH+1;
			continue;
		}
		else{
			if(lic_indexOf(alphabet,licenseKey[i])<0){
				LIC_DBG("License key contains invalid character");
				LIC_DBG("pos=%i, char=%c",i,licenseKey[i]);
				return false;
			}
		}
	}
	LIC_DBG("%s passed validation",licenseKey);
	return true;
}

//Validates a license and returns its components if valid
struct lic_Result lic_validate(const char* licenseKey,const char* offsetLicense,const char* appId,const char* alphabet, const char separator){
	//Return value buffer with defaults for a failed result
	struct lic_Result result;
	result.appId=0;
	result.checksumPass=false;
	result.expires=0;
	result.flags=0;
	result.installs=0;
	
	//Validate arguments
	
	if(!lic_checkLicense(licenseKey,alphabet,separator) || !lic_checkLicense(offsetLicense,alphabet,separator)){
		LIC_DBG("License check failed");
		return result;
	}
	if(!lic_validateAlphabet(alphabet,separator)){
		LIC_DBG("Alphabet check failed");
		return result;
	}
	//Extract license key segments and convert into an integer
	int segments[LIC_SEGMENT_COUNT];
	for(int index=0;index<LIC_SEGMENT_COUNT;index++){
		int offset=index*LIC_SEGMENT_LENGTH+(index==0?0:index);
		segments[index]=
			lic_segmentToNumber(licenseKey+offset,alphabet)^
			lic_segmentToNumber(offsetLicense+offset,alphabet);
			if(index>0){
				segments[index]^=segments[0];
			}
		LIC_DBG("SEG: %9i,%2i",segments[index],offset);
	}
	//Checksum all fields together except first and last (random and checksum field)
	int checksum=0;
	for(int doChecksum=LIC_FIELD_RANDOM+1;doChecksum<LIC_FIELD_CHECKSUM;doChecksum++){
		checksum^=segments[doChecksum];
	}
	
	//Validate checksum. Must match checksum field
	LIC_DBG("CHK: %9i",checksum);
	if(checksum!=segments[LIC_FIELD_CHECKSUM]){
		LIC_DBG("Checksum failed. is=%i should=%i",checksum,segments[LIC_FIELD_CHECKSUM]);
		return result;
	}
	
	//Check if appId matches (if provided)
	if(appId!=NULL && segments[LIC_FIELD_APPID]!=lic_segmentToNumber(appId,alphabet)){
		LIC_DBG("AppId check failed. is=%i should=%i",segments[LIC_FIELD_APPID],lic_segmentToNumber(appId,alphabet));
		return result;
	}
	
	//Convert expiration to unix time
	if(segments[LIC_FIELD_EXPIRATION]!=0){
		segments[LIC_FIELD_EXPIRATION]=(segments[LIC_FIELD_EXPIRATION]-719162)*86400;
	}
	
	//Extract flags and installation count
	int flags=segments[LIC_FIELD_FLAGS]>>20;
	int installs=segments[LIC_FIELD_FLAGS]&0xFFFFF;
	LIC_DBG("Flag field: flags=%i, installs=%i",flags,installs);
	
	//Fill in values
	result.checksumPass=true;
	result.appId=segments[LIC_FIELD_APPID];
	result.expires=segments[LIC_FIELD_EXPIRATION];
	result.flags=flags;
	result.installs=installs;
	LIC_DBG("check=%i app=%i exp=%i flags=%i installs=%i",result.checksumPass,result.appId,result.expires,result.flags,result.installs);
	return result;
	
}

//Validates the alphabet
bool lic_validateAlphabet(const char* alphabet,const char separator){
	if(alphabet==NULL){
		return false;
	}
	if(lic_indexOf(alphabet,separator)>=0){
		return false;
	}
	int i=0;
	while(alphabet[i]){
		if(lic_indexOf(alphabet,alphabet[i])!=i){
			return false;
		}
		i++;
	}
	return i==LIC_ALPHABET_SIZE;
}

//Converts a license segment into a number
int lic_segmentToNumber(const char* block,const char* alphabet){
	int ret=0;
	for(int i=0;i<LIC_SEGMENT_LENGTH;i++){
		//Each letter holds 5 bits of information because the alphabet is 32 character long and pow(2,5)==32
		ret=ret<<5|lic_indexOf(alphabet,block[i]);
	}
	return ret;
}

//Finds the first occurence of a character in a null terminated string. If not found, the index is negative.
int lic_indexOf(const char* haystack, const char needle){
	if(haystack==NULL){
		return -1;
	}
	int i=0;
	while(haystack[i]!='\0'){
		if(haystack[i]==needle){
			return i;
		}
		i++;
	}
	return -1;
}
