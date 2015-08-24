namespace QuizChallenge.Model.Test
{
    using System;
    using ModelInterfaces;
    using Moq;
    using NUnit.Framework;
    
    public class GameTest
    {
        private IGame _game;

        [SetUp]
        public void SetUp()
        {
            var quiz = new Mock<IQuiz>();

            _game = new Game(quiz.Object);
            _game.AwardPoints(10);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AwardPoints_WithNegativeAmountOfPoints_ThrowsExceptionAndScoreStaysTheSame(int inputPoints)
        {
            var beforePoints = _game.Score;

            _game.AwardPoints(inputPoints);

            Assert.That(_game.Score, Is.EqualTo(beforePoints), "Score has changed!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void AwardPoints_WithPositiveAmountOfPoints_AddsPointsToScore(int inputPoints)
        {
            var beforePoints = _game.Score;

            _game.AwardPoints(inputPoints);

            Assert.That(_game.Score, Is.EqualTo(beforePoints + inputPoints));
        }
    }
}
