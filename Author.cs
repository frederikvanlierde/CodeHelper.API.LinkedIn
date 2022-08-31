using System.Text.Json.Serialization;

namespace CodeHelper.API.LinkedIn
{
    public class Author
    {
        #region Properties
        [JsonPropertyName("id")] public string Id { get; set; } = "";
        #endregion

        #region Constructors
        public Author() { }
        #endregion
    }
}
