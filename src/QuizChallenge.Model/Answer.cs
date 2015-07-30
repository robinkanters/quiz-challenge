namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class Answer : IAnswer
    {
        public Answer(IQuestion question, IChoice choice)
        {
            Question = question;
            Choice = choice;
        }

        public IQuestion Question { get; }

        public IChoice Choice { get; }
    }
}
