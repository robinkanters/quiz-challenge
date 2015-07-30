namespace QuizChallenge.Model.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnswerTest
    {
        public void Answer_Creation_ShouldWork()
        {
            var answer = new Answer(null, null);
            Assert.IsNotNull(answer);
        }
    }
}
