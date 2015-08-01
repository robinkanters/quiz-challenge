using System.Collections.Generic;

namespace QuizChallenge.ModelInterfaces
{
    public interface IGameCommandListener
    {
        void ReadQuestion(IQuestion question);
        void ListChoices(List<IChoice> choices);
    }
}
