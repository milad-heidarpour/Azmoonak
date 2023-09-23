using Microsoft.AspNetCore.Mvc;
using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;

namespace Azmoonak.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    IQuestion _question;
    IAccount _account;
    IProfile _profile;
    public HomeController(IGroup group, IQuestion question, IAccount account, IProfile profile)
    {
        _group = group;
        _question = question;
        _account = account;
        _profile = profile;
    }
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user= await _profile.GetUserName(UserMobile: User.Identity.Name);
            ViewBag.UserFName = user.FName;
            ViewBag.UserLName=user.LName;
        }
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
