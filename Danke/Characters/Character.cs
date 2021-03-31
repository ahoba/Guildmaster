using System;
using System.Collections.Generic;
using System.Text;

namespace Danke.Characters
{
    public enum Stats
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public class Character
    {
        public int[] Stats = new int[Enum.GetValues(typeof(Stats)).Length];

        public int TotalHp { get; set; }

        private int _currentHp;

        public int CurrentHp 
        {
            get => _currentHp;
            set
            {
                if (value < 0)
                {
                    _currentHp = 0;
                }
                else if (value > TotalHp)
                {
                    _currentHp = TotalHp;
                }
                else
                {
                    _currentHp = value;
                }
            }
        }

        public int TotalStamina { get; set; }

        private int _currentStamina;

        public int CurrentStamina
        {
            get => _currentStamina;
            set
            {
                if (value < 0)
                {
                    _currentStamina = 0;
                }
                else if (value > TotalStamina)
                {
                    _currentStamina = TotalStamina;
                }
                else
                {
                    _currentStamina = value;
                }
            }
        }
    }
}
