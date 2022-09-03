# AyrA.Licensing - An open source license key scheme

This is a licensing scheme for traditional license keys.

The project is split into components so you can only include what is needed (generator and/or validator)

A license key consists of 5 groups of 5 characters separated by a separation character.

The default alphabet is `ABCDEFGHIJKLMNOPQRSTUVWXYZ234679` which excludes some numbers to be easy to read.

See the "Customization" chapter for how and what can be changed.

## Hey, making this open source defeats the purpose!

No it doesn't. Any type of usage restriction,
be it a license key, online validation scheme, or media DRM, is getting broken if it's worth breaking it.
Companies sink a lot of money every year into new fancy protection methods only to have them broken.

So instead of doing that you might as well just use an existing system for free.
The system comes with a few safety features
that stop people from just making their own keys if they know of this repository.
If they want to break this system they still have to disassemble your application and find the custom values.

## Features

- Easy to use for developers and users alike
- Fully offline license validation
- License format that is familiar for many users
- Customizable alphabet
- Prevents usage of licenses from other applications that use the same licensing system

## License Key Information

A license key is not just a random assortment of characters with a checksum,
but it also contains additional information.

The license key encodes this information:

- Application id
- Expiration date
- Number of permitted installations
- Customizable flags
- Checksum

These features are described in more detail in the following chapters below.

Note: How you use these values is up to you
and is just how the application interprets the decoded bits in the license by default,
but nothing stops you from using one flag as an additional bit for the installation count.

### Application id

The application id is a 5 character string that has the same format as one of the license key segments.
The license key contains this id in one of the blocks.

You should randomly generate this for every application.
This stops keys from one application being used in another,
but at the same time, you can use this to allow a key to unlock multiple applications
if they're aware of other app ids.

Tip: If you have multiple products you may want to treat this value as a bitmask.
This would allow you to use the key for up to 25 different applications.

**Important: This is one of the values you want to protect.**

### Expiration date

This permits you to hand out time-limited keys.
The value permits dates up to `91869-11-29`,
which should render this future proof for the forseable time.
This format has no time component, so a single day is the smallest possible step.
To indicate a perpetual license you can set the value to zero,
or you can simply chose to not evaluate the expiration time in the license.
This would then permit you to use the value for something else.

Note: The value is in UTC. When dealing with this,
consider adding a day to account for the users time zone.

### Number of permitted installations

This is a value that can range from 0 to 1048575 inclusive.
Note that because this system doesn't comes with online validation built into it,
you have to either trust the user that he obeys the license agreement,
or build your own validation service into your application.

In any case, be prepared that users may occasionally reinstall your software or their entire operating system.
This may have an influence over whatever value from the computer you use to uniquely identify it.
Because of this, you should purge license validation entries on your server after a while.

### Customizable flags

These are 5 flags that can be enabled or disabled.
You're free to interpret them however you want.
A suggestion is to enable or disable additional features in your product.

Note: The key generator allows you to name and even disable them completely.
This is only a convenience feature of the key generator and has no impact on the validator.

### Checksum

The checksum is used to detect tampering of the license key.

If the checksum is invalid the user is either messing with the key on purpose, mistyped some of it,
or tries to use a key for a different product.

## Customization

The licensing system allows you to change some values, and requires you to supply some values.

### Application id

Required: Yes

This 5 character value is responsible for associating a license key with an application.
You can pick whatever you want.
Together with the offset license it makes it impossible for someone else
to generate the same values for his application.

### Charset

Required: No (has a default value)

The charset (or alphabet) are the characters that make up the license key.
This system requires 32 different characters.
The default charset are the letters A-Z and the digits 234679.
This avoids confusion with the letters B, I, L, and O.

Note that any unicode value is acceptable,
including lucicrous stuff like emojis, country flags, hieroglyphics, and various whitespace.
The limitation is whether the character fits a single UTF-32 codepoint or not.
This is purely defined by this implementation.
In reality, you may want to stay within the basic ASCII plane
because not every programming language supports UTF-32 to the same degree

### Separation character

Required: No (has a default value)

This separates the license segments.
It's usually the dash and should not be changed unless you have good reason to change it.
The built-in demo application can therefore not change it.

The character is not permitted to be part of the alphabet.

### Offset license

Required: Yes

The offset license is a value that looks like a valid license key,
but isn't one. It will simply offset the real license value to a new value.
This ensures that license keys always look random, even if they have most bits unset for example.
It also stops applications from recognizing keys from different companies.

If you need an example of why this is inmportant,
chose `AAAAA` as application id and `99999-99999-99999-99999-99999` as offset license.
You will then notice that keys have a lot of repetition.
Setting expiration to never, installation count to zero,
and unchecking all flags will make all fields perfectly repeat.

