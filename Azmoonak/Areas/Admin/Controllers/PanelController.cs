using Azmoonak.Classes;
using Azmoonak.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Azmoonak.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[RoleAttribute("admin")]
public class PanelController : Controller
{
    IGroup _group;
    IQuestion _question;

    public PanelController(IGroup group,IQuestion question)
    {
        _group = group;
        _question = question;
    }
    public async Task<IActionResult> Index(int id)
    {
        int group= (await _group.GetGroups()).Count();
        int question= (await _question.GetQuestions()).Count();
        int groupsquestion=(await _question.GetGroupQuestions(id)).Count();
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
        //var groups=await _group.GetGroups();
        //ViewBag.groupquestion = groupsquestion;
        ViewBag.Group = group;
        ViewBag.Question = question;
        return View();
    }
}
