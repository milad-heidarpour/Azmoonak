using Azmoonak.Core.Interface;
using Azmoonak.Database.Context;
using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.ConsoleColor;

namespace Azmoonak.Core.Services;

public class QuestionService : IQuestion
{
    private readonly DatabaseContext _context;
    public QuestionService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddQuestion(Question question)
    {
        try
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            WriteLine(error.Message,
                BackgroundColor = Red,
                ForegroundColor = Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteQuestion(int QuestionId)
    {
        try
        {
            var question = _context.Questions.Find(QuestionId);
            if (question != null)
            {
                //remove product record from product database
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            //product ==null
            return await Task.FromResult(false);

        }
        catch (Exception error)
        {
            WriteLine(error.Message,
                   BackgroundColor = Red,
                   ForegroundColor = Yellow);
            return await Task.FromResult(false);
        }
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<bool> EditQuestion(Question question)
    {
        try
        {
            _context.Update(question);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,
                Console.BackgroundColor = ConsoleColor.Red,
                Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<List<Question>> GetGroupQuestions(int groupId)
    {
        var questions = _context.Questions.Include(q => q.Group).Where(q => q.GroupId == groupId).ToList();
        return questions;
    }

    public async Task<Question> GetQuestion(int QuestionId)
    {
        var question = await _context.Questions.Include(q => q.Group).FirstOrDefaultAsync(q => q.Id == QuestionId);
        return await Task.FromResult(question);
    }

    public async Task<List<Question>> GetQuestions()
    {
        var questions = _context.Questions.Include(q=>q.Group).ToList();
        return await Task.FromResult(questions);
    }

    public async Task<List<Question>> GetQuestions(int questionId)
    {
        var question = await _context.Questions.FindAsync(questionId);
        if (question == null) return null;

        var questions = _context.Questions.Include(q => q.Group).Where(q => q.Id != question.Id && q.GroupId == question.GroupId).ToList();
        return await Task.FromResult(questions);
    }

}
