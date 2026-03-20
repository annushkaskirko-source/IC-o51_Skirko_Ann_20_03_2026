using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_o51_Skirko_Ann_08_02_2026.Models
{
    // Модель гравця
    public class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Experience { get; private set; }

        public Player(string name)
        {
            Name = name;
            Level = 1;
            Experience = 0;
        }

        public void AddExperience(int amount)
        {
            Experience += amount;

            while (Experience >= Level * 100)
            {
                Experience -= Level * 100;
                Level++;
            }
        }
        public void LoadData(string name, int level, int experience)
        {
            Name = name;
            Level = level;
            Experience = experience;
        }

        public int GetProgressPercent()
        {
            return (int)((double)Experience / (Level * 100) * 100);
        }
    }
}
