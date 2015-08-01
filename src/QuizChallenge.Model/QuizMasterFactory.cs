namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class QuizMasterFactory
    {
        public static QuizMaster Create(IQuiz chosenQuiz, IGameCommandListener gameCommandListener)
        {
            return new QuizMaster(chosenQuiz, gameCommandListener);
        }
    }
}
