using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace CodeHelper.API.LinkedIn.Common
{    
    public class UploadRequest
    {
        #region Properties
        [JsonPropertyName("recipes")]               public List<string> Recipes { get; set; } = new() { "urn:li:digitalmediaRecipe:feedshare-image" };
        [JsonPropertyName("owner")]                 public string Owner { get; set; }
        [JsonPropertyName("serviceRelationships")]  public List<ServiceRelationship> ServiceRelationships { get; set; } = new();
        #endregion

        #region Constructors
        public UploadRequest() {}        
        #endregion
    }
}
