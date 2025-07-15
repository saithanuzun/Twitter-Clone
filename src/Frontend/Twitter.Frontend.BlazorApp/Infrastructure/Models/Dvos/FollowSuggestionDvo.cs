using System.Text.Json.Serialization;

namespace Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;

public class FollowSuggestionDvo
{
    [JsonPropertyName("userIds")]
    public List<Guid> UserIds { get; set; }

}