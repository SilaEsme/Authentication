namespace Authentication.Models;

public class Note
{
    public int NoteId { get; set; }
    public string? NoteContext { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}