namespace QuizChallenge.Model.Test
{
    using NUnit.Framework;
    
    public class QuizRepositoryTest
    {
        [Test]
        public void QuizRepository_CreateQuiz_Succeeds()
        {
            const string quizName = "Quiz name";

            var repo = QuizRepository.Instance;
            var quiz = repo.CreateQuiz(quizName);
            Assert.That(quiz.Name, Is.EqualTo(quizName));
        }

        [Test]
        public void QuizRepository_CreateWithChoices_HasChoices()
        {
            const string quizName = "Quiz name";

            var question1 = QuestionFactory.Create("Some question",
                ChoiceFactory.Create("Some choice", 10),
                ChoiceFactory.Create("Some other choice", 0),
                ChoiceFactory.Create("Some third choice", 20)
            );
            var question2 = QuestionFactory.Create("Some other question",
                ChoiceFactory.Create("Some choice", 10),
                ChoiceFactory.Create("Some other choice", 0)
            );

            var repo = QuizRepository.Instance;
            var quiz = repo.CreateQuiz(quizName, question1, question2);

            Assert.That(quiz.Questions.Count, Is.EqualTo(2));
            Assert.That(quiz.Questions[0].QuestionString, Is.EqualTo("Some question"));
            Assert.That(quiz.Questions[0].Choices.Count, Is.EqualTo(3));
            Assert.That(quiz.Questions[0].Choices[1].ChoiceText, Is.EqualTo("Some other choice"));
            Assert.That(quiz.Questions[0].Choices[2].Value, Is.EqualTo(20));
            Assert.That(quiz.Questions[1].QuestionString, Is.EqualTo("Some other question"));
            Assert.That(quiz.Questions[1].Choices.Count, Is.EqualTo(2));
            Assert.That(quiz.Questions[1].Choices[0].ChoiceText, Is.EqualTo("Some choice"));
            Assert.That(quiz.Questions[1].Choices[1].Value, Is.EqualTo(0));
        }
    }
}
