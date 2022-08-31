using System.Text.Json.Serialization;


namespace CodeHelper.API.LinkedIn.Common
{
    public class ShareMedia
    {
        #region Properties
        /// <summary>
        /// Mandatory: Must be configured to READY.
        /// </summary>
        [JsonPropertyName("status")] public string Status { get; set; } = "READY";

        /// <summary>
        /// Optional: Provide a short description for your image or article.
        /// </summary>
        [JsonPropertyName("description")] public ShareCommentary Description { get; set; } = null;

        /// <summary>
        /// Optional ID of the uploaded image asset. If you are uploading an article, this field is not required.
        /// </summary>
        [JsonPropertyName("media")] public string Media { get; set; } = null;

        /// <summary>
        /// Optional: Provide the URL of the article you would like to share here.        
        /// </summary>
        [JsonPropertyName("originalUrl")] public string OriginalUrl { get; set; } = "";

        /// <summary>
        /// Optional: Customize the title of your image or article.
        /// </summary>
        [JsonPropertyName("title")] public ShareCommentary Title { get; set; } = null;
        #endregion

        #region Constructors
        public ShareMedia() { }
        #endregion
    }
}
