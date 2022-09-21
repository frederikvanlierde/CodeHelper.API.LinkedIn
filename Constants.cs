namespace CodeHelper.API.LinkedIn
{
    public struct Constants
    {
        public const string APIURL_POST = "https://api.linkedin.com/v2/ugcPosts";
        public const string APIURL_ME = "https://api.linkedin.com/v2/me?projection=(id)";
        public const string APIURL_UPLOADREQUEST = "https://api.linkedin.com/v2/assets?action=registerUpload";
        public const string APIURL_ORGANIZATIONACLS = "https://api.linkedin.com/v2/organizationalEntityAcls?q=roleAssignee&role=ADMINISTRATOR&projection=(elements*(organizationalTarget~(localizedName)))";

    }

}