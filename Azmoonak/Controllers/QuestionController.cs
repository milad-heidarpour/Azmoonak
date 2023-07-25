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

    public IActionResult Index()
    {
        return View();
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
