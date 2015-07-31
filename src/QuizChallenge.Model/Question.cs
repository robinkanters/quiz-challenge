namespace QuizChallenge.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using ModelInterfaces;

    public class Question : IQuestion
    {
        internal Question(string question, params IChoice[] choices)
        {
            QuestionString = question;
            AddAll(choices);
        }

        public void AddAll(params IChoice[] choices)
        {
            choices.ToList().ForEach(c => Choices.Add(c));
        }

        public string QuestionString { get; }
        public IList<IChoice> Choices { get; } = new List<IChoice>();
    }
}
