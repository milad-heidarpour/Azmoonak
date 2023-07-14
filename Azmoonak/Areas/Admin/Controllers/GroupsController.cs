using Azmoonak.Core.Interface;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Areas.Admin.Controllers;
[Area("Admin")]
public class GroupsController : Controller
{
    IGroup _group;
    IQuestion _question;
    public GroupsController(IGroup group, IQuestion question)
    {
        _group = group;
        _question = question;
    }
    public async Task<IActionResult> Index()
    {
        var groups = await _group.GetGroups();
        return View(groups);
    }
    public async Task<IActionResult>Details(int id, bool editGroup = false)
    {
        var group = await _group.GetGroup(id);
        ViewBag.RelatedQuestion = await _question.GetGroupQuestions(id);
        ViewBag.QuestionCount = (await _question.GetGroupQuestions(id)).Count();
        if (group != null)
        {
            ViewBag.EditResult = editGroup;
            return View(group);
        }
        //return NotFound();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id)
    {
        var group = await _group.GetGroup(id);
        if (group != null)
        {
            return View(group);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Group group)
    {
        if (ModelState.IsValid)
        {
            var result = await _group.EditGroup(group);
            return RedirectToAction(nameof(Details), new { id = group.Id, editGroup = result });
        }
        //ModelState.AddModelError("GroupDes", "خطا در ویرایش گروه");
        return View(group);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Group group)
    {
        if (ModelState.IsValid)
        {
            if (await _group.AddGroup(group))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("GroupName", "خطا در ثبت گروه جدید");
            return View(group);
        }
        return View(group);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var group = await _group.GetGroup(id);
        return PartialView(group);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteEntryGroup(int id)
    {
        await _group.DeleteGroup(id);
        return RedirectToAction(nameof(Index));
    }
}
