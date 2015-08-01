// ReSharper disable ConvertToAutoProperty
// ReSharper disable ConvertPropertyToExpressionBody
namespace QuizChallenge.Model
{
    using System.Linq;
    using ModelInterfaces;

    public class QuizMaster
    {
        private readonly IQuiz _quiz;
        private readonly IGameCommandListener _gameCommandListener;

        internal QuizMaster(IQuiz quiz, IGameCommandListener listener)
        {
            _quiz = quiz;
            _gameCommandListener = listener;
        }

        public IQuiz Quiz { get { return _quiz; } }

        public void Play()
        {
            Quiz.Questions.ToList().ForEach(q =>
            {
                _gameCommandListener.ReadQuestion(q);

                var j = 0;
                q.Choices.ToList().ForEach(c =>
                {
                    System.Console.WriteLine("{0}. {1}", (char)('a'+j++), c.ChoiceText);
                });

                System.Console.Write("\nAnswer: ");

                System.Console.ReadLine();
            });
        }
    }
}