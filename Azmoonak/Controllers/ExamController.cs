using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Controllers;

public class ExamController : Controller
{
    IGroup _group;
    IQuestion _question;
    IProfile _profile;
    public ExamController(IGroup group, IQuestion question, IProfile profile)
    {
        _group = group;
        _question = question;
        _profile = profile;
    }
    public async Task<IActionResult> ShowExamGroups()
    {
        var groups = await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
    }

    //its about how to start test 
    public async Task<IActionResult> StartExam(int id)//id = groupid
    {
        var questions = await _question.GetGroupQuestions(id);
        var groups = await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Questions = questions,
            Groups = groups,
        };
        return View(viewModel);
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EndExam(List<Question> userAn)
    {
        ViewBag.OnlineUser = await _profile.GetUser(User.Identity.Name);

        double score = 0;

        foreach (var item in userAn)
        {
            if (item.UserAn == item.CorrectAn)
            {
                score += 2.5;
            }
        }
        ViewBag.Score = score;
        return View(score);
    }
}
