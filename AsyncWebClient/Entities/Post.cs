namespace AsyncWebClient;

public class Post(int id, string title, string text)
{
    private readonly int _id = id;
    private readonly string _title = title;
    private readonly string _text = text;



    override public string ToString()
    {
        return $"{_id}: {_title}\n{_text}";
    }

    public static bool IsPost(Post post)
    {
        if (!int.IsPositive(post._id))
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(post._title) || string.IsNullOrWhiteSpace(post._text))
        {
            return false;
        }
        return true;
    }
}
