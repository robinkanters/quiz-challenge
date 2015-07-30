namespace QuizChallenge.ModelInterfaces
{
    using System.Collections.Generic;

    public interface IQuestion
    {
        string QuestionString { get; }
        IList<IChoice> Choices { get; } 
    }
}