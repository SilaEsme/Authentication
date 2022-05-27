using Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly AuthenticationContext _authenticationContext;

    public HomeController(ILogger<HomeController> logger, AuthenticationContext authenticationContext)
    {
        _logger = logger;
        _authenticationContext = authenticationContext;
    }

    public IActionResult Index()
    {
        ViewData["Notes"] = GetAllNotes();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<Note> GetAllNotes()
    {
        return _authenticationContext.Notes.Where(n => n.UserId == HttpContext.Session.GetInt32("UserId")).ToList();
    }
    [HttpPost]
    public async Task<IActionResult> Save(Note model)
    {
        var key = (int)HttpContext.Session.GetInt32("UserId");
        model.UserId = (int)key;
        model.User = _authenticationContext.Users.SingleOrDefault(u => u.UserId == key);
        await _authenticationContext.AddAsync(model);
        await _authenticationContext.SaveChangesAsync();
        return Index();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = _authenticationContext.Entry(_authenticationContext.Notes.SingleOrDefault(n => n.NoteId == id));
        entity.State = EntityState.Deleted;
        await _authenticationContext.SaveChangesAsync();
        return Index();
    }

    public async Task<IActionResult> Update(string newContent)
    {
        return Index();
    }
}