

using Azmoonak.Database.Models;

namespace Azmoonak.Core.ViewModels;

public class ModalShowViewModel
{
    public Group Group { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
