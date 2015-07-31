namespace QuizChallenge.Model
{
    using ModelInterfaces;

    public class QuestionFactory
    {
        public static Question Create(string questionString, params IChoice[] choices)
        {
            return new Question(questionString, choices);
        }
    }
}
