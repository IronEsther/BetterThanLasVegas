using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterThanLasVegas
{
    public interface IObservable_SM
    {
        void AddObserver(IObserver_SM observer);
        void RemoveObserver(IObserver_SM observer);
        void NotifyObservers();
    }
}
