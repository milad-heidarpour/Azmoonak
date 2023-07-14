using Azmoonak.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azmoonak.Core.Interface;

public interface IQuestion:IDisposable
{
    Task<List<Question>> GetQuestions();
    Task<List<Question>> GetQuestions(int questionId);//related question list
    Task <List<Question>>GetGroupQuestions(int groupId);
    Task<Question> GetQuestion(int QuestionId);
    Task<bool> AddQuestion(Question question);
    Task<bool> EditQuestion(Question question);
    Task<bool> DeleteQuestion(int QuestionId);
}
