using Brixton.Interfaces;
using Brixton.Models;
using System.Collections.Generic;

namespace Brixton.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PRJ301_SE1705Context _context = new PRJ301_SE1705Context();

        public QuestionRepository(PRJ301_SE1705Context context)
        {
            _context = context;
        }

        public List<SecurityQuestionHe161048> getAllQues()
        {
            List<SecurityQuestionHe161048> list = _context.SecurityQuestionHe161048s.ToList();
            return list;
        }


    }
}
