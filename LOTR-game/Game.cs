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

        readonly DataAccess _dataAccess;

        public void Run()
        {
            SetUpNewGame();
        }

        public void GameLoop()
        {

        }

        public void StartMenu()
        {

        }

        public void SetUpNewGame()
        {
            GameDeck = new Deck();
            GameDeck.PopulateDeck();
            GameDeck.Shuffle();

        }

        public void AddPlayersToGame()
        {
            List<Player> players = _dataAccess.GetAllUniquePlayers();
        }

        public void EndGame()
        {

        }

    }
}
