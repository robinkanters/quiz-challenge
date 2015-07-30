namespace QuizChallenge.Console
{
    using System.Linq;
    using ModelInterfaces;

    public class QuizMaster
    {
        public IQuiz Quiz { get; }

        public QuizMaster(IQuiz quiz)
        {
            Quiz = quiz;
        }

        public void Play()
        {
            var i = 1;
            Quiz.Questions.ToList().ForEach(q =>
            {
                System.Console.Clear();
                System.Console.WriteLine("Question {0}:\n{1}", i++, q.QuestionString);
                System.Console.WriteLine();

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