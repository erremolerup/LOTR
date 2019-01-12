using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class CardAbility
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public AbilityType Type { get; set; }
        public string TypeName { get; set; }

        public override string ToString()
        {
            return $"{TypeName}:{Value}";
        }

    }

    public enum AbilityType
    {
        Damage = 1,
        DrawCard,
        LifeGain
    }
}
