namespace QuizChallenge.Model.Test
{
    using System.IO;
    using NUnit.Framework;

    public class ChoiceFactoryTest
    {
        [Test]
        [TestCase(-1)]
        [ExpectedException(typeof(InvalidDataException))]
        public void Create_WithChoiceValueBelowZero_ThrowsException(int testValue)
        {
            const string choiceText = "text doesn't matter for test";

            var choice = ChoiceFactory.Create(choiceText, testValue);

            Assert.That(choice, Is.Null);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Create_WithChoiceValueEqualToOrGreaterThanZero_CreatesChoiceObject(int testValue)
        {
            const string choiceText = "text doesn't matter for test";

            var choice = ChoiceFactory.Create(choiceText, testValue);

            Assert.That(choice, Is.Not.Null);
            Assert.That(choice.Value, Is.EqualTo(testValue));
        }

        [Test]
        [TestCase("")]
        [ExpectedException(typeof(InvalidDataException))]
        public void Create_WithEmptyChoiceText_ThrowsException(string choiceText)
        {
            var choice = ChoiceFactory.Create(choiceText, 0);

            Assert.That(choice, Is.Null);
        }

        [Test]
        [TestCase("1")]
        [TestCase("22")]
        public void Create_WithNonZeroLengthChoiceText_CreatesChoiceObject(string choiceText)
        {
            var choice = ChoiceFactory.Create(choiceText, 0);

            Assert.That(choice, Is.Not.Null);
            Assert.That(choice.ChoiceText, Is.EqualTo(choiceText));
        }
    }
}
