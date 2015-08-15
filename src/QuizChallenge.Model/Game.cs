namespace QuizChallenge.Model
{
    using System;
    using System.Collections.Generic;
    using ModelInterfaces;

    public class Game : IGame
    {
        private readonly IQuiz _quiz;

        internal Game(IQuiz quiz)
        {
            _quiz = quiz;
            Score = 0;
        }

        IQuiz IGame.Quiz => _quiz;

        public int Score { get; private set; }
        public Dictionary<IQuestion, IAnswer> Answers { get; } = new Dictionary<IQuestion, IAnswer>();

        public void AwardPoints(int points)
        {
            if(points < 0)
                throw new InvalidOperationException("Cannot substract points!");

            Score += points;
        }
    }
}
