namespace QuizChallenge.Console
{
    using System;
    using System.Linq;
    using Model;
    using ModelInterfaces;

    class Program
    {
        static void Main(string[] args)
        {
            var name = AskName();

            WriteLine("\nHello, {0}, these are the available quizzes:", name);

            var quizzes = QuizRepository.Instance;

            FillQuizzes(quizzes);

            if (!quizzes.Any())
            {
                WriteLine("Sorry, no quizzes available at the moment...");
                return;
            }

            ListQuizzes(quizzes);
            
            WriteLine();

            var chosenQuiz = GetQuizChoice(quizzes);

            QuizMasterFactory.Create(chosenQuiz).Play();

            Console.WriteLine("\nThanks for playing! Press enter to exit.");
            Console.ReadLine();
        }

        private static void FillQuizzes(QuizRepository quizzes)
        {
            quizzes.AddRange(new IQuiz[]
            {
                new Quiz
                (
                    "Test quiz",
                    new Question("Some question 1?", new Choice("Meh 1", 0), new Choice("Kinda 1", 5), new Choice("Yes 1!", 10)),
                    new Question("Some question 2?", new Choice("Meh 2", 0), new Choice("Kinda 2", 5), new Choice("Yes 2!", 10)),
                    new Question("Some question 3?", new Choice("Meh 3", 0), new Choice("Kinda 3", 5), new Choice("Yes 3!", 10))
                ),
                new Quiz
                (
                    "Test quiz 2",
                    new Question("Some question 1?", new Choice("Meh 1", 0), new Choice("Kinda 1", 5), new Choice("Yes 1!", 10)),
                    new Question("Some question 2?", new Choice("Meh 2", 0), new Choice("Kinda 2", 5), new Choice("Yes 2!", 10)),
                    new Question("Some question 3?", new Choice("Meh 3", 0), new Choice("Kinda 3", 5), new Choice("Yes 3!", 10))
                )
            });
        }

        private static string AskName()
        {
            string name;

            do
            {
                Write("Hello, what is your name? ");
                name = Console.ReadLine();
            } while (string.Empty.Equals(name));

            return name;
        }

        private static void ListQuizzes(QuizRepository quizRepository)
        {
            var i = 0;
            quizRepository.ForEach(q =>
            {
                WriteLine("{0} {1}", (++i).ToString().PadRight(3), q.Name);
            });
        }

        private static IQuiz GetQuizChoice(QuizRepository quizRepository)
        {
            IQuiz result = null;

            do
            {
                Write("Which quiz would you like to take? ");

                int quizNum;
                if (!int.TryParse(Console.ReadLine(), out quizNum))
                {
                    WriteLine("That is not a quiz number!!");
                    continue;
                }

                try
                {
                    result = quizRepository[--quizNum];
                }
                catch (ArgumentOutOfRangeException)
                {
                    WriteLine("Cannot find that quiz...");
                }
            } while (null == result);

            return result;
        }

        private static void WriteLine()
        {
            Console.WriteLine();
        }

        private static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        private static void WriteLine(string text, params object[] parameters)
        {
            WriteLine(string.Format(text, parameters));
        }
    
        private static void Write(string text)
        {
            Console.Write(text);
        }

        private static void Write(string text, params object[] parameters)
        {
            WriteLine(string.Format(text, parameters));
        }
    }
}
