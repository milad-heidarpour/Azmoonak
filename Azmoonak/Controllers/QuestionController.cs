using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Controllers;

public class QuestionController : Controller
{
    IGroup _group;
    IQuestion _question;
    public QuestionController(IGroup group, IQuestion question)
    {
        _group = group;
        _question = question;
    }

    public async Task< IActionResult> Index()
    {
        var groups = await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
        //اینجا باید دسته بندی گروه هارو نمایش بدم که روی هر کدو زد بره نمونه سوالات اون دسته رو نمایش بده با ویوی باحال
    }
    public async Task<IActionResult> GroupQuestion (int id)//id= groupid
    {
        var questions = await _question.GetGroupQuestions(id);
        var groups = await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Questions = questions,
            Groups = groups,
        };
        return View(viewModel);


        //ViewBag.Question = (await _group.GetGroup(id)).GroupName.ToString();
        //if (questions != null)
        //{
        //    return View(questions);
        //}
        //return null;
    }
}
