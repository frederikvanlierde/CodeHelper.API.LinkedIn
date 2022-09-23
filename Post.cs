using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
using CodeHelper.API.LinkedIn.Common;

namespace CodeHelper.API.LinkedIn
{
    public sealed class Post
    {
        #region Properties
        /// <summary>
        /// Mandatory: The author of a share contains Person URN of the Member creating the share. See Sign In with LinkedIn to see how to retrieve the Person URN.
        /// </summary>
        [JsonPropertyName("author")]            public string Author { get; set; } = "";

        /// <summary>
        /// Mandatory: Defines the state of the share.For the purposes of creating a share, the lifecycleState will always be PUBLISHED.
        /// </summary>
        [JsonPropertyName("lifecycleState")]    public string LifecycleState { get; set; } = "PUBLISHED";

        /// <summary>
        /// Mandatory: Provides additional options while defining the content of the share.
        /// </summary>
        [JsonPropertyName("specificContent")]   public SpecificContent SpecificContent { get; set; } = new();

        /// <summary>
        /// Mandatory: Defines any visibility restrictions for the share. Possible values include:
        /// ● CONNECTIONS - The share will be viewable by 1st-degree connections only.
        /// ● PUBLIC - The share will be viewable by anyone on LinkedIn.
        /// </summary>
        [JsonPropertyName("visibility")]        public Visibility Visibility { get; set; } = new();
        #endregion

        #region Constructors
        public Post() { }
        #endregion

        #region Public Methods
        public HttpContent GetJsonString()
        {
            var _j = JsonSerializer.Serialize(this, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
            return new StringContent(_j, System.Text.Encoding.UTF8, "application/json");
            }
        #endregion
    }
}
