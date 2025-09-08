public interface IConversationService
{
    public Task<List<Conversation>> GetConversations();
}