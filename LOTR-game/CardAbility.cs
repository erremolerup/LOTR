﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class CardAbility
    {
        public int Value { get; set; }
        public AbilityType Type { get; set; }

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(AbilityType), Type)} {Value}";
        }
    }

    public enum AbilityType
    {
        LifeGain,
        Damage,
        DrawCard
    }
}
