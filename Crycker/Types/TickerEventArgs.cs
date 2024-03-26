using System;

namespace Crycker.Types
{
    public class TickerEventArgs : EventArgs
    {
        public string Provider;
        public string Coin;
        public string Currency;
        
        public DateTime LastUpdated;
        public decimal LastPrice;

        //public DateTime PreviousUpdate;
        public decimal PreviousPrice;

        //public decimal DeltaPrice;
        //public decimal DeltaPercent;
    }
}