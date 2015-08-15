namespace QuizChallenge.ModelInterfaces
{
    using System.Collections.Generic;

    public interface IGame
    {
        IQuiz Quiz { get; }
        int Score { get; }
        Dictionary<IQuestion, IAnswer> Answers { get; } 

        void AwardPoints(int points);
    }
}
