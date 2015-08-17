namespace QuizChallenge.Model.Test
{
    using System;
    using NUnit.Framework;

    public class GameFactoryTest
    {
        [Test]
        public void CreateGame_WithValidArguments_SuccessfullyCreatesNewGame()
        {
            var quiz = new Quiz("testquiz", new Question("question", new Choice("choice", 10)));
            var game = GameFactory.Create(quiz);

            Assert.That(game, Is.Not.Null);
            Assert.That(game.Quiz, Is.EqualTo(quiz));
        }

        [Test]
        public void CreateGame_AfterCreation_StillHasTheQuizName()
        {
            const string quizName = "testquiz";

            var quiz = new Quiz(quizName, new Question("question", new Choice("choice", 10)));
            var game = GameFactory.Create(quiz);

            Assert.That(game.Quiz.Name, Is.EqualTo(quizName));
        }

        [Test]
        public void CreateGame_AfterCreation_StillHasTheQuiz()
        {
            var quiz = new Quiz("quizname", new Question("", new Choice("", 0)));
            var game = GameFactory.Create(quiz);

            Assert.That(game.Quiz, Is.EqualTo(quiz));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateGame_WithNullQuiz_ThrowsException()
        {
            var game = GameFactory.Create(null);
            Assert.That(game, Is.Null);
        }
    }
}
