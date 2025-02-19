using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.VievModels
{
    public class Answer : BindableObject
    {
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }

        public bool isCorrect { get; set; }

        private string answerContent;

        public string AnswerContent
        {
            get { return answerContent; }
            set { answerContent = value; OnPropertyChanged(); }
        }
    }
}
