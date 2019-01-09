using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Player
    {
        public string Name { get; set; }
        public int LifePoints { get; set; }
        public bool ActivePlayer { get; set; }
        public List<Card> CardsInHand { get; set; }
        public List<Card> CardsOnBoard { get; set; }
        public int Resources { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public void LifeChanger()
        {

        }

        public void ResourceChanger()
        {

        }

        public void PlayCard()
        {

        }

        public void ReceiveCard()
        {

        }

        public void ChangePlayerTurn()
        {

        }


    }
}
