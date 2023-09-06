using Microsoft.AspNetCore.Mvc;
using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;

namespace Azmoonak.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    IQuestion _question;
    IAccount _account;
    public HomeController(IGroup group, IQuestion question, IAccount account)
    {
        _group = group;
        _question = question;
        _account = account;
    }
    public async Task<IActionResult> Index()
    {
        var groups= await _group.GetGroups();
        ViewBag.UserCount= (await _account.GetUsers()).Count;
        ViewBag.QuestionCount= (await _question.GetQuestions()).Count;
        ViewBag.GroupCount=groups.Count;

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
    }
}
