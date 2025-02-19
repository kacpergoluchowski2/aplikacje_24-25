using QuizClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizClassLibrary
{
    public class QuizRepository
    {
        private QuizDBContext dbContext;

        public QuizRepository()
        {
            dbContext = new QuizDBContext();
        }

        public List<Question> DownloadCurrentQuestion(int id)
        {
            return dbContext
                .Questions
                .Where(p => p.Id == id)
                .ToList();
        }
    }
}
