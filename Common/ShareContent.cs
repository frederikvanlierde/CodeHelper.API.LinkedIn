using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CodeHelper.API.LinkedIn.Common
{
    public sealed class ShareContent
    {
        #region Properties
        /// <summary>
        /// Mandatory: Provides the primary content for the share.
        /// </summary>
        [JsonPropertyName("shareCommentary")]       public ShareCommentary ShareCommentary { get; set; } = new();
        /// <summary>
        /// Mandatory: Represents the media assets attached to the share. Possible values include:
        /// ● NONE - The share does not contain any media, and will only consist of text.
        /// ● ARTICLE - The share contains a URL.
        /// ● IMAGE - The Share contains an image.
        /// Use struct ShareMediaCategoryTypes for all types
        [JsonPropertyName("shareMediaCategory")]    public string ShareMediaCategory { get; set; } = ShareMediaCategoryTypes.None;

        /// <summary>
        /// If the shareMediaCategory is ARTICLE or IMAGE, define those media assets here.
        /// </summary>
        [JsonPropertyName("media")]              public List<ShareMedia> Media { get; set; } = null;
        #endregion
    }
}
