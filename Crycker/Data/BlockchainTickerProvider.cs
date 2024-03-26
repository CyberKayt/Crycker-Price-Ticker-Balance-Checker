using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using Crycker.Helper;

namespace Crycker.Data
{
    public class BlockchainTickerProvider : BaseTickerProvider, ITickerProvider
    {
        private static readonly IEnumerable<PropertyInfo> currenciesProperties = typeof(BlockchainTickerData).GetProperties().Where(property => property.PropertyType == typeof(CurrencyData));

        public BlockchainTickerProvider()
        {
            supportedCurrencies = currenciesProperties.Select(property => property.Name).ToArray();
            supportedCoins = new string[] { "BTC" };
        }        

        public string Provider
        {
            get { return "Blockchain"; }
        }

        public string TickerUrl
        {
            get { return "https://blockchain.info/charts/market-price?timespan=30days"; }
        }

        protected string BaseUrl
        {
            get { return $"https://blockchain.info/ticker"; }
        }

        public async Task UpdateData()
        {
            Logger.Info("Getting data from Blockchain.");

            try
            {
                var result = await CallRestApi(BaseUrl);
                var tickerData = ParseJsonResult<BlockchainTickerData>(result);

                LastUpdated = DateTime.Now;
                LastPrice = ((CurrencyData)currenciesProperties.Single(property => property.Name == Currency).GetValue(tickerData)).last;

                Logger.Info($"{Provider} said {Coin} = {LastPrice} {Currency} @ {LastUpdated}");
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating data.", ex);
            }
        }

    }

    [DataContract]
    public class CurrencyData
    {
        [DataMember(Name = "15m")]
        public decimal _15m { get; set; }
        [DataMember]
        public decimal last { get; set; }
        [DataMember]
        public decimal buy { get; set; }
        [DataMember]
        public decimal sell { get; set; }
        [DataMember]
        public string symbol { get; set; }
    }

    [DataContract]
    public class BlockchainTickerData
    {
        [DataMember]
        public CurrencyData USD { get; set; }
        [DataMember]
        public CurrencyData JPY { get; set; }
        [DataMember]
        public CurrencyData CNY { get; set; }
        [DataMember]
        public CurrencyData SGD { get; set; }
        [DataMember]
        public CurrencyData HKD { get; set; }
        [DataMember]
        public CurrencyData CAD { get; set; }
        [DataMember]
        public CurrencyData NZD { get; set; }
        [DataMember]
        public CurrencyData AUD { get; set; }
        [DataMember]
        public CurrencyData CLP { get; set; }
        [DataMember]
        public CurrencyData GBP { get; set; }
        [DataMember]
        public CurrencyData DKK { get; set; }
        [DataMember]
        public CurrencyData SEK { get; set; }
        [DataMember]
        public CurrencyData ISK { get; set; }
        [DataMember]
        public CurrencyData CHF { get; set; }
        [DataMember]
        public CurrencyData BRL { get; set; }
        [DataMember]
        public CurrencyData EUR { get; set; }
        [DataMember]
        public CurrencyData RUB { get; set; }
        [DataMember]
        public CurrencyData PLN { get; set; }
        [DataMember]
        public CurrencyData THB { get; set; }
        [DataMember]
        public CurrencyData KRW { get; set; }
        [DataMember]
        public CurrencyData TWD { get; set; }
    }
}
