# BlackJackCS

Create a class called deck
Attributes of a deck:
52 different cards, a way to shuffle (shuffling code from AllCardsOnDeck), deal
Create a class called card
Attributes of a card:
A rank, a suit, and a value: The value of a card is based on its rank: Ace = 11, number cards = their number, Jack, Queen, and King = 10

Create a list of cards from the deck class and call it mainDeck
Shuffle mainDeck using deck class
Get 2 cards from mainDeck
Add them to the houseDeck list
Remove them from the mainDeck
Get 2 more cards from the mainDeck
Add them to the playerHand list
Remove them from the mainDeck

Show the player the 2 cards that they have in playerHand and tell them the current total value of their hand
Ask the player if they want to hit (add another card to playerHand)
If they say they want to hit, add the next card in mainDeck to playerHand, and remove it from mainDeck
Calculate the playerHand as they have cards added to playerHand
If the total of playerHand's cards goes over 21 tell them they went bust
If the player decides to stand then the house must add cards to houseDeck until they reach 17 or more
If the houseDeck goes over 21 they go bust
If there is a tie the house wins
The program should tell who wins
The program should ask the player if they want to play again
If they do, the cards should all be added back to deck and reshuffled
