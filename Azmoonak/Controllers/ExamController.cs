using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;
using CarShop.Core.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

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
        var questions = (await _question.GetGroupQuestions(id)).Take(40);
        TempData["GroupId"] = id;

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Questions = questions,
            //Groups = groups,
        };
        return View(viewModel);
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EndExam(List<Question> userAn)
    {

        var user = await _profile.GetUser(User.Identity.Name);

        double _score = 0;
        int _correctAnswer = 0;
        int _falseAnswer = 0;
        int _noAnswer = 0;


        foreach (var item in userAn)
        {
            if (item.UserAn == item.CorrectAn)
            {
                _score += 2.5;
                _correctAnswer++;
            }
            else if (item.UserAn!= item.CorrectAn && item.UserAn!=null)
            {
                _falseAnswer++;
            }
            else if (item.UserAn==null)
            {
                _noAnswer++;
            }
        }

        Certificate certificate = new Certificate()
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            FinalScore = _score,
            GroupId = Convert.ToInt32(TempData["GroupId"]),
            CorrectAnswer = _correctAnswer,
            FalseAnswer = _falseAnswer,
            NoAnswer = _noAnswer,
            OpenDateTime = await new CoreClass().GetPersianDate(),
        };
        
        var newCertificate =await _profile.AddCertificate(certificate);

        QuestionUserViewModel viewModel = new QuestionUserViewModel()
        {
            Question = userAn,
            User = user,
            Score = _score,
            CorrectAnswer = _correctAnswer,
            FalseAnswer = _falseAnswer,
            NoAnswer = _noAnswer
        };
        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var group = await _group.GetGroup(id);
        if (group != null)
        {
            return View(group);
        }
        //return NotFound();
        return RedirectToAction(nameof(ShowExamGroups));
    }

}
