using Azmoonak.Classes;
using Azmoonak.Core.Interface;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Azmoonak.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[RoleAttribute("admin")]
public class PanelController : Controller
{
    IGroup _group;
    IQuestion _question;
    IAccount _account;

    public PanelController(IGroup group,IQuestion question,IAccount account)
    {
        _group = group;
        _question = question;
        _account = account;
    }
    public async Task<IActionResult> Index()
    {
        //اینجا باید لیست ادمین هارو بگیرم و اگر شد کسی که ادمین اصلی هست بتونه بقیه  رو تغییر بده
        return View();
    }


    public async Task<IActionResult> GetUsers()
    {
        var users = await _account.GetUsers();
        ViewBag.UserCount=users.Count;
        return View(users);
    }


    public async Task<IActionResult>EditUser(Guid id)
    {
        var user = await _account.GetUser(id);

        if (user != null)
        {
            ViewBag.RoleId = new SelectList(await _account.GetRoles(), "Id", "RoleName");
            return View(user);
        }
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(User user)
    {
        if (ModelState.IsValid)
        {
            var result = await _account.EditUser(user);
            return RedirectToAction(nameof(Details), new { id = user.Id, editUser = result });
        }
        return View(user);
    }



    public async Task<IActionResult> Details(Guid id, bool editUser = false)
    {
        var user = await _account.GetUser(id);
        if (user != null)
        {
            ViewBag.EditResult = editUser;
            return View(user);
        }
        //return NotFound();
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(Guid id)//id => userid
    {
        var user = await _account.GetUser(id);
        if (user == null)
        {
            return RedirectToAction(nameof(GetUsers));
        }
        return PartialView(user);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(User user)
    {
        await _account.DeleteUser(user.Id);
        return RedirectToAction(nameof(GetUsers));
    }
}
