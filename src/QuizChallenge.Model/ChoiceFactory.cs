namespace QuizChallenge.Model
{
    public class ChoiceFactory
    {
        public static Choice Create(string choiceText, int value)
        {
            return new Choice(choiceText, value);
        }
    }
}
