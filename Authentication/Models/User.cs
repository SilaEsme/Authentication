namespace Authentication.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Note>? Notes { get; set; }
    public bool IsDeleted { get; set; }
}