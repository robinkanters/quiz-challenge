using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizChallenge.ModelInterfaces;

namespace QuizChallenge.Model.Test
{
    [TestClass]
    public class QuizRepositoryTest
    {
        [TestMethod]
        public void QuizRepository_CreateQuiz_Succeeds()
        {
            const string quizName = "Quiz name";

            var repo = QuizRepository.Instance;
            var quiz = repo.CreateQuiz(quizName);

            Assert.AreEqual(quiz.Name, quizName);
        }

        [TestMethod]
        public void QuizRepository_CreateWithChoices_HasChoices()
        {
            const string quizName = "Quiz name";

            var question1 = QuestionFactory.Create("Some question",
                ChoiceFactory.Create("Some choice", 10),
                ChoiceFactory.Create("Some other choice", 0),
                ChoiceFactory.Create("Some third choice", 20)
            );
            var question2 = QuestionFactory.Create("Some other question",
                ChoiceFactory.Create("Some choice", 10),
                ChoiceFactory.Create("Some other choice", 0)
            );

            var repo = QuizRepository.Instance;
            var quiz = repo.CreateQuiz(quizName, question1, question2);

            Assert.AreEqual(quiz.Questions.Count, 2);
            Assert.AreEqual(quiz.Questions[0].QuestionString, "Some question");
            Assert.AreEqual(quiz.Questions[0].Choices.Count, 3);
            Assert.AreEqual(quiz.Questions[0].Choices[1].ChoiceText, "Some other choice");
            Assert.AreEqual(quiz.Questions[0].Choices[2].Value, 20);
            Assert.AreEqual(quiz.Questions[1].QuestionString, "Some other question");
            Assert.AreEqual(quiz.Questions[1].Choices.Count, 2);
            Assert.AreEqual(quiz.Questions[1].Choices[0].ChoiceText, "Some choice");
            Assert.AreEqual(quiz.Questions[1].Choices[1].Value, 0);
        }
    }
}
