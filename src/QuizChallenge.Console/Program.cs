using System.Collections.Generic;

namespace QuizChallenge.Console
{
    using System;
    using System.Linq;
    using Model;
    using ModelInterfaces;

    class Program : IGameCommandListener
    {
        internal Program() { 
            var name = AskName();

            Console.WriteLine("\nHello, {0}, these are the available quizzes:", name);

            var quizzes = QuizRepository.Instance;

            FillQuizzes(quizzes);

            if (!quizzes.Any())
            {
                Console.WriteLine("Sorry, no quizzes available at the moment...");
                return;
            }

            ListQuizzes(quizzes);
            
            Console.WriteLine();

            var chosenQuiz = GetQuizChoice(quizzes);

            QuizMasterFactory.Create(chosenQuiz, this).Play();

            Console.WriteLine("\nThanks for playing! Press enter to exit.");
            Console.ReadLine();
        }

        private static void FillQuizzes(QuizRepository quizzes)
        {
            quizzes.CreateQuiz
            (
                "Test quiz",
                QuestionFactory.Create("Some question 1?",
                    ChoiceFactory.Create("Meh 1", 0),
                    ChoiceFactory.Create("Kinda 1", 5),
                    ChoiceFactory.Create("Yes 1!", 10)),
                QuestionFactory.Create("Some question 2?",
                    ChoiceFactory.Create("Meh 2", 0),
                    ChoiceFactory.Create("Kinda 2", 5),
                    ChoiceFactory.Create("Yes 2!", 10)),
                QuestionFactory.Create("Some question 3?",
                    ChoiceFactory.Create("Meh 3", 0),
                    ChoiceFactory.Create("Kinda 3", 5),
                    ChoiceFactory.Create("Yes 3!", 10))
            );
            quizzes.CreateQuiz
            (
                "Test quiz 2",
                QuestionFactory.Create("Some question 1?",
                    ChoiceFactory.Create("Meh 1", 0),
                    ChoiceFactory.Create("Kinda 1", 5),
                    ChoiceFactory.Create("Yes 1!", 10)),
                QuestionFactory.Create("Some question 2?",
                    ChoiceFactory.Create("Meh 2", 0),
                    ChoiceFactory.Create("Kinda 2", 5),
                    ChoiceFactory.Create("Yes 2!", 10)),
                QuestionFactory.Create("Some question 3?",
                    ChoiceFactory.Create("Meh 3", 0),
                    ChoiceFactory.Create("Kinda 3", 5),
                    ChoiceFactory.Create("Yes 3!", 10))
            );
        }

        private static string AskName()
        {
            string name;

            do
            {
                Console.Write("Hello, what is your name? ");
                name = Console.ReadLine()?.Trim();
            } while (string.Empty.Equals(name));

            return name;
        }

        private static void ListQuizzes(QuizRepository quizRepository)
        {
            var i = 0;
            quizRepository.ForEach(q =>
            {
                Console.WriteLine("{0} {1}", (++i).ToString().PadRight(3), q.Name);
            });
        }

        private static IQuiz GetQuizChoice(QuizRepository quizRepository)
        {
            IQuiz result = null;

            do
            {
                Console.Write("Which quiz would you like to take? ");

                int quizNum;
                if (!int.TryParse(Console.ReadLine(), out quizNum))
                {
                    Console.WriteLine("That is not a quiz number!!");
                    continue;
                }

                try
                {
                    result = quizRepository[--quizNum];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Cannot find that quiz...");
                }
            } while (null == result);

            return result;
        }

        public void ReadQuestion(IQuestion question)
        {
            Console.Clear();
            Console.WriteLine("Question {0}:\n{1}", 0, question.QuestionString);
            Console.WriteLine();
        }

        public void ListChoices(List<IChoice> choices)
        {
            var j = 0;
            choices.ForEach(c =>
            {
                Console.WriteLine("{0}. {1}", (char)('a' + j++), c.ChoiceText);
            });
        }

        private static void Main(string[] args)
        {
            new Program();
        }
    }
}
