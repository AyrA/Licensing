//License validation logic
//Note that licenses are generally case sensitive.
//To be case insensitive, convert everything to uppercase before passing it in
var license = {
	//Checks license format. That's the number of segments, segment length and alphabet constraints
	checkLicense: function (l, charset) {
		var p = l.split('-');
		if (p.length !== 5) {
			return false;
		}
		for (var i = 0; i < p.length; i++) {
			if (p[i].length !== 5) {
				return false;
			}
			return p[i].split("").map(v => charset.indexOf(v)).filter(v => v < 0).length === 0;
		}
		return true;
	},
	//Offsets two license values.
	//This is a XOR operation, so the argument order doesn't matters.
	calcOffset: function (a, b) {
		var c = [];
		for (var i = 0; i < a.length && i < b.length; i++) {
			c[i] = a[i] ^ b[i];
		}
		return c;
	},
	//Convert a number array into a string from the charset
	//This is the inverse of getIndex
	numsToStr: function (v, charset) {
		return v.map(c => charset[c]).join("");
	},
	//Converts a string value into a number array
	//This is the inverse of numsToStr
	getIndex: function (v, charset) {
		return v.split("").map(c => charset.indexOf(c));
	},
	//Combines the numbers of a single license key segment into a single integer
	//Note: This will overflow if the segment is too long
	combineNums: function (v) {
		var ret = 0;
		for (var i = 0; i < v.length; i++) {
			ret = (ret << 5) | v[i];
		}
		return ret;
	},
	//Parse a license and decode the information contained within
	//licenseKey: License key to parse
	//appId     : Application Id
	//offset    : Offset license key
	//charset   : License charset
	//returns
	parseLicense: function (licenseKey, appId, offset, charset) {
		//Ensure argument count is OK
		if (arguments.length !== license.parseLicense.length) {
			throw new Error("Invalid argument count");
		}
		//Check argument type
		if (Array.from(arguments).filter(v => typeof(v) !== typeof("")).length > 0) {
			throw new Error("Invalid argument type");
		}
		//Check license conformity
		if (!license.checkLicense(offset, charset)) {
			throw new Error("Invalid offset license format");
		}
		if (!license.checkLicense(licenseKey, charset)) {
			throw new Error("Invalid license key format");
		}
		if (appId.length !== 5) {
			throw new Error("Invalid app ID format");
		}

		//Get indexes
		var oChunks = offset.split('-').map(v => license.getIndex(v, charset));
		var lChunks = licenseKey.split('-').map(v => license.getIndex(v, charset));
		var idOffset = appId.split('-').map(v => license.getIndex(v, charset));
		if (oChunks.concat(lChunks).concat(idOffset).filter(v => v < 0).length > 0) {
			throw new Error("Character not in alphabet");
		}

		//Undo offset license and random string offset
		for (var i = 0; i < oChunks.length && i < lChunks.length; i++) {
			lChunks[i] = license.calcOffset(oChunks[i], lChunks[i]);
			//Skip first segment
			if (i > 0) {
				lChunks[i] = license.calcOffset(lChunks[i], lChunks[0]);
			}
		}
		var checksum = license.numsToStr(license.calcOffset(lChunks[2], license.calcOffset(lChunks[1], lChunks[3])), charset);
		if (checksum !== license.numsToStr(lChunks[4], charset)) {
			throw new Error("Checksum failed");
		}
		if (appId !== license.numsToStr(lChunks[2], charset)) {
			throw new Error("AppId check failed");
		}

		//Number of days since 01-01-01 (January 1, Year 1)
		var expires = license.combineNums(lChunks[1]);
		if (expires < 1) {
			//Largest possible date
			//Sat, Sep 13 275760 00:00:00 UTC
			//An alternative and "technically correct" way would be to set "expires" to false,
			//but it would change the data type and may stop naive check functions from working
			expires = new Date(8640000000000000);
		} else {
			//Date construction in JS is ugly.
			//Years 0-99 are treated as 1900-1999.
			//The simplest way to get to the actual year 1 is to start with year -1 and add 24 months to it.
			//Note: The JS date object (and many others) implement a year zero,
			//which in the anno domini calendar does't exists.
			//On the plus side, it correctly overflows values,
			//meaning we can just add our massive number of days and land in the correct location.
			//The expiration value is in UTC and actually the last day the license is still valid,
			//because of that, one extra day is added.
			expires = new Date(Date.UTC(-1, 24, expires + 1, 0, 0, 0));
		}
		var installations = Math.max(1, license.combineNums(lChunks[3]) & 0xFFFFF);
		var flags = license.combineNums(lChunks[3]) >> 20;

		var ret = {
			//When the license expires
			expires: expires,
			//Whether the license has already expired
			expired: expires < Date.now(),
			//Number of permitted installations
			installations: installations,
			//Flags. Flag 1 is the first, Flag 5 is the last.
			flags: [flags & 1, flags >> 1 & 1, flags >> 2 & 1, flags >> 3 & 1, flags >> 4 & 1].map(v => v === 1)
		};
		return ret;
	}
};
Object.freeze(license);

//Run some tests
(function () {
	var tests = [
		//2023-09-03, 1 installs, flag 3
		"DQJXG-GRRO2-G6SHC-J2IVW-CVI6A",
		//Forever, 1 installs, flag 3
		"UJ3UN-R7SD4-REAEJ-7D2W6-V2LQG",
		//2023-01-01, 1048575 installs, flag 1,2,3
		"ZLAIQ-4KYZZ-4G3YU-Q77V7-3R7V6"
	];

	var info = {
		charset: "ABCDEFGHIJKLMNOPQRSTUVWXYZ234679",
		appId: "LWSCA",
		offset: "6MWW6-Y39BM-TX9EZ-TGXUM-TJUQX"
	}

	for (var i = 0; i < tests.length; i++) {
		console.log("Testing license", tests[i]);
		console.log(license.parseLicense(tests[i], info.appId, info.offset, info.charset));
	}
})();
