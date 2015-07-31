namespace QuizChallenge.Model
{
    using System.Collections.Generic;
    using ModelInterfaces;

    public class QuizRepository : List<IQuiz>
    {
        public static QuizRepository Instance { get; } = new QuizRepository();

        public IQuiz CreateQuiz(string name, params IQuestion[] questions)
        {
            var quiz = new Quiz(name, questions);
            Instance.Add(quiz);
            return quiz;
        }
    }
}