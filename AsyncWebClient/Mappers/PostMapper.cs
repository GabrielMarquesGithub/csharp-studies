namespace AsyncWebClient;

public class PostMapper
{
    public static Post MapFromDTO(PostDTO? postDTO)
    {
        if (postDTO == null) throw new Exception("Invalid post DTO format");
        Post post = new(postDTO.Id, postDTO.Title, postDTO.Body);
        if (!Post.IsPost(post)) throw new Exception("Invalid post entity");
        return post;
    }
}
