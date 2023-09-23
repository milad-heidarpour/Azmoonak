using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
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
        return View(user);
    }

    public async Task<IActionResult> GetCertificate() //id=userid
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var certificate = await _profile.GetCertificate(user.Id);
        return View(certificate);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _profile.GetUser(id);
        if (user!=null)
        {
            EditUserDashbordViewModel viewModel = new EditUserDashbordViewModel()
            {
                Id = user.Id,
                FName = user.FName,
                RoleId = user.RoleId,
                LName = user.LName,
                Mobile = user.Mobile,
                Password = user.Password,
            };
            return View(viewModel);
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditUserDashbordViewModel user)
    {
        if (ModelState.IsValid)
        {
            var result = await _profile.EditProfile(user);
            return RedirectToAction(nameof(Details), new { id = user.Id, editUser = result });
        }
        return View(user);
    }
    public async Task<IActionResult> Details(Guid id, bool editUser = false)
    {
        var user = await _profile.GetUser(id);
        if (user != null)
        {
            ViewBag.EditResult = editUser;
            return View(user);
        }
        //return NotFound();
        return RedirectToAction(nameof(Index));
    }
}
