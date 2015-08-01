// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable ConvertToAutoProperty
namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class Answer : IAnswer
    {
        private readonly IQuestion _question;
        private readonly IChoice _choice;

        internal Answer(IQuestion question, IChoice choice)
        {
            _question = question;
            _choice = choice;
        }

        public IQuestion Question { get { return _question; } }

        public IChoice Choice { get { return _choice; } }
    }
}
