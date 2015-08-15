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
            var game = GameFactory.Create(Quiz);

            for (var i = 0; i < Quiz.Questions.Count; i++)
            {
                var q = Quiz.Questions[i];

                _gameCommandListener.ReadQuestion(q);

                var answer = _gameCommandListener.AskAnswer(q);

                if (answer.Choice.Equals(Choice.PREVIOUS_ANSWER))
                {
                    if (i >= 2)
                        i -= 2;
                    continue;
                }

                game.Answers.Remove(q);
                game.Answers.Add(q, answer);
            }

            game.Answers.ToList().ForEach(a => game.AwardPoints(a.Value.Choice.Value));

            _gameCommandListener.ReadScore(game.Score);
        }
    }
}