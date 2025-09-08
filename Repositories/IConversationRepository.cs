public interface IConversationRepository
{
    public Task<List<Conversation>> AllConversations();
}