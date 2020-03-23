using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BasicAuth.Model;
using System.Threading.Tasks;

namespace BasicAuth.Controllers
{
  public class HomeController : Controller
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public HomeController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [Authorize]
    public IActionResult Secret()
    {
      return View();
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
      var user = await _userManager.FindByNameAsync(username);

      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        if (result.Succeeded)
          return RedirectToAction("Secret");
      }

      return RedirectToAction("Login");
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(string username, string email, string password)
    {
      var user = new Model.User()
      {
        UserName = username,
        Email = email
      };

      var result = await _userManager.CreateAsync(user, password);

      if (result.Succeeded)
      {
        //result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        //if (result.Succeeded)
        //  return RedirectToAction("Secret");
        return RedirectToAction("Login");
      }

      return RedirectToAction("Register");
    }
  }
}
