using IC_o51_Skirko_Ann_08_02_2026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace IC_o51_Skirko_Ann_08_02_2026.LifeRPG.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void CompleteQuest_ShouldAddExperienceToPlayer()
        {
            var manager = GameManager.Instance;

            var quest = new Quest("Test", "Desc", QuestCategory.Study, QuestDifficulty.Easy);
            manager.AddQuest(quest);

            int xpBefore = manager.Player.Experience;

            manager.CompleteQuest(quest);

            Assert.IsTrue(manager.Player.Experience > xpBefore);
        }
    }
}
