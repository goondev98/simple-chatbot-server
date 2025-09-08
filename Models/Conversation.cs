public class Conversation
{
    public int Id { get; set; }
    public int Uid { get; set; }
    public required string Name { get; set; }
    public required int From { get; set; }
    public required int To { get; set; }
}