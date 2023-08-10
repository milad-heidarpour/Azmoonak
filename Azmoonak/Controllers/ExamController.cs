using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;
using Azmoonak.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azmoonak.Controllers;

public class ExamController : Controller
{
    IGroup _group;
    IQuestion _question;
    public ExamController(IGroup group, IQuestion question)
    {
        _group = group;
        _question = question;
    }
    public async Task< IActionResult> ShowExamGroups()
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
    public async Task<IActionResult> StartExam(List<Question> questions)
    {
        return View();
    }
}
