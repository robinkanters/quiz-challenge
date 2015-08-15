namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class GameFactory
    {
        public static Game Create(IQuiz quiz)
        {
            return new Game(quiz);
        }
    }
}
