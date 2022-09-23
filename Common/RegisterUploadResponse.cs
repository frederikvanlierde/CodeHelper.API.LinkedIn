using System.Text.Json.Serialization;
namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class RegisterUploadResponse
    {
        #region Properties
        [JsonPropertyName("value")] public RegisterUploadResponseValue Value { get; set; }
        #endregion

        #region Constructors
        public RegisterUploadResponse() { }
        #endregion
    }
}
