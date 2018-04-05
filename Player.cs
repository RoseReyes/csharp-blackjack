using System;
using System.Collections.Generic;
using DeckOfCards;
namespace Players{
    public class Player{
        public string name;
        public List<Card> hand;
        public int handvalue;
        public int bet;
        public int money;
        public Player(){
            hand = new List<Card>();
        }
        public void Hit(Deck cards){
            Card newcard = cards.Deal();
            handvalue += newcard.val;
            hand.Add(newcard);
            Console.WriteLine(this.name + ": " + newcard.stringVal+" of "+newcard.suit + " value: " + newcard.val);
            Console.WriteLine(this.name + ": " + "handvalue: " + handvalue);
            // Below for Ace transform to 1 based off handvalue
            int aceCount = 0;
            if (newcard.stringVal == "Ace"){
                aceCount++;                
            }
            for(int idx = 0; idx < hand.Count-1; idx++){
                if(handvalue > 21){
                    if(hand[idx].stringVal == "Ace"){
                        for(int ace = 0; ace<aceCount; ace++){
                            hand[idx].val = 1;
                            handvalue -= 10;
                            Console.WriteLine(this.name + ": " + newcard.stringVal+" of "+newcard.suit + " value: " + newcard.val);
                            continue;
                        }
                    }
                }
            }
            // Below is to discard player hand if lose/Bust.
            // if (handvalue > 21){
            //     Console.WriteLine("BUST!!");
            //     Discard();
            //     bet = 0;
            // }
        }
        // Method below discards player hand
        public void Discard(){
            for (int idx = 0; idx<hand.Count-1; idx++){
                hand.RemoveAt(idx);
            }
            // Console.WriteLine(hand);
            handvalue = 0;
        }
    }
    public class Dealer{
        public string name = "Dealer";
        public List<Card> hand;
        public int handvalue;
        public int upcard;
        public Dealer(){
            hand = new List<Card>();
        }
        // Need to find way to have first ace turn to 1 if handvalue > 21; and if new hand value > 21 ace [2] == 0 if no more aces then break loop; 
        public void Hit(Deck cards){
            Card newcard = cards.Deal();
            handvalue += newcard.val;
            hand.Add(newcard);
            // Console.WriteLine(this.name + ": " +  newcard.stringVal+" of "+newcard.suit + " value: " + newcard.val);
            //Console.WriteLine(this.name + ": " +"handvalue: " + handvalue);

            if (handvalue > 21){
                Console.WriteLine("BUST Players WIN and Dealers LOSE!!");
                //Discard();
            }
        }
        // Method belows shows dealer face card
        public void Showupcard(){
            Console.WriteLine("DEALER FACE CARD: " + this.hand[0].stringVal + " of " + this.hand[0].suit);
        }
        // Method below discards Dealer hand
        public void Discard(){
            for (int idx = 0; idx<hand.Count-1; idx++){
                hand.RemoveAt(idx);
            }
            // Console.WriteLine(hand);
            handvalue = 0;
        }
    }
}
