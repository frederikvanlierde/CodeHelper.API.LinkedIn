using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
using CodeHelper.API.LinkedIn.Common;
namespace CodeHelper.API.LinkedIn
{
    public class RegisterUploadRequest
    {
        #region Properties
        [JsonPropertyName("registerUploadRequest")] public UploadRequest UploadRequest { get; set; }
        #endregion

        #region Constructors
        public RegisterUploadRequest(string owner) {
            this.UploadRequest = new() { Owner = owner };
            this.UploadRequest.ServiceRelationships.Add(new());
        }
        #endregion

        #region Public Methods
        public HttpContent GetJsonString()
        {
            return new StringContent (JsonSerializer.Serialize(this, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, }), System.Text.Encoding.UTF8, "application/json");
        }
        #endregion
    }
}
