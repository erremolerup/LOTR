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

        public Player()
        {
            CardsInHand = new List<Card>();
            CardsOnBoard = new List<Card>() { null, null, null, null, null, null };

        }

        public Card PlayCard()
        {
            Console.WriteLine("Which card do you want to play?");
            ConsoleKey playCardChoice = Console.ReadKey(true).Key;
            int chosenCardIndex = (int)playCardChoice - (int)ConsoleKey.D1;

            Card chosenCard = CardsInHand[chosenCardIndex];

            if (chosenCard.Type == CardType.Creature)
            {
                Console.WriteLine("Where do you want to place your creature?");
                ConsoleKey creaturePlacement = Console.ReadKey(true).Key;
                int chosenPlacementIndex = (int)creaturePlacement - (int)ConsoleKey.D1;

                CardsOnBoard[chosenPlacementIndex] = chosenCard;
            }

            CardsInHand.Remove(chosenCard);
            return chosenCard;

        }


        public int SelectAttacker()
        {
            Console.WriteLine("Which creature do you want to attack with?");
            ConsoleKey attackChoice = Console.ReadKey(true).Key;
            int chosenCardIndex = (int)attackChoice - (int)ConsoleKey.D1;

            Card chosenCard = CardsOnBoard[chosenCardIndex];

            return chosenCardIndex;

        }
    }
}
