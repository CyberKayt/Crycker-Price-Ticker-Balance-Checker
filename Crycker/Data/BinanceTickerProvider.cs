using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Crycker.Helper;

namespace Crycker.Data
{
    class BinanceTickerProvider : BaseTickerProvider, ITickerProvider
    {
        public BinanceTickerProvider()
        {
            supportedCurrencies = new string[] { "EUR", "USDT" };
            supportedCoins = new string[] { "BNB"};
        }

        public string Provider
        {
            get { return "Binance"; }
        }

        public string TickerUrl
        {
            get { return "https://api.binance.com/api/v3/ticker/price"; }
        }

        protected string BaseUrl
        {
            get { return $"{TickerUrl}?symbol={_coin}{_currency}"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Coinbase.");

            try
            {
                var result = await CallRestApi(BaseUrl);
                var tickerData = ParseJsonResult<BinanceTickerData>(result);

                LastUpdated = DateTime.Now;

                LastPrice = tickerData.price;

                Logger.Info($"{Provider} said {Coin} = {LastPrice} {Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating data.", ex);
            }
        }
    }

    [DataContract]
    public class BinanceTickerData
    {
        [DataMember]
        public decimal price { get; set; }
        [DataMember]
        public string symbol { get; set; }
    }
}
