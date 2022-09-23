using System.Text.Json.Serialization;

namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class ShareCommentary
    {
        #region Properties
        [JsonPropertyName("text")] public string Text { get; set; } = null;
        #endregion
    }
}
