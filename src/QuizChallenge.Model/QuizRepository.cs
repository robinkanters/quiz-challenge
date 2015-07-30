namespace QuizChallenge.Model
{
    using System.Collections.Generic;
    using ModelInterfaces;

    public class QuizRepository : List<IQuiz>
    {
        public static QuizRepository Instance { get; } = new QuizRepository();
    }
}