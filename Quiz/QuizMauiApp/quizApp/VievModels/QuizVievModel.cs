using quizApp.VievModels;
using QuizClassLibrary;
using System.Collections.ObjectModel;

namespace Quiz.VievModels
{
    internal class QuizVievModel : BindableObject
    {
        private ObservableCollection<Question> questions;
        public ObservableCollection<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        private string questionLabel;
        public string QuestionLabel
        {
            get { return questionLabel; }
            set { questionLabel = value; OnPropertyChanged(); }
        }

        private string answer1Label;
        public string Answer1Label
        {
            get { return answer1Label; }
            set { answer1Label = value; OnPropertyChanged(); }
        }

        private string answer2Label;
        public string Answer2Label
        {
            get { return answer2Label; }
            set { answer2Label = value; OnPropertyChanged(); }
        }

        private string answer3Label;
        public string Answer3Label
        {
            get { return answer3Label; }
            set { answer3Label = value; OnPropertyChanged(); }
        }

        private string answer4Label;
        public string Answer4Label
        {
            get { return answer4Label; }
            set { answer4Label = value; OnPropertyChanged(); }
        }

        private Command nextQuestionCommand;
        public Command NextQusetionCommand
        {
            get { return nextQuestionCommand; }
            set { nextQuestionCommand = value; }
        }

        private Command previousQuestionCommand;
        public Command PreviousQuestionCommand
        {
            get { return previousQuestionCommand; }
            set { previousQuestionCommand = value; }
        }

        private Command selectAnswerCommand;
        public Command SelectAnswerCommand
        {
            get { return selectAnswerCommand; }
            set { selectAnswerCommand = value; }
        }

        private Command resetQuizCommand;
        public Command ResetQuizCommand
        {
            get { return resetQuizCommand; }
            set { resetQuizCommand = value; }
        }

        private bool answer1RadioButton;
        public bool Answer1RadioButton
        {
            get { return answer1RadioButton; }
            set { answer1RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer2RadioButton;
        public bool Answer2RadioButton
        {
            get { return answer2RadioButton; }
            set { answer2RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer3RadioButton;
        public bool Answer3RadioButton
        {
            get { return answer3RadioButton; }
            set { answer3RadioButton = value; OnPropertyChanged(); }
        }

        private bool answer4RadioButton;
        public bool Answer4RadioButton
        {
            get { return answer4RadioButton; }
            set { answer4RadioButton = value; OnPropertyChanged(); }
        }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        public int currentQuestionIndex { get; set; }

        public QuizVievModel()
        {
            currentQuestionIndex = 0;
            QuestionsData questionsData = new QuestionsData();
            Questions = questionsData.GetAllQuestions();
            bool[] radioButtons = new bool[] { Answer1RadioButton, Answer2RadioButton, Answer3RadioButton, Answer4RadioButton };

            void DisplayQuestionAndAnswers()
            {
                QuestionLabel = Questions[currentQuestionIndex].QuestionContent;

                Answer1Label = Questions[currentQuestionIndex].Answers[0].AnswerContent;
                Answer2Label = Questions[currentQuestionIndex].Answers[1].AnswerContent;
                Answer3Label = Questions[currentQuestionIndex].Answers[2].AnswerContent;
                Answer4Label = Questions[currentQuestionIndex].Answers[3].AnswerContent;

                Answer1RadioButton = Questions[currentQuestionIndex].Answers[0].IsSelected;
                Answer2RadioButton = Questions[currentQuestionIndex].Answers[1].IsSelected;
                Answer3RadioButton = Questions[currentQuestionIndex].Answers[2].IsSelected;
                Answer4RadioButton = Questions[currentQuestionIndex].Answers[3].IsSelected;
            }

            void SelectAnswer()
            {
                for (int i = 0; i < 4; i++)
                    Questions[currentQuestionIndex].Answers[i].IsSelected = false;

                if(Answer1RadioButton)
                    Questions[currentQuestionIndex].Answers[0].IsSelected = true;
                else if(Answer2RadioButton)
                    Questions[currentQuestionIndex].Answers[1].IsSelected = true;
                else if(Answer3RadioButton)
                    Questions[currentQuestionIndex].Answers[2].IsSelected = true;
                else
                    Questions[currentQuestionIndex].Answers[3].IsSelected = true;
            }

            NextQusetionCommand = new Command(() =>
            {
                SelectAnswer();

                if (currentQuestionIndex == Questions.Count - 1)
                    currentQuestionIndex = 0;

                currentQuestionIndex++;
                DisplayQuestionAndAnswers();
            });

            PreviousQuestionCommand = new Command(() =>
            {
                SelectAnswer();

                if (currentQuestionIndex == 0)
                    currentQuestionIndex = Questions.Count - 1;
                currentQuestionIndex--;
                DisplayQuestionAndAnswers();
            });

            SelectAnswerCommand = new Command(() =>
            {
                SelectAnswer();

                int result = 0;
                
                foreach(var question in Questions)
                {
                    foreach(var answer in question.Answers)
                    {
                        if(answer.isCorrect == true && answer.IsSelected == true)
                        {
                            result++; 
                        }
                    }
                }

                Result = "Wynik to: " + result.ToString() + " / " + Questions.Count;
            });

            ResetQuizCommand = new Command(() =>
            {
                currentQuestionIndex = 0;

                foreach(var question in Questions)
                {
                    foreach(var answer in question.Answers)
                    {
                        answer.IsSelected = false;
                    }
                }

                Result = "";

                DisplayQuestionAndAnswers();
            });

            DisplayQuestionAndAnswers();
        }
    }
}
