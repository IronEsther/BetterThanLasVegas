using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterThanLasVegas;

namespace BetterThanLasVegas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validSelection = false;
            while (!validSelection)
            {
                Console.WriteLine("\n |||||||||||||||||       ||||||||||||||||||||");
                Console.WriteLine("Willkommen im BestesCasino! Bitte wähle ein Spiel aus (Eingabe der Zahl): ");
                Console.WriteLine("1. Random Number Game");
                Console.WriteLine("2. Slotmachine");
                Console.Write("\n Deine Auswahl: ");

                string userInput = Console.ReadLine();
                int selectedGame;

                if (int.TryParse(userInput, out selectedGame))
                {
                    IGame_P game;

                    switch (selectedGame)
                    {
                        case 1:
                            game = GameFactory_P.CreateGame<RandomNumberGame>();
                            break;
                        case 2:
                            game = GameFactory_P.CreateGame<SlotMachine>();
                            break;
                        default:
                            Console.WriteLine("Ungültige Auswahl.");
                            continue; 
                    }

                    bool playAgain = true;
                    while (playAgain)
                    {
                        Console.Write("Bitte gib den Betrag für dein ausgewähltes Spiel ein (0 zum Beenden): ");
                        string chipsInput = Console.ReadLine();
                        int chips;

                        if (int.TryParse(chipsInput, out chips) && chips == 0)
                        {
                            Console.WriteLine("Spiel beendet.");
                            break; 
                        }

                        if (int.TryParse(chipsInput, out chips) && chips < 0)
                        {
                            Console.WriteLine("Ungültiger Betrag.");
                            continue; 
                        }

                        game.SetChips(chips);
                        game.Play();
                        break;
                    }

                    Console.Clear();
                  
                    Console.Write("Möchtest du ein weiteres Spiel spielen? (ja/nein): ");
                    string playAgainInput = Console.ReadLine();

                    if (playAgainInput.ToLower() != "ja")
                    {
                        validSelection = true; 
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Auswahl.");
                }
            }
        }
    }
}
