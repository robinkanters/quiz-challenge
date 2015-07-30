namespace QuizChallenge.ModelInterfaces
{
    using System.Collections.Generic;

    public interface IQuiz
    {
        string Name { get; }
        IList<IQuestion> Questions { get; }
    }
}
