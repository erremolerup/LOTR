using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class Game
    {
        public int GameRound { get; set; }
        public Deck GameDeck { get; set; }
        public List<Player> Players { get; set; }
        public bool EndConditionReached { get; set; }
        readonly Print _print;

        readonly DataAccess _dataAccess;
        readonly string _name;

        public string Name { get; set; }

        public Game()
        {
            _print = new Print();
            _dataAccess = new DataAccess();
            Players = new List<Player>();

        }

        public void Run()
        {
            _print.StartMenu();
            ConsoleKey menuChoice = Console.ReadKey().Key;

            _dataAccess.GetAllUniqueCards();

            switch (menuChoice)
            {
                case ConsoleKey.D1:
                    SetUpNewGame();
                    GameLoop();
                    break;
                case ConsoleKey.D2:
                    return;
                case ConsoleKey.D3:
                    Administration();
                    return;
                default:
                    break;
            }

        }

        private void Administration()
        {
            Console.WriteLine("Choose action: ");
            Console.WriteLine("1. CreateNewCard");
            Console.WriteLine("2. UpdateCard");
            //Console.WriteLine("3. End your turn");
            //UpdateACard();

            ConsoleKey menuChoice = Console.ReadKey().Key;
            switch (menuChoice)
            {
                case ConsoleKey.D1:
                    CreateNewCard();
                    break;
                case ConsoleKey.D2:
                    UpdateACard();
                    return;
                case ConsoleKey.D3:
                    return;
                default:
                    break;
            }
        }

        private void CreateNewCard()
        {
            var newCard = new Card();

            Console.Write("Choose cardname: ");
            newCard.Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Choose cost: ");
            newCard.Cost = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Choose Attack: ");
            newCard.Attack = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Choose Health: ");
            newCard.Health = int.Parse(Console.ReadLine());

            newCard.Type = CardType.Creature;

            _dataAccess.SaveNewCard(newCard);
        }

        private void UpdateACard()
        {
            List<Card> cards = _dataAccess.GetAllUniqueCards();

            Card card1 = cards[0];

            card1.Name = "Magnus";

            _dataAccess.UpdateName(card1);
        }

        public void GameLoop()
        {

            while (true)
            {
                foreach (Player activePlayer in Players)
                {
                    activePlayer.ActivePlayer = true;
                    activePlayer.CardsInHand.Add(GameDeck.DrawCard());
                    ConsoleKey menuChoice = ConsoleKey.A;

                    while (menuChoice != ConsoleKey.D3)
                    {
                        _print.Battlefield(this);
                        _print.PlayChoices();
                        menuChoice = Console.ReadKey().Key;

                        switch (menuChoice)
                        {
                            case ConsoleKey.D1:
                                Card playedCard = activePlayer.PlayCard();
                                if (playedCard.Abilities.Count() > 0)
                                {
                                    ExecuteAbilities(playedCard);
                                }
                                break;
                            case ConsoleKey.D2:
                                int attackingCreatureIndex = activePlayer.SelectAttacker();
                                ExecuteFight(attackingCreatureIndex);
                                break;
                            default:
                                break;
                        }
                    }
                    activePlayer.Resources++;
                    activePlayer.ActivePlayer = false;
                }
            }
        }

        public void ExecuteFight(int attackingCreatureIndex)
        {
            Player Attacker = Players.FirstOrDefault(x => x.ActivePlayer);
            Player Defender = Players.FirstOrDefault(x => !x.ActivePlayer);



            if (Defender.CardsOnBoard[attackingCreatureIndex] != null)
            {
                Defender.CardsOnBoard[attackingCreatureIndex].Health -= Attacker.CardsOnBoard[attackingCreatureIndex].Attack;
                Attacker.CardsOnBoard[attackingCreatureIndex].Health -= Defender.CardsOnBoard[attackingCreatureIndex].Attack;

                if (Defender.CardsOnBoard[attackingCreatureIndex].Health < 1)
                {
                    Defender.CardsOnBoard[attackingCreatureIndex] = null;
                }

                if (Attacker.CardsOnBoard[attackingCreatureIndex].Health < 1)
                {
                    Attacker.CardsOnBoard[attackingCreatureIndex] = null;
                }

            }

            else
                Defender.LifePoints -= Attacker.CardsOnBoard[attackingCreatureIndex].Attack;

        }

        public void ExecuteAbilities(Card playedCard)
        {
            foreach (CardAbility ability in playedCard.Abilities)
            {
                if (ability.Type == AbilityType.Damage)
                {
                    foreach (Player player in Players)
                    {
                        if (player.ActivePlayer == false)
                        {
                            player.LifePoints -= ability.Value;
                        }
                    }
                }

                if (ability.Type == AbilityType.DrawCard)
                {
                    foreach (Player player in Players)
                    {
                        if (player.ActivePlayer == true)
                        {
                            for (int i = 0; i < ability.Value; i++)
                            {
                                player.CardsInHand.Add(GameDeck.DrawCard());
                            }
                        }
                    }
                }

                if (ability.Type == AbilityType.LifeGain)
                {
                    foreach (Player player in Players)
                    {
                        if (player.ActivePlayer == true)
                        {
                            player.LifePoints += ability.Value;
                        }
                    }
                }
            }
        }

        public void SetUpNewGame()
        {
            GameDeck = new Deck();
            GameDeck.PopulateDeck();
            GameDeck.Shuffle();
            AddPlayersToGame();

            foreach (Player player in Players)
            {
                for (int i = 0; i < 4; i++)
                {
                    player.CardsInHand.Add(GameDeck.DrawCard());
                }
            }

        }

        public void AddPlayersToGame()
        {
            List<Player> players = _dataAccess.GetAllUniquePlayers();
            Players.Add(players[0]);
            Players.Add(players[1]);

            players[0].ActivePlayer = true;
            players[1].ActivePlayer = false;

            foreach (Player player in Players)
            {
                player.LifePoints = 20;
                player.Resources = 1;
            }
        }

        public void EndGame()
        {

        }

    }
}
