using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestesCasino;

namespace BestesCasino.Tests
{
    [TestClass]
    public class SlotMachineTests
    {
        [TestMethod]
        public void SpinReels_ThreeMatchingNumbers_Wins()
        {
            
            SlotMachine slotMachine = new SlotMachine();
            slotMachine.SetChips(100);

            
            slotMachine.SpinReels(10);

            
            Assert.AreEqual(110, slotMachine.AccountBalance);
        }

        [TestMethod]
        public void SpinReels_NoMatchingNumbers_Loses()
        {
            
            SlotMachine slotMachine = new SlotMachine();
            slotMachine.SetChips(100);

            
            slotMachine.SpinReels(10);

            
            Assert.AreEqual(90, slotMachine.AccountBalance);
        }
    }
}
