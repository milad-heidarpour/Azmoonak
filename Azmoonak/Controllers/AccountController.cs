using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Azmoonak.Controllers;

public class AccountController : Controller
{
    IAccount _account;
    public AccountController(IAccount account)
    {
        _account = account;
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            if (await _account.AddUser(register))
            {
                return RedirectToAction(nameof(Login));
            }
            //ModelState.AddModelError("Mobile", "احتمالا این شماره موبایل پیش از این ثبت شده است");
            //ModelState.AddModelError("RePassword", "مقایسه رمز ها اشتباه میباشد");
            return View(register);
        }
        return View(register);
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task< IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var user = await _account.LoginUser(login);
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Mobile),
                    new Claim(ClaimTypes.Role,user.Role.RoleName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principale = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true, //remember me
                };

                await HttpContext.SignInAsync(principale, properties);

                //redirect base on user role(admin/user)
                if (user.Role.RoleName == "admin")
                {
                    return Redirect("~/admin/panel/index");
                }
                return RedirectToAction("index", "profile");
            }
        }

        return View(login);
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("index", "home");
    }
}
