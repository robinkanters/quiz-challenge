namespace QuizChallenge.Model
{
    using System;
    using System.Collections.Generic;
    using ModelInterfaces;

    public class Game : IGame
    {
        internal Game(IQuiz quiz)
        {
            Quiz = quiz;
            Score = 0;
        }

        public IQuiz Quiz { get; }
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
