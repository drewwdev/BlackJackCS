using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list for ranks
            var ranks = new List<string>()
            {
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King",
            };

            // Create a list for suits
            var suits = new List<string>() {
            "Clubs",
            "Diamonds",
            "Hearts",
            "Spades",
            };

            // Create an empty deck list
            var deck = new List<string>() { };

            // Combine the ranks and suits decks together and add them to the deck list
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            // Shuffle the deck list
            var numberOfCards = deck.Count;
            for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);
                var leftCard = deck[leftIndex];
                var rightCard = deck[rightIndex];
                deck[rightIndex] = leftCard;
                deck[leftIndex] = rightCard;
            }

            // Create deck dictionary
            var deckDict = new Dictionary<string, int>();

            // Add strings from deck list to deckDict and assign a value
            foreach (string card in deck)
            {
                if (card.Contains("Ace"))
                    deckDict.Add(card, 11);
                if (card.Contains("2"))
                    deckDict.Add(card, 2);
                if (card.Contains("3"))
                    deckDict.Add(card, 3);
                if (card.Contains("4"))
                    deckDict.Add(card, 4);
                if (card.Contains("5"))
                    deckDict.Add(card, 5);
                if (card.Contains("6"))
                    deckDict.Add(card, 6);
                if (card.Contains("7"))
                    deckDict.Add(card, 7);
                if (card.Contains("8"))
                    deckDict.Add(card, 8);
                if (card.Contains("9"))
                    deckDict.Add(card, 9);
                if (card.Contains("10"))
                    deckDict.Add(card, 10);
                if (card.Contains("Jack"))
                    deckDict.Add(card, 10);
                if (card.Contains("Queen"))
                    deckDict.Add(card, 10);
                if (card.Contains("King"))
                    deckDict.Add(card, 10);
            }

            // Making sure all the cards exist in deckDict and that they are shuffled
            foreach (var card in deckDict)
            {
                Console.WriteLine(card);
            }


            Console.WriteLine("Let's play some Blackjack!");

            // Create a dictionary for the house
            var houseDeck = new Dictionary<string, int>() { };
        }
    }
}
