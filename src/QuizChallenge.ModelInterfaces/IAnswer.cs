namespace QuizChallenge.ModelInterfaces
{
    public interface IAnswer
    {
        IQuestion Question { get; }
        IChoice Choice { get; }
    }
}
