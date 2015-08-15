namespace QuizChallenge.Model
{
    using System;
    using ModelInterfaces;

    public class GameFactory
    {
        public static Game Create(IQuiz quiz)
        {
            if(quiz == null)
                throw new InvalidOperationException("Quiz cannot be null");

            return new Game(quiz);
        }
    }
}
