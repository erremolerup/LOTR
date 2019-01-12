using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Print
    {
        public string gameLogo = @"
 (                                                     (                          
 )\ )             (           (         )    )         )\ )                       
(()/(       (     )\ )        )\ )   ( /( ( /(    (   (()/( (          (  (       
 /(_))  (   )(   (()/(    (  (()/(   )\()))\())  ))\   /(_)))\   (     )\))(  (   
(_))    )\ (()\   ((_))   )\  /(_)) (_))/((_)\  /((_) (_)) ((_)  )\ ) ((_))\  )\  
| |    ((_) ((_)  _| |   ((_)(_) _| | |_ | |(_)(_))   | _ \ (_) _(_/(  (()(_)((_) 
| |__ / _ \| '_|/ _` |  / _ \ |  _| |  _|| ' \ / -_)  |   / | || ' \))/ _` | (_-< 
|____|\___/|_|  \__,_|  \___/ |_|    \__||_||_|\___|  |_|_\ |_||_||_| \__, | /__/ 
           - The Console Cardgame                                     |___/ 
";

        public string BattleFieldCardsInHandTemplate = "{1,-20}, ";
        public string BattleFieldCardsOnBoardTemplate = "| {1,-20} ";


        public void GameLogo()
        {
            Console.WriteLine(gameLogo);
        }

        public void CardOnBoard()
        {

        }

        public void CardInHand()
        {

        }

        public void StartMenu()
        {
            Console.Clear();
            GameLogo();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. End Game");
            Console.WriteLine("3. Administrate Cards");
        }

        internal void AdminMenue()
        {
            Console.Clear();
            Console.WriteLine("Choose action: ");
            Console.WriteLine("1. Create New Card");
            Console.WriteLine("2. Create New Ability");
            Console.WriteLine("3. UpdateCard");
            Console.WriteLine("4. Remove Card");
            Console.WriteLine("5. Return to main menue");
        }

        public void PlayChoices()
        {
            Console.WriteLine("Choose action: ");
            Console.WriteLine("1. Play a card");
            Console.WriteLine("2. Attack with a creature");
            Console.WriteLine("3. End your turn");
        }

        internal void ClearAndPrintIndexedList(List<string> list)
        {
            Console.Clear();
            for (int i = 0; i < list.Count(); i++)
                Console.WriteLine($"{i + 1}. {list[i]}");
        }

        public void Battlefield(Game game)
        {
            Console.Clear();

            if (game.Players[0].ActivePlayer)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{game.Players[0].Name}: ");
            Console.ResetColor();
            Console.Write($"LifePoints: {game.Players[0].LifePoints} Resources: {game.Players[0].Resources}");
            Console.WriteLine();
            Console.WriteLine();


            Console.Write("Cards in Hand:  | ");
            for (int i = 0; i < game.Players[0].CardsInHand.Count; i++)
            {
                Console.Write("{0}.[{1}] ", i + 1, game.Players[0].CardsInHand[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Cards on Table: | ");

            foreach (Card card in game.Players[0].CardsOnBoard)
            {
                Console.Write("{0,-25} | ", card);
            }

            Console.WriteLine();

            Console.Write(new string('-', 28)); // ------------------------
            for (int i = 1; i <= 6; i++)
                Console.Write($"Slot{i}" + new string('-', 23));
            Console.WriteLine();


            Console.Write("Cards on Table: | ");

            foreach (Card card in game.Players[1].CardsOnBoard)
            {
                Console.Write("{0,-25} | ", card);
            }

            Console.WriteLine();
            Console.WriteLine();



            Console.Write("Cards in Hand:  | ");

            for (int i = 0; i < game.Players[1].CardsInHand.Count; i++)
            {
                Console.Write("{0}.[{1}] ", i + 1, game.Players[1].CardsInHand[i]);


            }

            Console.WriteLine();
            Console.WriteLine();

            if (game.Players[1].ActivePlayer)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{game.Players[1].Name}: ");
            Console.ResetColor();
            Console.Write($"LifePoints: {game.Players[1].LifePoints} Resources: {game.Players[1].Resources}");


            Console.WriteLine();
            Console.WriteLine();
        }

        internal void UpdateCardMenue(string cardString)
        {
            Console.Clear();
            Console.WriteLine("Card card: " + cardString);
            Console.WriteLine("1. Update Name");
            Console.WriteLine("2. Uppdate Cost");
            Console.WriteLine("3. Uppdate Attack");
            Console.WriteLine("4. Uppdate Health");
            Console.WriteLine("5. Remove Ability");
            Console.WriteLine("6. Add Ability");
            Console.WriteLine("7. Return to main menue");

        }
    }
}
