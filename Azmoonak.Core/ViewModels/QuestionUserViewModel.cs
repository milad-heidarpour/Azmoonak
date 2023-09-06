

using Azmoonak.Database.Models;

namespace Azmoonak.Core.ViewModels;

public class QuestionUserViewModel
{
    public User User { get; set; }
    public IEnumerable<Question> Question { get; set; }
    public double Score { get; set; }
    public int CorrectAnswer { get; set; }
    public int FalseAnswer { get; set; }
    public int NoAnswer { get; set; }
}
