using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Deck
    {

        readonly DataAccess _dataAccess;

        public List<Card> PlayingDeck {get ; set ; }

        public Deck()
        {
            _dataAccess = new DataAccess();
        }

        public void Shuffle()
        {
            PlayingDeck = PlayingDeck.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card DrawCard()
        {
            var card = PlayingDeck.FirstOrDefault();
            PlayingDeck.Remove(card);

            return card;
        }

        public void PopulateDeck()
        {
            List<Card> list =_dataAccess.GetAllUniqueCards();
            //Skapar en deck med massor av kort från vår lista med unika kort
            PlayingDeck = list;

        }

    }


}
