namespace QuizChallenge.Model
{
    using System.IO;

    public class ChoiceFactory
    {
        public static Choice Create(string choiceText, int value)
        {
            if (choiceText.Length <= 0)
                throw new InvalidDataException($"{choiceText} is not a valid choice text");
            if(value < 0)
                throw new InvalidDataException($"{value} is not a valid value, must be 0 or higher");

            return new Choice(choiceText, value);
        }
    }
}
