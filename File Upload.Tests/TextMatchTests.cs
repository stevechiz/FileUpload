using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextMatch.Tests
{
    [TestClass]
    public class StringSearchTests
    {

        private string _testText1 = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
        private string _testText2 = "pollypollypollypppppppppppppppppppppppppppppolly        &8908** y8&* }╔ Ãpoll";

        [TestMethod]
        public void StringSearch_WithMatchingString1_ReturnsResults()
        {
            string subText = "PollY";
            
            var stringSearch = new Services.StringSearchService();

            var matches = stringSearch.MatchString(_testText1, subText);

            Assert.AreEqual(matches, "1,26,51");

            subText = "ll";

            matches = stringSearch.MatchString(_testText1, subText);

            Assert.AreEqual(matches, "3,28,53,78,82");

            subText = "X";

            matches = stringSearch.MatchString(_testText1, subText);

            Assert.AreEqual(matches, "");
        }

        [TestMethod]
        public void StringSearch_WithMatchingString2_ReturnsResults()
        {
            string subText = "PollY";
            
            var stringSearch = new Services.StringSearchService();

            var matches = stringSearch.MatchString(_testText2, subText);

            Assert.AreEqual(matches, "1,6,11,44");

            subText = "ll";

            matches = stringSearch.MatchString(_testText2, subText);

            Assert.AreEqual(matches, "3,8,13,46,76");

            subText = "p";

            matches = stringSearch.MatchString(_testText2, subText);

            Assert.AreEqual(matches, "1,6,11,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,74");
        }

        [TestMethod]
        public void StringSearch_WithNonMatchingString_ReturnsBlank()
        {
            string subText = "X";

            var stringSearch = new Services.StringSearchService();

            string matches = stringSearch.MatchString(_testText1, subText);

            Assert.AreEqual(matches, "");
        }

    }
}
