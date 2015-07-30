namespace QuizChallenge.ModelInterfaces
{
    using System.Collections.Generic;

    public interface IPlayer
    {
        string Name { get; }
        IList<IAnswer> Answers { get; } 
    }
}
