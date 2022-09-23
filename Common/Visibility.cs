using System.Text.Json.Serialization;

namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class Visibility
    {
        #region Properties
        [JsonPropertyName("com.linkedin.ugc.MemberNetworkVisibility")]  public string VisibiltyTpe { get; set; } = CodeHelper.API.LinkedIn.VisibilityTypes.Public;
        #endregion
    }
}