**Important: This is one of the values you want to protect.**

## Secret fields

To keep your licensing system private you want to at least keep the offset license and the application id a secret.
Additionally, you may decide to use a custom alphabet which you want to keep a secret too.

## Security

Like every other licensing system in existence,
this will not stop a person that's dedicated enough from breaking.
The difference between other systems is that this one is free to use.
This means less expense for you, and more funds to implement features for your users.

## General information format

Example key: `11111-22222-33333-44444-55555`

- Segment 11111 contains a randomly chosen set of characters.
- Segment 22222 contains the expiration date
- Segment 33333 is the application id
- Segment 44444 is the installation count and flags
- Segment 55555 is the checksum

## Key count

For any given combination of settings, 33'554'432 possible keys can exist.

## Usage

Here's short code snippets that shows usage.
Names are fully quailified here, but I recomment you make use of the `using` statement to shorten them.

Also feel free to browse the code. All functions of the libraries are commented,
including those not publicly exposed.

### Generating keys

1. Set the alphabet if you want a custom one
2. Set application id and offset license
3. Call `Generator.Keygen(...)` for every key you need

```C#
//Do these steps once
AyrA.Licensing.Base.Global.SetAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ234679"); //Optional
AyrA.Licensing.Base.Global.SetAppId("FRTBN"); //Please change this value
AyrA.Licensing.Base.Global.SetOffsetLicense("SZHZV-BFRJT-2WJGW-S7VDF-SGLBY"); //Please change this value

//Alternatively, use AyrA.Licensing.Generator.GenerateAppId()
//and AyrA.Licensing.Generator.GenerateOffsetLicense()
//But don't forget to store those values for later

//Do this for every key you need
string Key = AyrA.Licensing.Generator.Keygen(
	ExpirationDate, //System.DateTime
	NumberOfInstallations, //System.Int32
	LicenseFlags //AyrA.Licensing.Base.LicenseProperties
	);
```

### Key validation

To validate a key you must set the same global key values from the key generator,
then you can read the key into an info object that contains all information from the key.

Be sure to use a try and catch block like shown below
because the validator will throw on gross key format violations.

```C#
//Do these steps once. Values must match those from the key generator
AyrA.Licensing.Base.Global.SetAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ234679"); //Optional
AyrA.Licensing.Base.Global.SetAppId("FRTBN"); //Please change this value
AyrA.Licensing.Base.Global.SetOffsetLicense("SZHZV-BFRJT-2WJGW-S7VDF-SGLBY"); //Please change this value

AyrA.Licensing.Base.LicenseInfo LI;
try
{
	LI = AyrA.Licensing.Verification.Verify.ParseLicense("LICENSE_KEY_GOES_HERE");
}
catch (Exception ex)
{
	//Show ex.message to the user, or show generic "invalid license" error
	return;
}

//Work with LI here. Simplest case is "if(LI.IsValid()) {...} else {...}"
//Possible properties:
//- ChecksumPass: (bool) Whether checksum passed or not
//- LicenseCount: (int) Number of permitted installations
//- Props: ([Flags] LicenseProperties) Selected flags
//- AppId: (string) Application id
//- Expiration: (DateTime) Expiration. Is AyrA.Licensing.Base.Global.Forever for perpetual licenses.
//Possible methods:
// - IsExpired(): (bool) Whether the license is expired (treats IsPerpetual() correctly)
// - IsPerpetual(): (bool) Whether the license will never expire or not
// - IsValid(): (bool) Checks expiration, appId, and LicenseCount>=0

```

## Example applications

This repository comes with two example applications that generate and consume keys respectively.

### Key generator

While just being an example, it's still capable of generating keys with all features and for all applications,
provided you know the 3 values required (application id, alphabet, offset license).
Settings can be saved and loaded. For small application runs, this will be suitable to make keys.

If you need more keys it's trivial to take the code and put it into a console application,
or program a mass key generator button into the application.

The generator also has a key importer. This allows you to set installation count, expiration, and flags
according to an existing key, this can help you when you want to extend a time limited key.
You must set the 3 base values at the top correctly for this to work.

### Key validator (Demo)

This is a demo application that displays a random application id and offset license.

Copying a valid key from the key generator into this application will display the key details.

## Other implementations

You can find these in the "Other" directory in their respective language subdirectories.

| Language   | File name    | Generator | Validator |
|------------|--------------|-----------|-----------|
| JavaScript | Validator.js | No        | Yes       |
| C          | Validator.c  | No        | Yes       |
