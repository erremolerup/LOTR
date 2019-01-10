using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public CardType Type { get; set; }
        public List<CardAbility> Abilities { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }

        public Card()
        {
            Abilities = new List<CardAbility>();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Name + " ");
            stringBuilder.Append("$" + Cost);

            if (Attack != 0 && Health != 0)
                stringBuilder.Append($" {Attack}/{Health} ");

            if(Abilities.Count > 0)
            {
                foreach (var ability in Abilities)
                {
                    stringBuilder.Append($"{Enum.GetName(typeof(AbilityType), ability.Type)}{ability.Value} ");
                }
            }

            return stringBuilder.ToString();
        }

    }



    public enum CardType
    {
        Creature,
        Spell
    }
}
