using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOTR_game
{
    partial class Game
    {
         private void Administration()
        {
            while (true)
            {
                _print.AdminMenue();

                ConsoleKey menuChoice = Console.ReadKey(true).Key;
                switch (menuChoice)
                {
                    case ConsoleKey.D1:
                        CreateNewCard();
                        break;
                    case ConsoleKey.D2:
                        CreateNewAbility();
                        break;
                    case ConsoleKey.D3:
                        var cardToUpdate = ChooseCardMenue();
                        UpdateCardMenue(cardToUpdate);
                        break;
                    case ConsoleKey.D4:
                        RemoveCardMenue();
                        break;
                    case ConsoleKey.D5:
                        return;
                    default:
                        break;
                }
            }
        }

        private void RemoveCardMenue()
        {
            Card cardToRemove = ChooseCardMenue();
            _dataAccess.RemoveCard(cardToRemove);
        }

        private void UpdateCardMenue(Card cardToUpdate)
        {
            while (true)
            {
                _print.UpdateCardMenue(cardToUpdate.ToString());

                Console.WriteLine("What do you want to update? Press 'F2' to save updates or 'Esc' to go back to main menue");
                Console.WriteLine();
                ConsoleKey menuChoice = Console.ReadKey(true).Key;

                switch (menuChoice)
                {
                    case ConsoleKey.D1:
                        Console.Write("Enter new name: ");
                        cardToUpdate.Name = Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Write("Enter new cost: ");
                        cardToUpdate.Cost = int.Parse(Console.ReadLine());
                        break;
                    case ConsoleKey.D3:
                        Console.Write("Enter new Attack value: ");
                        cardToUpdate.Attack = int.Parse(Console.ReadLine());
                        break;
                    case ConsoleKey.D4:
                        Console.Write("Enter new Defense value: ");
                        cardToUpdate.Health = int.Parse(Console.ReadLine());
                        break;
                    case ConsoleKey.D5:
                        for (int i = 0; i < cardToUpdate.Abilities.Count; i++)
                            Console.WriteLine($"{i + 1}. {cardToUpdate.Abilities[i]}");
                        Console.Write("Select an ability index from above to remove: ");
                        var abilityToRemoveIndex = int.Parse(Console.ReadLine());
                        cardToUpdate.Abilities.RemoveAt(abilityToRemoveIndex - 1);
                        break;
                    case ConsoleKey.D6:
                        List<CardAbility> awailableCardAbilities = _dataAccess.GetAllAbilities();
                        for (int i = 0; i < awailableCardAbilities.Count; i++)
                            Console.WriteLine($"{i + 1}. {awailableCardAbilities[i]}");
                        Console.Write("Select an ability index from above to add: ");
                        var abilityToAddIndex = int.Parse(Console.ReadLine());
                        if (!cardToUpdate.Abilities.Any(x => x.Id == awailableCardAbilities[abilityToAddIndex - 1].Id))
                            cardToUpdate.Abilities.Add(awailableCardAbilities[abilityToAddIndex - 1]);
                        break;
                    case ConsoleKey.F2:
                        uppdateAllCardAttributes(cardToUpdate);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }

        }

        private void uppdateAllCardAttributes(Card cardToUpdate)
        {
            _dataAccess.UpdateAllCardAttributes(cardToUpdate);
        }

        private void CreateNewAbility()
        {
            var newAbility = new CardAbility();
            Console.Clear();

            var abilityTypes = Enum.GetNames(typeof(AbilityType));

            for (int i = 0; i < abilityTypes.Length; i++)
                Console.WriteLine($"{i + 1}. {abilityTypes[i]}");

            Console.WriteLine();
            Console.Write("Select an ability type index from above: ");

            var abilityIndex = int.Parse(Console.ReadLine());
            newAbility.Type = (AbilityType)abilityIndex;

            Console.Write("Chose ability value: ");
            newAbility.Value = int.Parse(Console.ReadLine());

            _dataAccess.SaveNewAbility(newAbility);
        }

        private void CreateNewCard()
        {
            Console.Clear();
            var newCard = new Card();

            Console.Write("Choose cardname: ");
            newCard.Name = Console.ReadLine();

            Console.Write("Choose cost: ");
            newCard.Cost = int.Parse(Console.ReadLine());

            Console.Write("Choose Attack: ");
            newCard.Attack = int.Parse(Console.ReadLine());

            Console.Write("Choose Health: ");
            newCard.Health = int.Parse(Console.ReadLine());

            Console.Write("Creature or Spell? (c/r)");
            newCard.Type = Console.ReadLine() == "c" ? CardType.Creature : CardType.Spell;

            int choosenAbilityIndex;

            do
            {
                Console.WriteLine();

                List<CardAbility> cardAbilities = _dataAccess.GetAllAbilities();

                for (int i = 0; i < cardAbilities.Count; i++)
                    Console.WriteLine($"{i + 1}. {cardAbilities[i]}");

                Console.Write("Add an ability index from above or press 0 to continue without abilities: ");
                choosenAbilityIndex = int.Parse(Console.ReadLine());
                if (choosenAbilityIndex != 0)
                    newCard.Abilities.Add(cardAbilities[choosenAbilityIndex - 1]);

            } while (choosenAbilityIndex != 0);


            _dataAccess.SaveNewCard(newCard);
        }

        private Card ChooseCardMenue()
        {
            Console.Clear();
            List<Card> cards = _dataAccess.GetAllCards();

            for (int i = 0; i < cards.Count; i++)
                Console.WriteLine($"{i + 1}. {cards[i]}");

            Console.Write("Select a Card index from above: ");
            var choosenCardIndex = int.Parse(Console.ReadLine());

            return cards[choosenCardIndex - 1];

        }
    }
}
