
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BestesCasino
{
    public class RandomNumberGame : IGame_P
    {
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private const int MaxAttempts = 5;
        private const int WinReward = 100;
        private const int LossPenalty = 50;

        private readonly Random _random = new Random();
        private int _secretNumber;
        private int _attemptCount;
        private int _chips;
        private int _guess;

        public int GetChips()
        {
            return _chips;
        }


        public void Play()
        { 
            Console.Clear();
            Console.WriteLine("\n Das Random Numbergame wird gestartet...");

            StartRandomNumberGame();
        }

        public void StartRandomNumberGame()
        {
            Console.WriteLine(" ===== ======= \n Willkommen beim Random Numbergame! Hier kannst du deine Jetons gewinnen oder verlieren.");

            int totalRoundsToPlay = AskHowManyRoundsToPlay(); 
            PlayRounds(totalRoundsToPlay);

            Console.WriteLine("\n=== Spiel beendet ===");
            Console.WriteLine($"Vielen Dank fürs Spielen! Du hast {_chips} Jetons gewonnen.");
            Console.WriteLine("\n===              ===\n");
        }

        public void PlayRounds(int totalRoundsToPlay)
        {
            for (int round = 1; round <= totalRoundsToPlay; round++)
            {
                Console.Clear();
                Console.WriteLine($"\n=== Runde {round} von {totalRoundsToPlay} ===\n");
                StartGame();

                if (round == totalRoundsToPlay && AskToPlayAgain())
                { 
                    totalRoundsToPlay = AskHowManyRoundsToPlay();
                    round = 0;
                }
            }
        }

        public bool AskToPlayAgain()
        {
            Console.Write("Möchtest du noch weitere Runden spielen? (ja/nein): ");
            string answer = Console.ReadLine().ToLower();
            return answer == "ja"; 
        }

        public int AskHowManyRoundsToPlay()
        {
            int totalRoundsToPlay;
            do
            {
                Console.Write("\n Wie viele Runden möchtest du spielen? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out totalRoundsToPlay) || totalRoundsToPlay <= 0)
                {
                    Console.WriteLine("Bitte gib eine Zahl über 0 ein.");
                }
            } while (totalRoundsToPlay <= 0);
            return totalRoundsToPlay;
        }

        public void StartGame()
        {
            InitializeGame();
            PlayGame();
            DisplayResult();
        }

        public void InitializeGame()
        {
            Console.WriteLine($"Ich denke an eine Zahl zwischen {MinNumber} und {MaxNumber}.");
            _secretNumber = _random.Next(MinNumber, MaxNumber + 1); 
            _attemptCount = 0;
        }

        public void PlayGame()
        {
            while (true)
            {
                Console.Write($"Rate die Zahl: ");
                if (!GetGuess())
                {
                    continue;
                }
                if (!ValidateGuess())
                {
                    continue;
                }

                _attemptCount++;

                if (_guess == _secretNumber)
                {
                    Win();
                    break;
                }
                else if (_guess < _secretNumber)
                {
                    Console.WriteLine("Die gesuchte Zahl ist größer.");
                }
                else
                {
                    Console.WriteLine("Die gesuchte Zahl ist kleiner.");
                }

                if (_attemptCount > MaxAttempts)
                {
                    Lose();
                    break;
                }
            }
        }

        public bool GetGuess()
        {
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
                return false;
            }
            _guess = guess;
            return true;
        }

        public bool ValidateGuess()
        {
            if (_guess < MinNumber || _guess > MaxNumber)
            {
                Console.WriteLine($"Ungültige Eingabe! Bitte geben Sie eine Zahl zwischen {MinNumber} und {MaxNumber} ein.");
                return false;
            }
            return true;
        }

        public void Win()
        {
            Console.WriteLine("Glückwunsch, du hast die Zahl erraten! ");
            Console.WriteLine($"Anzahl der Versuche: {_attemptCount}");
            _chips += WinReward;
            Console.WriteLine($"Du hast {WinReward} Jetons gewonnen, weil du die Zahl in weniger als {MaxAttempts} Versuchen erraten hast!");
        }

        public void Lose()
        {
            if (_chips >= LossPenalty)
            {
                Console.WriteLine($"Du hast {LossPenalty} Jetons verloren, weil du die Zahl nicht in {MaxAttempts} Versuchen erraten hast. Die gesuchte Zahl war {_secretNumber}.");
                _chips -= LossPenalty;
            }
            else
            {
                Console.WriteLine($"Du hast nichts verloren, da du nur noch {_chips} Jetons hast. Du hast die Zahl nicht in {MaxAttempts} Versuchen erraten. Die gesuchte Zahl war {_secretNumber}.");
            }
        }

        public void DisplayResult()
        {
            Console.WriteLine($"Deine aktuellen Jetons: {_chips}");
        }

        public void SetChips(int chips)
        {
            _chips = chips;
        }
    }
}