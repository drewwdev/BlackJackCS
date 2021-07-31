using System;
using System.Collections.Generic;

namespace BlackJackCS
{
    class deck
    {
        public string card { get; set; }
        static void Shuffle()
        {
            var deck = new List<string>() { };
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
        }
    }
    class card
    {
    }
    class Program
    {
        static void Card()
        {
            var ranks = new List<string>() {
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

            var suits = new List<string>() { };
            suits.Add("Clubs");
            suits.Add("Diamonds");
            suits.Add("Hearts");
            suits.Add("Spades");
            var deck = new List<string>() { };

            foreach (string rank in ranks)
            {
                foreach (string suit in suits)
                {
                    deck.Add($"{rank} of {suit}");
                }

            }



        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play some Blackjack!");
        }

    }

}
