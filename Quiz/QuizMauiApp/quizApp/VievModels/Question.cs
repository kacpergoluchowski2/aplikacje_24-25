using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizApp.VievModels
{
    public class Question : BindableObject
    {
        public string QuestionContent { get; set; }
        private ObservableCollection<Answer> answers;

        public ObservableCollection<Answer> Answers
        {
            get { return answers; }
            set { answers = value; OnPropertyChanged(); }
        }
    }
}
