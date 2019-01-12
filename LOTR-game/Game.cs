using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public partial class Game
    {
        public int GameRound { get; set; }
        public Deck GameDeck { get; set; }
        public List<Player> Players { get; set; }
        public bool EndConditionReached { get; set; }
        readonly Print _print;

        readonly DataAccess _dataAccess;

        public Game()
        {
            _print = new Print();
            _dataAccess = new DataAccess();
            Players = new List<Player>();

        }

        public void Run()
        {
            while (true)
            {
                _print.StartMenu();
                ConsoleKey menuChoice = Console.ReadKey(true).Key;

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
                        break;
                    default:
                        break;
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
                for (int i = 0; i < 4; i++)
                    player.CardsInHand.Add(GameDeck.DrawCard());

        }

        public void AddPlayersToGame()
        {
            List<Player> players = _dataAccess.GetAllPlayers();

            for (int playerNumber = 0; playerNumber < 2; playerNumber++)
            {
                _print.ClearAndPrintIndexedList(players.Select(x => x.Name).ToList());

                Console.Write($"Player {playerNumber + 1}, select a player index from the above or create a new player by entering a new name: ");

                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int index))
                {
                    Players.Add(players[index - 1]);
                }
                else
                {
                    var newPlayer = new Player();
                    newPlayer.Name = userInput;
                    Players.Add(newPlayer);
                }
            }

            players[0].ActivePlayer = true;
            players[1].ActivePlayer = false;

            foreach (Player player in Players)
            {
                player.LifePoints = 20;
                player.Resources = 1;
            }
        }

        public void GameLoop()
        {
            while (true)
            {
                foreach (Player activePlayer in Players)
                {
                    activePlayer.ActivePlayer = true;
                    activePlayer.CardsInHand.Add(GameDeck.DrawCard());
                    ConsoleKey menuChoice = ConsoleKey.NoName;

                    while (menuChoice != ConsoleKey.D3)
                    {
                        _print.Battlefield(this);
                        _print.PlayChoices();
                        menuChoice = Console.ReadKey(true).Key;

                        switch (menuChoice)
                        {
                            case ConsoleKey.D1:

                                Card playedCard = activePlayer.PlayCard();
                                if (playedCard.Abilities.Count() > 0)
                                    ExecuteAbilities(playedCard);
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
                    Defender.CardsOnBoard[attackingCreatureIndex] = null;

                if (Attacker.CardsOnBoard[attackingCreatureIndex].Health < 1)
                    Attacker.CardsOnBoard[attackingCreatureIndex] = null;
            }
            else
                Defender.LifePoints -= Attacker.CardsOnBoard[attackingCreatureIndex].Attack;

        }

        public void ExecuteAbilities(Card playedCard)
        {
            Player Attacker = Players.FirstOrDefault(x => x.ActivePlayer);
            Player Defender = Players.FirstOrDefault(x => !x.ActivePlayer);

            foreach (CardAbility ability in playedCard.Abilities)
            {
                if (ability.Type == AbilityType.Damage)
                {
                    Defender.LifePoints -= ability.Value;
                }

                else if (ability.Type == AbilityType.DrawCard)
                {
                    for (int i = 0; i < ability.Value; i++)
                    {
                        Attacker.CardsInHand.Add(GameDeck.DrawCard());
                    }
                }

                else if (ability.Type == AbilityType.LifeGain)
                {
                    Attacker.LifePoints += ability.Value;
                }
            }
        }

        public void EndGame()
        {

        }

    }
}
