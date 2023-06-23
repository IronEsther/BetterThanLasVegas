using System;
using BetterThanLasVegas;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BetterThanLasVegas
{
    
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

   
    public interface IObserver
    {
        void Update();
    }

    public class SlotMachine : IGame_P, IObservable
    {
        private Random random;
        public int AccountBalance { get; private set; }
        private List<IObserver> observers;

        public SlotMachine()
        {
            random = new Random();
            AccountBalance = 1000;
            observers = new List<IObserver>();
        }

        public void Play()
        {
            Console.WriteLine("Die Slotmaschine wird gestartet...");

            while (true)
            {
                StartSlotMachine();

                Console.Write("Möchten Sie erneut spielen? (ja/nein): ");
                string input = Console.ReadLine();

                if (input.ToLower() != "ja")
                    break;
            }
        }

        public void StartSlotMachine()
        {
            Console.WriteLine($"Aktueller Kontostand: {AccountBalance} Jetons");

            Console.Write("Geben Sie Ihren Einsatz ein: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int bet) || bet <= 0)
            {
                Console.WriteLine("Ungültiger Einsatz. Bitte geben Sie einen gültigen Betrag ein.");
                return;
            }

            if (bet > AccountBalance)
            {
                Console.WriteLine("Sie haben nicht genügend Guthaben für diesen Einsatz.");
                return;
            }

            SpinReels(bet);
        }

        public void SpinReels(int bet)
        {
            int reel1 = random.Next(1, 7);
            int reel2 = random.Next(1, 7);
            int reel3 = random.Next(1, 7);

            Console.WriteLine($"Gewinnzahlen: {reel1} - {reel2} - {reel3}");

            if (reel1 == reel2 && reel2 == reel3)
            {
                int winnings = bet * 10;
                Console.WriteLine($"Herzlichen Glückwunsch! Sie haben {winnings} Jetons gewonnen!");
                AccountBalance += winnings;
            }
            else
            {
                Console.WriteLine("Leider verloren. Versuchen Sie es erneut!");
                AccountBalance -= bet;
            }

            Console.WriteLine($"Aktueller Kontostand: {AccountBalance} Jetons");

           
            NotifyObservers();
        }

        public void SetChips(int chips)
        {
            AccountBalance = chips;
        }

        
        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    
    class BalanceDisplay : IObserver
    {
        public SlotMachine slotMachine;

        public BalanceDisplay(SlotMachine slotMachine)
        {
            this.slotMachine = slotMachine;
        }

        public void Update()
        {
            Console.WriteLine($"Aktueller Kontostand (BalanceDisplay): {slotMachine.AccountBalance} Jetons");
        }
    }
}