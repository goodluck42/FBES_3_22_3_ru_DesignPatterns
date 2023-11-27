namespace ChainOfResposibility;

public class TopicDb
{
    private List<Topic> _topics;

    public TopicDb()
    {
        _topics = new List<Topic>();
    }
    
    public Topic? GetTopic(string title)
    {
        return _topics.FirstOrDefault(t => t.Title == title);
    }

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }
}