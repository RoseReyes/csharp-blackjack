using System;
using System.Collections.Generic;
using DeckOfCards;
using Players;

namespace BlackJack
{
    class Program
    {
    
        // static void StartDeal(){
        //     Player Javier = new Player("Javier");
        //     Dealer D = new Dealer();
        //     Deck NewDeck = new Deck();
        //     NewDeck.Deal();

        static void Main(string[] args)
        {
           
            Console.ResetColor();
            Player player = new Player();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please enter your name: ");
            player.name = Console.ReadLine();

            Dealer dealer = new Dealer();
            Console.Write("Please enter a name for the dealer: ");
            dealer.name = Console.ReadLine();

         
            Console.WriteLine("How many deck do you want to play?: ");
            string test = Console.ReadLine();
            int test1 = Int32.Parse(test);
            Deck NewDeck = new Deck(test1);

            NewDeck.Deal();
            player.Hit(NewDeck);
            dealer.Hit(NewDeck);
            player.Hit(NewDeck);
            dealer.Hit(NewDeck);
            dealer.Showupcard();

            if(player.handvalue == 21){
                player.money += player.bet * 2;
                Console.WriteLine("BLACKJACK! WINNER WINNER CHICKEN DINNER!");
                return;
            }

            
            Console.Write("Hit or Stick? ");
            string choice = Console.ReadLine();

            if(choice.ToUpper() == "HIT")
            {
                player.Hit(NewDeck); 
            }

            if(choice.ToUpper() == "STICK")
            {
                dealer.Hit(NewDeck);

                if(dealer.handvalue < 17 || dealer.handvalue < 21)
                {
                    dealer.Hit(NewDeck);
                }
                if(dealer.handvalue > 21)
                {
                 
                    Console.WriteLine("Play Again (Y/N): ");
                    string play = Console.ReadLine();
                   
                    if(play.ToUpper() == "Y")
                    {
                        player.Discard();
                        dealer.Discard();
                        NewDeck.Reset(test1);
                        return;
                    } 
                }
            }
            if(player.handvalue > 21)
            {
                Console.WriteLine("You Bust!");
                Console.WriteLine("Play Again (Y/N): ");
                string play = Console.ReadLine();
                if(play.ToUpper() == "Y")
                {
                    player.Discard();
                    dealer.Discard();
                    NewDeck.Reset(test1);

                }
            }
            else if(player.handvalue < 21)
            {
                Console.Write("Hit or Stick? ");
                string choice1 = Console.ReadLine();
                if(choice1.ToUpper() == "HIT")
                {
                 player.Hit(NewDeck); 
                } 
                if(player.handvalue > 21)
                {
                Console.WriteLine("You Bust!");
                Console.WriteLine("Play Again (Y/N): ");
                string play = Console.ReadLine();
                if(play.ToUpper() == "Y")
                {
                    player.Discard();
                    dealer.Discard();
                    NewDeck.Reset(test1);

                }

                }

            }
           
           
            // Class Constructor will not tansfer over. Need to user database.
            // int newcount = 0;
            // foreach (var card in NewDeck.cards){
            //     newcount++;
            //     Console.WriteLine(card.stringVal + card.suit);
            // }
            // Console.WriteLine(newcount);
        }
    }
}
