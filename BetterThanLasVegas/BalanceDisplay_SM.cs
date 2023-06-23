using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterThanLasVegas
{
    class BalanceDisplay_SM : IObserver_SM
    {
        private SlotMachine slotMachine;

        public BalanceDisplay_SM(SlotMachine slotMachine)
        {
            this.slotMachine = slotMachine;
        }

        public void Update()
        {
            Console.WriteLine($"Aktueller Kontostand (BalanceDisplay): {slotMachine.AccountBalance} Jetons");
        }
    }
}
