using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Crycker.Helper;
using System.IO;
using System.Text;

namespace Crycker.Data
{
    public class BitstampTickerProvider : BaseTickerProvider, ITickerProvider
    {
        public BitstampTickerProvider() 
        {
            supportedCurrencies = new string[] { "EUR", "USD" };
            supportedCoins = new string[] { "BTC", "XRP", "LTC", "ETH" };            
        }

        public string Provider
        {
            get { return "Bitstamp"; }
        }

        public string TickerUrl
        {
            get { return "https://www.bitstamp.net/market/tradeview/"; }
        }

        protected string BaseUrl
        {
            get { return $"https://www.bitstamp.net/api/v2/ticker/{_coin.ToLower()}{_currency.ToLower()}/"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Bitstamp.");

            try
            {
                var result = await CallRestApi(BaseUrl);
                BitstampTickerData tickerData;
                try
                {
                    tickerData = ParseJsonResult<BitstampTickerData>(result);
                }
                catch 
                {
                    result.Position = 0;
                    using (StreamReader reader = new StreamReader(result, Encoding.UTF8))
                    {
                        Logger.Error(reader.ReadToEnd());
                    }
                    throw;
                }

                LastUpdated = DateTime.Now;
                LastPrice = tickerData.last;

                Logger.Info($"{Provider} said {Coin} = {LastPrice} {Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error("Update data failed:", ex);
                Logger.Error(ex.ToString());
            }
        }
    }

    [DataContract]
    internal class BitstampTickerData
    {
        [DataMember]
        public decimal high { get; set; }
        [DataMember]
        public decimal last { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public decimal bid { get; set; }
        [DataMember]
        public string vwap { get; set; }
        [DataMember]
        public decimal volume { get; set; }
        [DataMember]
        public decimal low { get; set; }
        [DataMember]
        public decimal ask { get; set; }
        [DataMember]
        public decimal open { get; set; }
    }
}
