using System.Diagnostics;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

public class AccountController : Controller
{
    private readonly AuthenticationContext _authenticationContext;

    public AccountController(AuthenticationContext authenticationContext)
    {
        _authenticationContext = authenticationContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _authenticationContext.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (user == null) return View("Index");
        HttpContext.Session.SetInt32("UserId", user.UserId);
        HttpContext.Session.SetString("Name", user.Name);
        return Redirect("/Home/Index");
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public async Task<IActionResult> Register(User model)
    {
        await _authenticationContext.AddAsync(model);
        await _authenticationContext.SaveChangesAsync();
        return Redirect("Index");
    }
}