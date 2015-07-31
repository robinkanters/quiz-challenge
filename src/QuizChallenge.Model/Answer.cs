namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class Answer : IAnswer
    {
        internal Answer(IQuestion question, IChoice choice)
        {
            this.Question = question;
            this.Choice = choice;
        }

        public IQuestion Question { get; }

        public IChoice Choice { get; }
    }
}
