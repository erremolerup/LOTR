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
        public string TypeName { get; set; }
        public List<CardAbility> Abilities { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }

        public string GetTypeName { get { return Enum.GetName(typeof(CardType), Type); } }

        public Card()
        {
            Abilities = new List<CardAbility>();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Name + " ");
            stringBuilder.Append("$" + Cost);

            if (Type == CardType.Creature)
                stringBuilder.Append($" {Attack}/{Health} ");

            if (Abilities.Count > 0)
                    stringBuilder.Append(string.Join(' ', Abilities));

            return stringBuilder.ToString();
        }

    }



    public enum CardType
    {
        Creature = 1,
        Spell
    }
}
