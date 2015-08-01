namespace QuizChallenge.ModelInterfaces
{
    using System.Collections.Generic;

    public interface IQuestion
    {
        string QuestionString { get; }
        List<IChoice> Choices { get; }
        IAnswer CreateAnswer(IChoice choice);
    }
}