﻿# CodeHelper.API.LinkedIn
CodeHelper.API.LinkedIn is a lightweight and simple .NET Wrapper to let you share posts, url and articles on LinkedIn
Including ShareTextMessage and ShareUrl
		
## Info + Question?
* [Twitter](https://twitter.com/@frederik_vl/)
* [LinkedIN](https://www.linkedin.com/company/codehelper-dotnet/)
* [LinkedIn API](https://docs.microsoft.com/en-us/linkedin/consumer/integrations/self-serve/share-on-linkedin?context=linkedin%2Fconsumer%2Fcontext)
* [NuGet](https://www.nuget.org/packages/CodeHelper.API.LinkedIN)
* [Wiki + Code Examples](https://github.com/frederikvanlierde/CodeHelper.API.LinkedIn/wiki)

## Support
You can support the work if you want:
* [Buy Me A Coffee](https://www.buymeacoffee.com/codehelper.net)
* [Revolut](https://revolut.me/frederwa9)


## Version
* 1.0.4 : ShareImage
* 1.0.2 : GetAuthorID
* 1.0.0 : ShareTextMessage, ShareUrl


## Methods
* LinkedInHelper.GetAuthorID() : Returns the profile id for the current member, using the accesstoken
* LinkedInHelper.ShareTextMessage(string textMessage, string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public) : Share a simple text message on LinkedIn
* LinkedInHelper.ShareUrl(string textMessage, string eUrl, string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public,  string articleTitle=null, string articleDescription=null) : Share an Article or an URL 
* LinkedInHelper.ShareImage(string textMessage, byte[] imageData,  string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public, string imageTitel= null, string imageDescription=null) : Share an Image 


## Use of Code	
 ```csharp
using CodeHelper.API.LinkedIn;

LinkedInHelper _helper = new() {AuthorID= "{authorid}", AccessToken = "{accesstoken}" };
await _helper.ShareTextMessage("A first test message shared on LinkedIn");
await _helper.ShareUrl("Check out my updated website", "https://frederik.today/", VisibilityTypes.Public, "Frederik Today", "My Upated Webiste") ;

byte[] _image = File.ReadAllBytes(@"{PATHTOIMAGE}");
await _helper.ShareImage("Test for post", _image, VisibilityTypes.Public, "My Image Title", "MyImage Description");
```


## Authentication
LinkedIn API uses OAuth2.0 and you need to get your **Access Token** which you can find via  **My Apps page** <https://www.linkedin.com/developers/apps>


## Usage
* Free Plan, OAUTH is mandatory <https://docs.microsoft.com/en-us/linkedin/consumer/integrations/self-serve/share-on-linkedin?context=linkedin%2Fconsumer%2Fcontextd>
