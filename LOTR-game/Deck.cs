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

        public List<Card> PlayingDeck { get; set; }

        public Deck()
        {
            _dataAccess = new DataAccess();
            PlayingDeck = new List<Card>();
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
            List<Card> list = _dataAccess.GetAllCards();
            foreach (Card card in list)
            {
                for (int i = 0; i < 5; i++)
                {
                    PlayingDeck.Add(new Card
                    {
                        Name = card.Name,
                        Attack = card.Attack,
                        Health = card.Health,
                        Cost = card.Cost,
                        Id = card.Id,
                        Type = card.Type,
                        Abilities = card.Abilities

                    });

                }

            }
        }

    }


}
