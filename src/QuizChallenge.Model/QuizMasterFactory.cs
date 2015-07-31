namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class QuizMasterFactory
    {
        public static QuizMaster Create(IQuiz chosenQuiz)
        {
            return new QuizMaster(chosenQuiz);
        }
    }
}
