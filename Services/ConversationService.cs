
public class ConversationService : IConversationService
{
    private readonly IConversationRepository _repo;
    public ConversationService(IConversationRepository repo)
    {
        _repo = repo;
    }
    public Task<List<Conversation>> GetConversations()
    {
        return _repo.AllConversations();
    }
}