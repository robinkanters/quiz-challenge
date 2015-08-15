namespace QuizChallenge.Model
{
    using System.IO;
    using System.Linq;
    using ModelInterfaces;

    public class QuizMasterFactory
    {
        public static QuizMaster Create(IQuiz chosenQuiz, IGameCommandListener gameCommandListener)
        {
            if (!chosenQuiz.Questions.Any())
                throw new InvalidDataException("No questions in this quiz!");

            return new QuizMaster(chosenQuiz, gameCommandListener);
        }
    }
}
