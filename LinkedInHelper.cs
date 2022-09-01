using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using CodeHelper.API.LinkedIn.Common;
namespace CodeHelper.API.LinkedIn
{
    /// <summary>
    /// Documentation: https://docs.microsoft.com/en-us/linkedin/consumer/integrations/self-serve/share-on-linkedin?context=linkedin%2Fconsumer%2Fcontext
    /// </summary>
    public class LinkedInHelper
    {
        #region Properties
        private readonly HttpClient _httpClient = new();
        private string _AuthorID = "";
        public string AccessToken { get; set; } = "";        
        public string AuthorID { get { return "urn:li:person:" + _AuthorID; } 
                                 set { _AuthorID = value.Replace("urn:li:person:",""); } }
        #endregion

        #region Constructo
        public LinkedInHelper() { }
        #endregion

        #region Public Methods
        public async Task<bool> ShareImage(string textMessage, byte[] imageData,  string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public, string imageTitel= null, string imageDescription=null)
        {
            bool isSuccess = false;
            RegisterUploadRequest _uploadRequest = new(this.AuthorID);
            RegisterUploadResponse _uploadResponse = JsonSerializer.Deserialize<RegisterUploadResponse>(await PostJson(Constants.APIURL_UPLOADREQUEST, _uploadRequest.GetJsonString())) ?? new();
            if (!string.IsNullOrEmpty(_uploadResponse.Value.UploadMechanism.UploadHttpRequest.UploadUrl))
            {
                //--Upload imge 
                var _uploadURL = _uploadResponse.Value.UploadMechanism.UploadHttpRequest.UploadUrl;
                
                SetAuthorizationHeader();
                var _task = await _httpClient.PostAsync(_uploadURL, new ByteArrayContent(imageData));
                if (_task.IsSuccessStatusCode)
                {
                    await Share(textMessage, ShareMediaCategoryTypes.Image, "", visibility, imageTitel, imageDescription, _uploadResponse.Value.Asset);
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// Share a simple Text post on LinkedIn
        /// </summary>
        /// <param name="textMessage">Mandatory: text to share</param>
        /// <param name="visibility">Mandatory, use VisibilityTypes for list (default: PUBLIC</param>
        public async Task ShareTextMessage(string textMessage, string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public)
        {
            Post _post = new() { Author = this.AuthorID };
            _post.Visibility.VisibiltyTpe = visibility;
            _post.SpecificContent.ShareContent = new Common.ShareContent() { ShareCommentary = new() {Text=textMessage } };

            await PostJson(Constants.APIURL_POST, _post.GetJsonString());
        }
        /// <summary>
        /// Create an Article or URL Share
        /// </summary>
        /// <param name="textMessage">Mandatory: Provides the primary content for the share.</param>
        /// <param name="url">Mandatory: Provide the URL of the article you would like to share here.</param>
        /// <param name="visibility">Mandatory
        /// Defines any visibility restrictions for the share. Possible values include:
        /// ● CONNECTIONS - The share will be viewable by 1st-degree connections only.
        /// ● PUBLIC - The share will be viewable by anyone on LinkedIn.
        /// </param>
        /// <param name="articleTitle">Optional: Customize the title of your image or article.</param>
        /// <param name="articleDescription">Optional: Provide a short description for your image or article.</param>
        /// <returns></returns>
        public async Task ShareUrl(string textMessage, string url, string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public,  string articleTitle=null, string articleDescription=null)
        {
            await Share(textMessage, ShareMediaCategoryTypes.Article, url, visibility, articleTitle, articleDescription, null);            
        }

        /// <summary>
        /// Gets the author iD for the current loggedin user, based on accesstoken
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAuthorID()
        {
            SetAuthorizationHeader();
            this.AuthorID = (JsonSerializer.Deserialize<Author>(await GetJson(Constants.APIURL_ME)) ?? new()).Id;
            return this.AuthorID;
        
        }
        #endregion

        #region Private Methods        
        protected async Task<string> PostJson(string apiURL, HttpContent data)
        {
            SetAuthorizationHeader();
            var _task = await _httpClient.PostAsync(apiURL, data);
            return await _task.Content.ReadAsStringAsync();
        }
        protected async Task<string> GetJson(string apiURL)
        {
            SetAuthorizationHeader();            
            var _task = await _httpClient.GetAsync(apiURL);
            return await _task.Content.ReadAsStringAsync();
        }
        private void SetAuthorizationHeader()
        {
            if (_httpClient.DefaultRequestHeaders.Contains("X-Restli-Protocol-Version"))
                _httpClient.DefaultRequestHeaders.Remove("X-Restli-Protocol-Version");
            _httpClient.DefaultRequestHeaders.Add("X-Restli-Protocol-Version", "2.0.0");

            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
        }
        private async Task Share(string textMessage, string shareMediaCategory, string url="", string visibility = CodeHelper.API.LinkedIn.VisibilityTypes.Public, string articleTitle = null, string articleDescription = null, string mediaID=null)
        {
            Post _post = new() { Author = this.AuthorID };
            _post.Visibility.VisibiltyTpe = visibility;
            _post.SpecificContent.ShareContent = new Common.ShareContent() { ShareCommentary = new() { Text = textMessage }, ShareMediaCategory = shareMediaCategory };
            _post.SpecificContent.ShareContent.Media = new();
            _post.SpecificContent.ShareContent.Media.Add(new() { Title = new() { Text = articleTitle }, Description = new() { Text = articleDescription } });
            if(!string.IsNullOrEmpty(url))
                _post.SpecificContent.ShareContent.Media[0].OriginalUrl = url;

            if (!string.IsNullOrEmpty(mediaID))_post.SpecificContent.ShareContent.Media[0].Media = "urn:li:digitalmediaAsset:" + mediaID;
                _post.SpecificContent.ShareContent.Media[0].Media = mediaID;
            await PostJson(Constants.APIURL_POST, _post.GetJsonString());
            
        }
        #endregion
    }
}
