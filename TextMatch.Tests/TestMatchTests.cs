using NUnit.Framework;

namespace TextMatch.Tests
{
    [TestFixture]
    public class TestMatchTests
    {
        [TestCase("Polly", new int[] { 1, 26, 51 })]
        [TestCase("ll", new int[] { 3, 28, 53, 78, 82 })]
        [TestCase("X", new int[] { })]
        [TestCase("Polx", new int[] { })]
        public void Process_WithTestCases_ShouldReturnExpected(string subText, int[] expected)
        {
            // arrange
            var text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

            // act
            var actual = Program.Process(text, subText);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Process_WithIncompleteMatch_ShouldIterateOnceAndReturnExpected()
        {
            // arrange
            var text = "Polly poll";
            var subText = "Polly";
            var expected = new int[] { 1 };

            // act
            var actual = Program.Process(text, subText);

            // assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Process_WithTwoSequentialMatches_ShouldIterateTwiceAndReturnExpected()
        {
            // arrange
            var text = "Pollypolly";
            var subText = "Polly";
            var expected = new int[] { 1, 6 };

            // act
            var actual = Program.Process(text, subText);

            // assert
            Assert.AreEqual(actual, expected);
        }
    }
}