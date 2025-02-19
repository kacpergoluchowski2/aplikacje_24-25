using quizApp.VievModels;
using System.Collections.ObjectModel;

public class QuestionsData
{
    public ObservableCollection<Question> GetAllQuestions()
    {
        return new ObservableCollection<Question>
        {
            new Question
            {
                QuestionContent = "Jaki typ danych w języku C# przechowuje liczby całkowite?",
                Answers = new ObservableCollection<Answer>
                {
                    new Answer() { AnswerContent = "string", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "int", IsSelected = false, isCorrect = true },
                    new Answer() { AnswerContent = "float", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "char", IsSelected = false, isCorrect = false }
                }
            },
            new Question
            {
                QuestionContent = "Który z poniższych operatorów w języku Python służy do porównania dwóch wartości?",
                Answers = new ObservableCollection<Answer>
                {
                    new Answer() { AnswerContent = "==", IsSelected = false, isCorrect = true },
                    new Answer() { AnswerContent = "=", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "!==", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "=>", IsSelected = false, isCorrect = false }
                }
            },
            new Question
            {
                QuestionContent = "Co oznacza pojęcie \"polimorfizm\" w programowaniu obiektowym?",
                Answers = new ObservableCollection<Answer>
                {
                    new Answer() { AnswerContent = "Możliwość tworzenia nowych klas w ramach istniejących klas", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "Możliwość definiowania wielu metod o tej samej nazwie w jednej klasie", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "Możliwość przypisania różnych implementacji tej samej metody w różnych klasach", IsSelected = false, isCorrect = true },
                    new Answer() { AnswerContent = "Możliwość tworzenia zmiennych o zmieniającym się typie w czasie działania programu", IsSelected = false, isCorrect = false }
                }
            },
            new Question
            {
                QuestionContent = "Jakie słowo kluczowe w języku C++ służy do deklaracji zmiennej, która nie może zostać zmieniona po jej inicjalizacji?",
                Answers = new ObservableCollection<Answer>
                {
                    new Answer() { AnswerContent = "static", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "const", IsSelected = false, isCorrect = true },
                    new Answer() { AnswerContent = "final", IsSelected = false, isCorrect = false },
                    new Answer() { AnswerContent = "immutable", IsSelected = false, isCorrect = false }
                }
            }
        };
    }
}
