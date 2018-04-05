using System;
using System.Collections.Generic;
namespace DeckOfCards{
    public class Card{
        public string stringVal;
        public string suit;
        public int val;

        public Card(string name, string suitType, int value){
            stringVal = name;
            suit = suitType;
            val = value;

        }
    }

    public class Deck{
        public List<Card> cards;
        public int Decks;
        
        public Deck(int DeckAmount){
            CreateDeck(DeckAmount);
            Shuffle();
        }
        public void CreateDeck(int Decks){
            cards = new List<Card>();
            for( int deck = 0; deck < Decks; deck++){
                string[] suits = {"♣", "♥", "♦", "♠"};
                string[] cardname = {"2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"};
                int[] cardval = {2,3,4,5,6,7,8,9,10,10,10,10,11};
                foreach( string suit in suits){
                    for (int i = 0; i < 13; i++){
                        cards.Add(new Card(cardname[i], suit, cardval[i]));
                    }
                }
            }
        }
        public Card Deal(){
            Card topcard = cards[0];
            if (cards.Count > 0){
                cards.Remove(topcard);
            }
            return topcard;
        }
        public void Reset(int DeckAmount){
            cards = new List<Card>();
            CreateDeck(DeckAmount);
            Shuffle();
        }
        public void Shuffle(){
            Random rand = new Random();
            for(int idx = 0; idx < cards.Count-1; idx++){
                int swap = rand.Next(0,52);
                Card temp = cards[swap];
                cards[swap] = cards[idx];
                cards[idx] = temp;
            }
        }
    }
}
