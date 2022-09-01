using System.Text.Json.Serialization;
namespace CodeHelper.API.LinkedIn.Common
{
    public class UploadMechanism
    {
        #region Properties
        [JsonPropertyName("com.linkedin.digitalmedia.uploading.MediaUploadHttpRequest")]    public DigitalmediaUploadingMediaUploadHttpRequest UploadHttpRequest { get; set; }
        #endregion

        #region Constructors
        public UploadMechanism() { }
        #endregion
    }
}
