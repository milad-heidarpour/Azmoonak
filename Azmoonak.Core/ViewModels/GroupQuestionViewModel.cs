
using Azmoonak.Database.Models;

namespace Azmoonak.Core.ViewModels;

public class GroupQuestionViewModel
{
    public IEnumerable<Group>? Groups { get; set; } = null;
    public IEnumerable<Question>? Questions { get; set; }=null;

}
