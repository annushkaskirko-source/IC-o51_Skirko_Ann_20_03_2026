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
    public class QuestTests
    {
        [TestMethod]
        public void CompleteQuest_WhenActive_ShouldSetCompleted()
        {
            // Arrange
            var quest = new Quest("Test", "Desc", QuestCategory.Study, QuestDifficulty.Easy);

            // Act
            quest.Complete();

            // Assert
            Assert.AreEqual(QuestStatus.Completed, quest.Status);
            Assert.IsNotNull(quest.CompletedDate);
        }

        [TestMethod]
        public void Test_Exception()
        {
            var quest = new Quest("Test", "Desc", QuestCategory.Study, QuestDifficulty.Easy);
            quest.Complete();

            try
            {
                quest.Complete();
                Assert.Fail("Очікувалась помилка");
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Reward_ShouldDependOnDifficulty()
        {
            var easy = new Quest("Q1", "Desc", QuestCategory.Study, QuestDifficulty.Easy);
            var medium = new Quest("Q2", "Desc", QuestCategory.Study, QuestDifficulty.Medium);
            var hard = new Quest("Q3", "Desc", QuestCategory.Study, QuestDifficulty.Hard);

            Assert.AreEqual(20, easy.ExperienceReward);
            Assert.AreEqual(50, medium.ExperienceReward);
            Assert.AreEqual(100, hard.ExperienceReward);
        }
    }
}
