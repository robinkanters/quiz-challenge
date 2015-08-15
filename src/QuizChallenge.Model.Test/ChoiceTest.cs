namespace QuizChallenge.Model.Test
{
    using System.IO;
    using NUnit.Framework;

    public class ChoiceTest
    {
        [Test]
        public void CreateChoice_WithValue_StillHasValue()
        {
            const int choiceValue = 3;
            var choice = new Choice("choice", choiceValue);
            Assert.That(choice.Value, Is.EqualTo(choiceValue));
        }

        [Test]
        public void CreateChoice_WithName_StillHasName()
        {
            const string choiceText = "1234abewlkd dweij dw98dj3w";
            var choice = new Choice(choiceText, 0);
            Assert.That(choice.ChoiceText, Is.EqualTo(choiceText));
        }
    }
}
