namespace Authentication.Models;

public class Note
{
    public int NoteId { get; set; }
    public string? NoteContent { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}