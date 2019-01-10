using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTR_game
{
    public class DataAccess
    {

        public string conString = "Server=(localdb)\\mssqllocaldb; Database=LOTR-game";

        public List<Card> GetAllUniqueCards()
        {
            var sql = @"SELECT * FROM Card
                        INNER JOIN CardType ON CardTypeId = CardType.Id
                        LEFT JOIN AbilityToCard On AbilityToCard.CardId = Card.Id
                        LEFT JOIN CardAbilities ON CardAbilities.Id = AbilityToCard.CardAbility
                        LEFT JOIN AbilityType ON AbilitieTypeId = AbilityType.Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Card>();

                while (reader.Read())
                {
                    if (!list.Any(x => x.Id == reader.GetSqlInt32(0).Value))
                    {

                        Card c = new Card
                        {
                            Id = reader.GetSqlInt32(0).Value,
                            Name = reader.GetSqlString(1).Value,
                            Cost = reader.GetSqlInt32(2).Value,
                            Type = (CardType)Enum.Parse(typeof(CardType), reader.GetSqlString(7).Value)

                        };

                        if (!reader.IsDBNull(4) && !reader.IsDBNull(5))
                        {
                            c.Attack = reader.GetSqlInt32(4).Value;
                            c.Health = reader.GetSqlInt32(5).Value;
                        }

                        list.Add(c);

                    }


                    if (!reader.IsDBNull(8))
                    {

                        CardAbility cardAbility = new CardAbility
                        {
                            Type = (AbilityType)Enum.Parse(typeof(AbilityType), reader.GetSqlString(14).Value),
                            Value = reader.GetSqlInt32(12).Value
                        };
                        
                        list[list.Count - 1].Abilities.Add(cardAbility);
                    }


                }
                return list;
            }
        }

        public List<Player> GetAllUniquePlayers()
        {
            var sql = @"SELECT * FROM Player";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Player>();

                while (reader.Read())
                {
                    Player p = new Player
                    {
                        Name = reader.GetSqlString(0).Value,
                        Wins = reader.GetSqlInt32(1).Value,
                        Losses = reader.GetSqlInt32(2).Value,

                    };

                    list.Add(p);

                }
                return list;
            }
        }

    }
}
