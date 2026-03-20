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
    public class QuestRepositoryTests
    {
        [TestMethod]
        public void Add_ShouldIncreaseCount()
        {
            var repo = new QuestRepository(); 

            repo.Add(new Quest("Q1", "D", QuestCategory.Study, QuestDifficulty.Easy));

            Assert.AreEqual(1, repo.Count);
        }

        [TestMethod]
        public void Remove_ShouldDeleteQuest()
        {
            var repo = new QuestRepository();

            var quest = new Quest("Q1", "D", QuestCategory.Study, QuestDifficulty.Easy);

            repo.Add(quest);
            repo.Remove(quest);

            Assert.AreEqual(0, repo.Count);
        }

        [TestMethod]
        public void GetActiveQuests_ShouldReturnOnlyActive()
        {
            var repo = new QuestRepository();

            var q1 = new Quest("Q1", "D", QuestCategory.Study, QuestDifficulty.Easy);
            var q2 = new Quest("Q2", "D", QuestCategory.Work, QuestDifficulty.Medium);

            repo.Add(q1);
            repo.Add(q2);

            q1.Complete();

            var active = repo.GetActiveQuests();

            Assert.AreEqual(1, active.Count());
        }
    }
}
