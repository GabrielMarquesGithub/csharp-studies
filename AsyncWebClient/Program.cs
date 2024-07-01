using System.Net.Http.Headers;
using System.Text.Json;
using AsyncWebClient;

try
{
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    Post post = await ProcessPostAsync(client, 1);
    Console.WriteLine(post);
}
catch (Exception err)
{
    Console.WriteLine($"Request exception: {err.Message}");
}

static async Task<Post> ProcessPostAsync(HttpClient client, int id)
{

    const string url = "https://jsonplaceholder.typicode.com/posts";
    string json = await client.GetStringAsync($"{url}/{id}");

    PostDTO? post = JsonSerializer.Deserialize<PostDTO>(json);
    return PostMapper.MapFromDTO(post);
}

