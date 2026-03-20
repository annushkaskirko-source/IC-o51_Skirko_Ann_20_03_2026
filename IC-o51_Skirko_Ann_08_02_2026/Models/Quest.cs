using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IC_o51_Skirko_Ann_08_02_2026.Models
{
    // Модель квесту (тільки дані)
    public class Quest
    {
        // Унікальний ідентифікатор
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва квесту обов'язкова")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Назва повинна містити від 3 до 100 символів")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Опис обов'язковий")]
        [StringLength(300,
            ErrorMessage = "Опис не може бути довшим за 300 символів")]
        public string Description { get; private set; }

        public QuestCategory Category { get; private set; }
        public QuestDifficulty Difficulty { get; private set; }
        public QuestStatus Status { get; private set; }

        [Range(1, 1000,
            ErrorMessage = "Кількість досвіду повинна бути від 1 до 1000")]
        public int ExperienceReward { get; private set; }

        // Дата створення
        public DateTime CreatedDate { get; private set; }

        // Дата виконання
        public DateTime? CompletedDate { get; private set; }

        // Конструктор
        public Quest(string name,
                     string description,
                     QuestCategory category,
                     QuestDifficulty difficulty)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва квесту не може бути порожньою.");

            if (name.Length < 3)
                throw new ArgumentException("Назва повинна містити мінімум 3 символи.");

            if (description != null && description.Length > 300)
                throw new ArgumentException("Опис занадто довгий.");

            Name = name;
            Description = description;
            Category = category;
            Difficulty = difficulty;

            Status = QuestStatus.Active;
            CreatedDate = DateTime.Now;

            ExperienceReward = CalculateReward();
        }

        public void Edit(string name,
                         string description,
                         QuestCategory category,
                         QuestDifficulty difficulty)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва не може бути порожньою.");

            if (name.Length < 3)
                throw new ArgumentException("Назва повинна містити мінімум 3 символи.");

            Name = name;
            Description = description;
            Category = category;
            Difficulty = difficulty;

            ExperienceReward = CalculateReward();
        }

        // Розрахунок нагороди
        private int CalculateReward()
        {
            switch (Difficulty)
            {
                case QuestDifficulty.Easy:
                    return 20;

                case QuestDifficulty.Medium:
                    return 50;

                case QuestDifficulty.Hard:
                    return 100;

                default:
                    return 0;
            }
        }

        // Виконати квест
        public void Complete()
        {
            if (Status == QuestStatus.Completed)
                throw new InvalidOperationException("Цей квест вже виконано.");

            Status = QuestStatus.Completed;
            CompletedDate = DateTime.Now;
        }

        public void SetCreatedDate(DateTime date)
        {
            CreatedDate = date;
        }

        public void SetCompletedDate(DateTime? date)
        {
            CompletedDate = date;
        }

        // Відображення в ListBox
        public override string ToString()
        {
            return $"[{Id}] {Name} | {Category} | {Difficulty} | {Status}";
        }
    }
}
