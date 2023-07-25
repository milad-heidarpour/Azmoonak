using Microsoft.AspNetCore.Mvc;
using Azmoonak.Core.Interface;
using Azmoonak.Core.ViewModels;

namespace Azmoonak.Controllers;

public class HomeController : Controller
{
    IGroup _group;
    IQuestion _question;
    public HomeController(IGroup group, IQuestion question)
    {
        _group = group;
        _question = question;

    }
    public async Task<IActionResult> Index()
    {
        var groups= await _group.GetGroups();

        GroupQuestionViewModel viewModel = new GroupQuestionViewModel()
        {
            Groups = groups,
        };
        return View(viewModel);
    }
}
