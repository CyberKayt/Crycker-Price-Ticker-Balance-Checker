using System;
using System.Threading.Tasks;

namespace Crycker.Data
{
    interface ITickerProvider
    {
        string TickerUrl { get; }

        string Provider { get; }
        string Coin { get; set; }
        string Currency { get; set; }
        decimal LastPrice { get; set; }

        DateTime LastUpdated { get; set; }

        string[] SupportedCurrencies { get; }
        string[] SupportedCoins { get; }
        
        Task UpdateData();        
    }
}