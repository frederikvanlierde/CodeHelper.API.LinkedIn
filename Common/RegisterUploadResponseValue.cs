using System.Text.Json.Serialization;
namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class RegisterUploadResponseValue
    {
        #region Properties
        [JsonPropertyName("uploadMechanism")]   public UploadMechanism UploadMechanism { get; set; }
        [JsonPropertyName("mediaArtifact")]     public string MediaArtifact { get; set; }
        [JsonPropertyName("asset")]             public string Asset { get; set; }
        #endregion

        #region Constructors
        public RegisterUploadResponseValue() { }
        #endregion
    }
}
