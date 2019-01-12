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

        public List<Card> GetAllCards() // Läser data från databasen
        {
            var sql = @"SELECT * FROM Card
                        JOIN CardType ON Card.CardTypeId = CardType.CardTypeID
                        LEFT JOIN AbilityToCard On AbilityToCard.CardId = Card.CardID
                        LEFT JOIN Ability ON AbilityToCard.AbilityId = Ability.AbilityID
                        LEFT JOIN AbilityType On Ability.AbilityTypeId = AbilityType.AbilityTypeID";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Card>();

                while (reader.Read())
                {
                    if (!list.Any(x => x.Id == reader.GetSqlInt32(0).Value)) //Kontrollerar om kortet redan finns, nytt kort skapas om  false
                    {
                        Card c = new Card
                        {
                            Id = reader.GetSqlInt32(reader.GetOrdinal("CardID")).Value, // 0
                            Name = reader.GetSqlString(reader.GetOrdinal("Name")).Value, // 1
                            Cost = reader.GetSqlInt32(reader.GetOrdinal("Cost")).Value, // 2
                            Type = (CardType) reader.GetSqlInt32(reader.GetOrdinal("CardTypeId")).Value, // 3
                            TypeName = reader.GetSqlString(reader.GetOrdinal("CardTypeName")).Value // 7

                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("Attack")) && !reader.IsDBNull(reader.GetOrdinal("Health")))
                        {
                            c.Attack = reader.GetSqlInt32(reader.GetOrdinal("Attack")).Value; // 4
                            c.Health = reader.GetSqlInt32(reader.GetOrdinal("Health")).Value; // 5
                        }

                        list.Add(c);
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("AbilityID"))) //8
                    {
                        CardAbility cardAbility = new CardAbility
                        {
                            Id = reader.GetSqlInt32(reader.GetOrdinal("AbilityID")).Value, //10
                            Type = (AbilityType) reader.GetSqlInt32(reader.GetOrdinal("AbilityTypeId")).Value, // 12
                            Value = reader.GetSqlInt32(reader.GetOrdinal("Value")).Value, //13
                            TypeName = reader.GetSqlString(reader.GetOrdinal("AbilityTypeName")).Value //15
                        };

                        list[list.Count - 1].Abilities.Add(cardAbility);
                    }
                }
                return list;
            }
        }

        internal void RemoveCard(Card cardToRemove)
        {
            RemoveCardAbilities(cardToRemove);

            var sql = @"DELETE Card
                        WHERE CardID = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>();//Skapar en lista som vi kan spara alla våra parametrar i.
            var parameter = new SqlParameter("Id", cardToRemove.Id);

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(parameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Player> GetAllPlayers() // Läser data från databasen
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

        internal void SaveNewAbility(CardAbility newAbility) // OK
        {
            var sql = @"INSERT INTO Ability
                        VALUES (@AbilityType, @Value)";

            List<SqlParameter> parameters = new List<SqlParameter>(); //Skapar en lista som vi kan spara alla våra parametrar i.
            parameters.Add(new SqlParameter("AbilityType", (int) newAbility.Type));
            parameters.Add(new SqlParameter("Value", newAbility.Value));

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var parameter in parameters) //Loop genom alla våra parametrar för att lägga in dem i "command"
                    command.Parameters.Add(parameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<CardAbility> GetAllAbilities() // OK Läser data från databasen...
        {
            var sql = @"SELECT *
                        FROM Ability
                        JOIN AbilityType ON Ability.AbilityTypeId = AbilityType.AbilityTypeID";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<CardAbility>();

                while (reader.Read())
                {
                    CardAbility p = new CardAbility
                    {
                        Id = reader.GetSqlInt32(reader.GetOrdinal("AbilityID")).Value,  //2
                        Value = reader.GetSqlInt32(reader.GetOrdinal("Value")).Value, //1
                        Type = (AbilityType)reader.GetSqlInt32(reader.GetOrdinal("AbilityTypeId")).Value,
                        TypeName = reader.GetSqlString(reader.GetOrdinal("AbilityTypeName")).Value
                    };

                    list.Add(p);
                }
                return list;
            }
        }

        internal void UpdateAllCardAttributes(Card cardToUpdate)
        {
            var sql = @"UPDATE Card
                        SET Name = @Name, Cost = @Cost, Attack = @Attack, Health = @Health
                        WHERE CardID = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>();//Skapar en lista som vi kan spara alla våra parametrar i.
            parameters.Add(new SqlParameter("Name", cardToUpdate.Name));
            parameters.Add(new SqlParameter("Cost", cardToUpdate.Cost));
            parameters.Add(new SqlParameter("Attack", cardToUpdate.Attack));
            parameters.Add(new SqlParameter("Health", cardToUpdate.Health));
            parameters.Add(new SqlParameter("Id", cardToUpdate.Id));


            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

                connection.Open();
                command.ExecuteNonQuery();
            }

            RemoveCardAbilities(cardToUpdate);
            SaveAbilitiesToCard(cardToUpdate);

        }

        internal void RemoveCardAbilities(Card cardToUpdate)
        {
            var sql = @"DELETE
                        FROM AbilityToCard
                        WHERE CardId = @Id";

            var parameter = new SqlParameter("Id", cardToUpdate.Id);

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(parameter);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        internal void SaveNewCard(Card newCard) // OK Sparar ett kort i databasen
        {
            var sql = @"INSERT INTO Card
                        OUTPUT INSERTED.CardID
                        VALUES (@Name, @Cost, @Type, @Attack, @Health)";

            List<SqlParameter> parameters = new List<SqlParameter>();//Skapar en lista som vi kan spara alla våra parametrar i.
            parameters.Add(new SqlParameter("Name", newCard.Name));
            parameters.Add(new SqlParameter("Cost", newCard.Cost));
            parameters.Add(new SqlParameter("Type", (int)newCard.Type));
            parameters.Add(new SqlParameter("Attack", newCard.Attack));
            parameters.Add(new SqlParameter("Health", newCard.Health));

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                foreach (var parameter in parameters) //Loop genom alla våra parametrar för att lägga in dem i "command"
                    command.Parameters.Add(parameter);

                connection.Open();
                newCard.Id = (int)command.ExecuteScalar();
            }

            SaveAbilitiesToCard(newCard);

        }

        private void SaveAbilitiesToCard(Card newCard) // OK Sparar ett korts abilities i databasen
        {
            foreach (CardAbility ability in newCard.Abilities)
            {

                var sql = @"INSERT INTO AbilityToCard
                        VALUES (@AbilityId, @CardId)";

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("AbilityId", ability.Id),
                    new SqlParameter("CardId", newCard.Id)
                };

                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    foreach (var parameter in parameters) //Loop genom alla våra parametrar för att lägga in dem i "command"
                        command.Parameters.Add(parameter);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

       
    }
}
