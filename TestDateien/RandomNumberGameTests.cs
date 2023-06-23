using BetterThanLasVegas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BetterThanLasVegasTest
{
    [TestClass]
    public class RandomNumberGameTest
    {
        [TestMethod]
        public void PlayGame_PlayerWins()
        {
            
            RandomNumberGame game = new RandomNumberGame();
            string input = "50\n";
            string expectedOutput = "Glückwunsch, du hast die Zahl erraten!";
            int expectedChips = 100;

            using (StringWriter sw = new StringWriter())
            {
                
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                game.Play();

                string consoleOutput = sw.ToString().Trim();

                
                Assert.IsTrue(consoleOutput.Contains(expectedOutput));
                Assert.AreEqual(expectedChips, game.GetChips());
            }
        }

        [TestMethod]
        public void PlayGame_PlayerLoses()
        {
            
            RandomNumberGame game = new RandomNumberGame();
            string input = "1\n1\n1\n1\n1\n1\n";
            string expectedOutput = "Du hast nichts verloren";
            int expectedChips = 0;

            using (StringWriter sw = new StringWriter())
            {
                
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                game.Play();

                string consoleOutput = sw.ToString().Trim();

                
                Assert.IsTrue(consoleOutput.Contains(expectedOutput));
                Assert.AreEqual(expectedChips, game.GetChips());
            }
        }
    }
}
