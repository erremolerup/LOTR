using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Card
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public CardType Type { get; set; }
        public CardAbility Ability { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
    }

    public enum CardType
    {
        Creature,
        Spell
    }
}
