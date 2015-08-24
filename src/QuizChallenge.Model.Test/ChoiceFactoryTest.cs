namespace QuizChallenge.Model.Test
{
    using System.IO;
    using NUnit.Framework;

    public class ChoiceFactoryTest
    {
        [Test]
        [TestCase(-1)]
        [ExpectedException(typeof(InvalidDataException))]
        public void Create_WithInvalidChoiceValue_ThrowsException(int testValue)
        {
            const string choiceText = "text doesn't matter for test";

            var choice = ChoiceFactory.Create(choiceText, testValue);

            Assert.That(choice, Is.Null);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Create_WithValidChoiceValue_CreatesChoiceObject(int testValue)
        {
            const string choiceText = "text doesn't matter for test";

            var choice = ChoiceFactory.Create(choiceText, testValue);

            Assert.That(choice, Is.Not.Null);
            Assert.That(choice.Value, Is.EqualTo(testValue));
        }
    }
}
