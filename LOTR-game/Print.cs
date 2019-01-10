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
            GameLogo();
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. End Game");
        }

        public void PlayChoices()
        {
            Console.WriteLine("Choose action: ");
            Console.WriteLine("1. Play a card");
            Console.WriteLine("2. Attack with a creature");
            Console.WriteLine("3. End your turn");
        }

        public void Battlefield(Game game)
        {
            Console.Clear();


            Console.Write($"{game.Players[0].Name,-10}: ");
            Console.Write($"LifePoints: {game.Players[0].LifePoints} Resources: {game.Players[0].Resources}");
            Console.WriteLine();
            Console.WriteLine();


            Console.Write("Cards in Hand:  | ");
            foreach (Card card in game.Players[0].CardsInHand)
            {
                Console.Write("{0}, ",card);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Cards on Table: | ");

            foreach (Card card in game.Players[0].CardsOnBoard)
            {
                Console.Write("{0,-25} | ", card);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-',25*7)); // ------------------------



            Console.Write("Cards on Table: | ");

            foreach (Card card in game.Players[1].CardsOnBoard)
            {
                Console.Write("{0,-25} | ", card);
            }

            Console.WriteLine();
            Console.WriteLine();



            Console.Write("Cards in Hand:  | ");

            foreach (Card card in game.Players[1].CardsInHand)
            {
                Console.Write("{0}, ", card);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write($"{game.Players[1].Name,-10}: ");
            Console.Write($"LifePoints: {game.Players[1].LifePoints} Resources: {game.Players[1].Resources}");
        }

    }
}
