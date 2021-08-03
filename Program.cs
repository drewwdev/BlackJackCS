using System;
using System.Collections.Generic;

class Deck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public Deck()
    {
        Initialize();
        Shuffle();
    }
    public void Initialize()
    {
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
                Cards.Add(newCard);
            }
        }

    }

    public void Shuffle()
    {
        var numberOfCards = Cards.Count;

        for (var rightIndex = numberOfCards - 1; rightIndex > 1; rightIndex--)
        {
            var randomNumberGenerator = new Random();
            var leftIndex = randomNumberGenerator.Next(rightIndex);
            var leftCard = Cards[leftIndex];
            var rightCard = Cards[rightIndex];
            Cards[rightIndex] = leftCard;
            Cards[leftIndex] = rightCard;
        }

    }

    public Card Deal()
    {
        var card = Cards[0];
        Cards.Remove(card);
        return card;
    }

    public List<Card> DealMultiple(int numberOfCardsToDeal)
    {
        var multipleCards = new List<Card>();
        for (int count = 0; count < numberOfCardsToDeal; count++)
        {
            Card dealtCard = Deal();

            multipleCards.Add(dealtCard);
        }

        return multipleCards;
    }
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

    public void AddCards(List<Card> cardsToAdd)
    {
        foreach (Card card in cardsToAdd)
        {
            AddCard(card);
        }
    }
}

namespace Blackjack
{
    class Program
    {
        static void PlayTheGame()
        {
            Console.WriteLine("♥️   ♣️   🃟   ♦️   ♠️");
            Console.WriteLine("Let's play blackjack!");
            Console.WriteLine("♥️   ♣️   🃟   ♦️   ♠️");
            Console.WriteLine();

            var deck = new Deck();

            var playerHand = new Hand();

            var dealerHand = new Hand();

            playerHand.AddCards(deck.DealMultiple(2));

            dealerHand.AddCards(deck.DealMultiple(2));

            Console.WriteLine($"The dealers first card is {dealerHand.CurrentCards[0]}");
            Console.WriteLine();

            var answer = "";

            while (playerHand.TotalValue() < 21 && answer != "stand")
            {
                playerHand.PrintCardsAndTotal("Player");
                Console.Write("Do you want to hit or stand? ");
                Console.WriteLine();
                answer = Console.ReadLine().ToLower();

                if (answer == "hit")
                {
                    Card card = deck.Deal();
                    playerHand.AddCard(card);
                }
            }

            playerHand.PrintCardsAndTotal("Player");

            while (playerHand.TotalValue() <= 21 && dealerHand.TotalValue() <= 17)
            {
                Card card = deck.Deal();
                dealerHand.AddCard(card);
            }

            dealerHand.PrintCardsAndTotal("Dealer");

            if (playerHand.TotalValue() > 21)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            if (dealerHand.TotalValue() > 21)
            {
                Console.WriteLine("Player wins!");
            }
            else
            if (dealerHand.TotalValue() > playerHand.TotalValue())
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            if (playerHand.TotalValue() > dealerHand.TotalValue())
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