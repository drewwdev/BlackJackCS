using System;
using System.Collections.Generic;

class Deck
{
    // shuffle
}
class Card
{
    public string Rank { get; set; }
    public string Suit { get; set; }

    public int Value()
    {
        switch (Rank)
        {
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
                return int.Parse(Rank);
            case "Jack":
            case "Queen":
            case "King":
                return 10;
            case "Ace":
                return 11;
            default:
                return 0;
        }
    }

    override public string ToString()
    {
        return ($"{Rank} of {Suit}");
    }

}

class Hand
{
    public List<Card> CurrentCards { get; set; } = new List<Card>();

    public int TotalValue()
    {
        var total = 0;
        foreach (var card in CurrentCards)
        {
            total = total + card.Value();
        }

        return total;
    }

    public void AddCard(Card cardToAdd)
    {
        CurrentCards.Add(cardToAdd);
    }

    public void PrintCardsAndTotal(string handName)
    {
        Console.WriteLine($"{handName}, your cards are:");
        Console.WriteLine(String.Join(", ", CurrentCards));
        Console.WriteLine($"The total value of {handName}'s hand is: {TotalValue()}");
        Console.WriteLine();
    }
}

namespace Blackjack
{
    class Program
    {
        static void PlayTheGame()
        {
            Console.WriteLine("🂡    🂸   🃎   🂹   🃄");
            Console.WriteLine("Let's play blackjack!");
            Console.WriteLine("🂭    🃄    🂧   🃓  🂸");
            Console.WriteLine();
            var deck = new List<Card>();

            var suits = new List<string>() {
                "Clubs",
                "Diamonds",
                "Hearts",
                "Spades"
                };

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
                "King"
                };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var newCard = new Card()
                    {
                        Suit = suit,
                        Rank = rank,
                    };
                    deck.Add(newCard);
                }
            }

            var numberOfCards = deck.Count;

            for (var rightIndex = numberOfCards - 1; rightIndex > 1; rightIndex--)
            {
                var randomNumberGenerator = new Random();
                var leftIndex = randomNumberGenerator.Next(rightIndex);
                var leftCard = deck[leftIndex];
                var rightCard = deck[rightIndex];
                deck[rightIndex] = leftCard;
                deck[leftIndex] = rightCard;
            }

            var player = new Hand();

            var dealer = new Hand();

            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];
                deck.Remove(card);
                player.AddCard(card);
            }

            for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
            {
                var card = deck[0];
                deck.Remove(card);
                dealer.AddCard(card);
            }

            Console.WriteLine($"The dealers first card is {dealer.CurrentCards[0]}");
            Console.WriteLine();

            var answer = "";

            while (player.TotalValue() < 21 && answer != "stand")
            {
                player.PrintCardsAndTotal("Player");
                Console.Write("Do you want to hit or stand? ");
                Console.WriteLine();
                answer = Console.ReadLine().ToLower();

                if (answer == "hit")
                {
                    var newCard = deck[0];
                    deck.Remove(newCard);
                    player.AddCard(newCard);
                }
            }

            player.PrintCardsAndTotal("Player");

            while (player.TotalValue() <= 21 && dealer.TotalValue() <= 17)
            {
                var card = deck[0];
                deck.Remove(card);
                dealer.AddCard(card);
            }

            dealer.PrintCardsAndTotal("Dealer");

            if (player.TotalValue() > 21)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            if (dealer.TotalValue() > 21)
            {
                Console.WriteLine("Player wins!");
            }
            else
            if (dealer.TotalValue() > player.TotalValue())
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            if (player.TotalValue() > dealer.TotalValue())
            {
                Console.WriteLine("Player wins!");
            }
            else
            {
                Console.WriteLine("Dealer wins!");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                PlayTheGame();

                Console.WriteLine();
                Console.Write("Keep playing? ");
                var answer = Console.ReadLine().ToLower();

                if (answer == "no")
                {
                    Console.WriteLine("Player quit the game");
                    break;
                }
            }
        }
    }
}