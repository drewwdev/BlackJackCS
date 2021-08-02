using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Let's play blackjack!");
            Console.WriteLine("Type play to play blackjack");
            var play = Console.ReadLine();
            while (play == "play")
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

                // Create a list for the house
                var houseDeck = new List<string>() { };

                // Starting hand for house
                houseDeck.Add(deck[0]);
                deckDict.Remove(deck[0]);
                houseDeck.Add(deck[1]);
                deckDict.Remove(deck[1]);


                // Calculate house starting hand value
                // int houseFirstCard = deckDict[deck[0]];
                // int houseSecondCard = deckDict[deck[1]];
                // var houseTotalValue = houseFirstCard + houseSecondCard;

                // Create a list for the player
                var playerDeck = new List<string>() { };

                // Starting hand for player
                playerDeck.Add(deck[0]);
                deckDict.Remove(deck[0]);
                playerDeck.Add(deck[1]);
                deckDict.Remove(deck[1]);

                // Calculate player starting hand value
                // var playerFirstCard = deckDict[deck[0]];
                // var playerSecondCard = deckDict[deck[1]];
                // var playerTotalValue = playerFirstCard + playerSecondCard;


                //Tell the player their starting cards
                Console.WriteLine("The player has the following cards in their hand.");
                foreach (var card in playerDeck)
                {
                    Console.WriteLine(card);
                }

                // Calculate the players current total hand
                // Console.WriteLine($"The player total is {playerTotalValue}");

                // Ask the player if they want to hit or stand
                Console.WriteLine("Does the player want to hit or stand?");
                var userInput = Console.ReadLine();

                if (userInput == "hit")
                {
                    playerDeck.Add(deck[0]);
                    deckDict.Remove(deck[0]);
                }
            }
        }
    }
}
