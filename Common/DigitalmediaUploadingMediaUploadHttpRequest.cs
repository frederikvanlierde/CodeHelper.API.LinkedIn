using System.Text.Json.Serialization;
namespace CodeHelper.API.LinkedIn.Common
{
    public class DigitalmediaUploadingMediaUploadHttpRequest
    {
        #region Properties
        [JsonPropertyName("headers")]   public Headers Headers { get; set; }
        [JsonPropertyName("uploadUrl")] public string UploadUrl { get; set; }
        #endregion

        #region Constructors
        public DigitalmediaUploadingMediaUploadHttpRequest() { }
        #endregion
    }
}
