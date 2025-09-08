
using Microsoft.EntityFrameworkCore;

public class ConversationRepository : IConversationRepository
{
    private readonly AppDbContext _db;
    public ConversationRepository(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<Conversation>> AllConversations()
    {
        var conversations = await _db.Conversations.ToListAsync();
        return conversations;
    }
}