using System.Text.Json.Serialization;

namespace AsyncWebClient;

public class PostDTO(int id, string title, string body)
{
    [JsonPropertyName("id")]
    public int Id { get; } = id;
    [JsonPropertyName("title")]
    public string Title { get; } = title;
    [JsonPropertyName("body")]
    public string Body { get; } = body;

}
