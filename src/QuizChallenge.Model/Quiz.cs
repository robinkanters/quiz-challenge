namespace QuizChallenge.Model
{
    using System.Collections.Generic;
    using System.Linq;
    using ModelInterfaces;

    public class Quiz : IQuiz
    {
        internal Quiz(string name, params IQuestion[] questions)
        {
            Name = name;
            AddAll(questions);
        }

        public IQuestion NewQuestion(string question, params IChoice[] choices)
        {
            IQuestion newQuestion = new Question(question, choices);
            Add(newQuestion);
            return newQuestion;
        }

        private void Add(IQuestion newQuestion)
        {
            Questions.Add(newQuestion);
        }

        public void AddAll(params IQuestion[] newQuestions)
        {
            newQuestions.ToList().ForEach(Add);
        }

        public string Name { get; }
        public IList<IQuestion> Questions { get; } = new List<IQuestion>();
    }
}
