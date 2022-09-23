using System.Text.Json.Serialization;
namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class ServiceRelationship
    {
        #region Properties
        [JsonPropertyName("relationshipType")] public string RelationshipType { get; set; } = "OWNER";
        [JsonPropertyName("identifier")]        public string Identifier { get; set; } = "urn:li:userGeneratedContent";
        #endregion

        #region Constructors
        public ServiceRelationship() { }
        #endregion
    }
}
