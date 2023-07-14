using Azmoonak.Core.Interface;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Azmoonak.Areas.Admin.Controllers;

[Area("Admin")]
public class QuestionsController : Controller
{
    IGroup _group;
    IQuestion _question;
    public QuestionsController(IQuestion question,IGroup group)
    {
        _group = group;
        _question = question;
    }

    public async Task< IActionResult> Index()
    {
        var question =await _question.GetQuestions();
        return View(question);
    }
    public async Task<IActionResult> Create()
    {
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Question question)
    {
        if (ModelState.IsValid)
        {
            if (await _question.AddQuestion(question))
            {
                return RedirectToAction(nameof(Index));
            }
        }
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");

        return View(question);
    }

    public async Task<IActionResult> Delete(int id)//id => productid 
    {
        var question = await _question.GetQuestion(id);
        if (question == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(question);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Question question)
    {
        await _question.DeleteQuestion(question.Id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var question= await _question.GetQuestion(id);
        
        if (question != null)
        {
            ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
            return View(question);
            
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Question question)
    {
        if (ModelState.IsValid)
        {
            var result = await _question.EditQuestion(question);
            return RedirectToAction(nameof(Details), new { id = question.Id, editGroup = result });
        }
        return View(question);
    }

    public async Task<IActionResult> Details(int id, bool editGroup = false)
    {
        var question = await _question.GetQuestion(id);
        if (question != null)
        {
            ViewBag.RelatedQuestions=await _question.GetQuestions(id);
            ViewBag.EditResult = editGroup;
            return View(question);
        }
        //return NotFound();
        return RedirectToAction(nameof(Index));
    }


}
