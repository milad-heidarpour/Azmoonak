using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Controllers;

public class QuestionController : Controller
{
    IGroup _group;
    IQuestion _question;
    IProfile _profile;
    public QuestionController(IGroup group, IQuestion question, IProfile profile)
    {
        _group = group;
        _question = question;
        _profile = profile;
    }

    public async Task< IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _profile.GetUserName(UserMobile: User.Identity.Name);
            ViewBag.UserFName = user.FName;
            ViewBag.UserLName = user.LName;
        }
        var groups = (await _group.GetGroups()).Take(4);

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
        //اینجا باید دسته بندی گروه هارو نمایش بدم که روی هر کدو زد بره نمونه سوالات اون دسته رو نمایش بده با ویوی باحال
    }
    public async Task<IActionResult> ShowExampleGroups()//برای نمایش گروه نمونه سوالات
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _profile.GetUserName(UserMobile: User.Identity.Name);
            ViewBag.UserFName = user.FName;
            ViewBag.UserLName = user.LName;
        }
        var groups = await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
    }
    public async Task<IActionResult> GroupQuestion (int id)//id= groupid
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _profile.GetUserName(UserMobile: User.Identity.Name);
            ViewBag.UserFName = user.FName;
            ViewBag.UserLName = user.LName;
        }

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

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> GroupQuestion(List<Question> questions)
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _profile.GetUserName(UserMobile: User.Identity.Name);
            ViewBag.UserFName = user.FName;
            ViewBag.UserLName = user.LName;
        }
        return View();
    }
}
