using System;
using Xunit;
using System.Collections.Generic;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var tester = new TacoParser();
            var input = "31.597099,-84.176122,Taco Bell Albany...";
            var actual = tester.Parse(input);
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("31.597099,-84.176122,Taco Bell Albany...", "Taco Bell Albany...")]
        public void ShouldParse(string str, string expected)
        {

            // TODO: Complete Should Parse
            TacoParser parserInstance = new TacoParser();
            ITrackable actual = parserInstance.Parse(str);
            Assert.Equal(expected, actual.Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            var fail = new TacoParser();
            var actual = fail.Parse(str);
            Assert.Null(actual);
        }
    }
}
