using QuizClassLibrary;
using QuizClassLibrary.Models;
using System.Collections.ObjectModel;

namespace Quiz.VievModels
{
    public class QuizVievModel : BindableObject
    {
        private QuizRepository quizRepository = new QuizRepository();
        private List<Question> questions;
        public List<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        private List<Answer> answers;

        public List<Answer> Answers
        {
            get { return answers; }
            set { answers = value; }
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
        private Color resultColor;

        public Color ResultColor
        {
            get { return resultColor; }
            set { resultColor = value; OnPropertyChanged(); }
        }


        public int currentQuestionIndex { get; set; }

        public QuizVievModel()
        {
            currentQuestionIndex = 1;
            Questions = quizRepository.DownloadCurrentQuestion(5);
            bool[] radioButtons = new bool[] { Answer1RadioButton, Answer2RadioButton, Answer3RadioButton, Answer4RadioButton };

            void DisplayQuestionAndAnswers()
            {
                Questions = quizRepository.DownloadCurrentQuestion(currentQuestionIndex);
                Answers = quizRepository.DownloadCurrentAnswers(currentQuestionIndex);

                QuestionLabel = Questions[0].Question1;
                Answer1Label = Answers[0].Answer1;
                Answer2Label = Answers[1].Answer1;
                Answer3Label = Answers[2].Answer1;
                Answer4Label = Answers[3].Answer1;

                //Answer1RadioButton = Questions[currentQuestionIndex].Answers[0].IsSelected;
                //Answer2RadioButton = Questions[currentQuestionIndex].Answers[1].IsSelected;
                //Answer3RadioButton = Questions[currentQuestionIndex].Answers[2].IsSelected;
                //Answer4RadioButton = Questions[currentQuestionIndex].Answers[3].IsSelected;
            }

            void SelectAnswer()
            {
                //for (int i = 0; i < 4; i++)
                //    Questions[currentQuestionIndex].Answers[i].IsSelected = false;

                //if(Answer1RadioButton)
                //    Questions[currentQuestionIndex].Answers[0].IsSelected = true;
                //else if(Answer2RadioButton)
                //    Questions[currentQuestionIndex].Answers[1].IsSelected = true;
                //else if(Answer3RadioButton)
                //    Questions[currentQuestionIndex].Answers[2].IsSelected = true;
                //else
                //    Questions[currentQuestionIndex].Answers[3].IsSelected = true;
            }

            void CheckAnswer()
            {
                if (Answer1RadioButton && Answers[0].IsCorrect)
                {
                    Result = "To prawidłowa odpowiedź!";
                    ResultColor = Colors.Green;
                }
                else if (Answer2RadioButton && Answers[1].IsCorrect)
                {
                    Result = "To prawidłowa odpowiedź!";
                    ResultColor = Colors.Green;
                }
                else if (Answer3RadioButton && Answers[2].IsCorrect)
                {
                    Result = "To prawidłowa odpowiedź!";
                    ResultColor = Colors.Green;
                }
                else if (Answer4RadioButton && Answers[3].IsCorrect)
                {
                    Result = "To prawidłowa odpowiedź!";
                    ResultColor = Colors.Green;
                }
                else
                {
                    Result = "To nieprawidłowa odpowiedź!";
                    ResultColor = Colors.Red;

                }

            }

            NextQusetionCommand = new Command(() =>
            {
                currentQuestionIndex++;

                if (currentQuestionIndex == quizRepository.DownloadQuestionsAmount() + 1)
                    currentQuestionIndex = 1;
                Result = "";
                DisplayQuestionAndAnswers();
            });

            PreviousQuestionCommand = new Command(() =>
            {
                currentQuestionIndex--;

                if (currentQuestionIndex == 0)
                    currentQuestionIndex = quizRepository.DownloadQuestionsAmount();
                Result = "";
                DisplayQuestionAndAnswers();
            });

            SelectAnswerCommand = new Command(() =>
            {
                CheckAnswer();
            });

            ResetQuizCommand = new Command(() =>
            {
                currentQuestionIndex = 1;
                Result = "";
                DisplayQuestionAndAnswers();
            });

            DisplayQuestionAndAnswers();
        }
    }
}
