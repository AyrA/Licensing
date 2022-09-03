//Dumps additional information to the console
//#define LIC_VERBOSE

#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include "validator.h"

int main(){
	const char* charset="ABCDEFGHIJKLMNOPQRSTUVWXYZ234679";
	const char separator='-';
	const char* appId="LWSCA";
	const char* offsetLicense="6MWW6-Y39BM-TX9EZ-TGXUM-TJUQX";
	//Test license
	struct lic_Result result=lic_validate("DQJXG-GRRO2-G6SHC-J2IVW-CVI6A",offsetLicense,appId,charset,separator);

	//Convert to time_t structure
	time_t expires=result.expires;
	struct tm* calendar=gmtime(&expires);
	
	//Show results
	printf("License validation result:\n");
	printf("Checksum:     %s\n",result.checksumPass?"Pass":"Fail");
	printf("AppId:        %i\n",result.appId);
	printf("Installs:     %i\n",result.installs);
	printf("Flag bitmask: %i\n",result.flags);
	printf("Expires:      %04i-%02i-%02i UTC\n",calendar->tm_year+1900,calendar->tm_mon+1,calendar->tm_mday);
	return result.checksumPass?0:1;
}
