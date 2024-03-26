using Crycker.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Crycker.Data
{
    public class BaseTickerProvider
    {
        protected string[] supportedCurrencies;
        public string[] SupportedCurrencies
        {
            get
            {
                return supportedCurrencies;
            }
            private set
            {
                supportedCurrencies = value;
            }
        }

        protected string[] supportedCoins;
        public string[] SupportedCoins
        {
            get
            {
                return supportedCoins;
            }
            private set
            {
                supportedCoins = value;
            }
        }

        public DateTime LastUpdated { get; set; }
        public decimal LastPrice { get; set; }

        protected string _coin;
        protected string _currency;
        
        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value == null)
                    return;

                var currencyValue = value.ToUpper();

                if (new List<string>(supportedCurrencies).Contains(currencyValue))
                {
                    _currency = currencyValue;
                }
                else
                {
                    _currency = supportedCurrencies[0];
                }
            }
        }

        public string Coin
        {
            get { return _coin; }
            set
            {
                if (value == null)
                    return;

                var coinValue = value.ToUpper();

                if (new List<string>(supportedCoins).Contains(coinValue))
                {
                    _coin = coinValue;
                }
                else
                {
                    _coin = supportedCoins[0];
                }                              
            }
        }

        protected async Task<Stream> CallRestApi(string baseUrl)
        {
            Stream response = null;
            try { 
            var client = new HttpClient();
                response = await client.GetStreamAsync(baseUrl);
                
            }catch(Exception ex)
            {
                Logger.Error(ex.ToString());
                throw;
            }

            return response;
        }

        protected T ParseJsonResult<T>(Stream jsonStream) where T : new()
        {            
            var serializer = new DataContractJsonSerializer(typeof(T));            
            var tickerData = (T)serializer.ReadObject(jsonStream);            
            return tickerData;
        }
    }
}