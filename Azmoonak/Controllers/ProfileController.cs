using Azmoonak.Core.Interface;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Controllers;

[Authorize]
public class ProfileController : Controller
{
    IProfile _profile;
    IAccount _account;
    public ProfileController(IProfile profile, IAccount account)
    {
        _profile = profile;
        _account = account;
    }
    public async Task<IActionResult> Index()
    {
        var user = await _profile.GetUser(userMobile: User.Identity.Name);
        if (user.Role.RoleName == "admin")
        {
            return Redirect("~/admin/panel");
        }
        return View();
    }

    public async Task<IActionResult> GetCertificate() //id=userid
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var certificate = await _profile.GetCertificate(user.Id);
        return View(certificate);
    }

}
