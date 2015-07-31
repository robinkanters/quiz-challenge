namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class Choice : IChoice
    {
        internal Choice(string choiceText, int value)
        {
            ChoiceText = choiceText;
            Value = value;
        }

        public string ChoiceText { get; }
        public int Value { get; }
    }
}
