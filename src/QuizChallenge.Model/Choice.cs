namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class Choice : IChoice
    {
        public Choice(string choiceText, int value)
        {
            ChoiceText = choiceText;
            Value = value;
        }

        public string ChoiceText { get; }
        public int Value { get; }
    }
}
