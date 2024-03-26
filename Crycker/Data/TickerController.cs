using System;
using System.Timers;
using Crycker.Helper;
using Crycker.Types;

namespace Crycker.Data
{
    public class TickerController
    {
        private static ITickerProvider _ticker;
        private static Timer _timer;

        private string coin;
        private string currency;

        decimal lastPrice;        

        public event EventHandler<TickerEventArgs> DataUpdated = delegate { };

        public string[] SupportedCurrencies { get { return _ticker.SupportedCurrencies; } }
        public string[] SupportedCoins { get { return _ticker.SupportedCoins; }  }    
        public string TickerUrl { get { return _ticker.TickerUrl; } }

        public void SetProvider(string provider)
        {
            switch (provider.ToLower())
            {
                case "bitstamp":
                    _ticker = new BitstampTickerProvider();                    
                    break;
                case "blockchain":
                    _ticker = new BlockchainTickerProvider();
                    break;
                case "coinbase":
                    _ticker = new CoinbaseTickerProvider();
                    break;
                case "binance":
                    _ticker = new BinanceTickerProvider();
                    break;
                default:
                    throw new InvalidOperationException($"{provider} not supported.");
            }
            SetCoin(coin);
            SetCurrency(currency);
            lastPrice = 0;
        }

        public void SetCoin(string coin)
        {
            if (_ticker == null)
                return;

            if (_ticker.Coin == coin)
                return;

            _ticker.Coin = coin;

            lastPrice = 0;            
        }

        public void SetCurrency(string currency)
        {
            if (_ticker == null)
                return;

            if (_ticker.Currency == currency)
                return;

            _ticker.Currency = currency;

            lastPrice = 0;            
        }

        public void SetRefreshInterval(int value)
        {
            Logger.Info($"Refresh interval set to {value}s");
            _timer.Interval = value * 1000;            
        }

        public TickerController(string provider, string coin, string currency, int refreshInterval)
        {
            Logger.Info($"Controller initialized: {provider} - {coin} {currency}");

            this.coin = coin;
            this.currency = currency;

            SetProvider(provider);
            
            _timer = new Timer();
            _timer.Elapsed += Timer_Elapsed;            
            _timer.Start();

            SetRefreshInterval(refreshInterval);

            UpdateData();
        }

        public async void UpdateData()
        {
            await _ticker.UpdateData();

            Logger.Info($"Data Updated: {_ticker.LastPrice} {_ticker.Currency}");

            DataUpdated(this, new TickerEventArgs() {
                Provider = _ticker.Provider,
                Coin = _ticker.Coin,
                Currency = _ticker.Currency,
                LastPrice = _ticker.LastPrice,
                PreviousPrice = lastPrice == 0 ? _ticker.LastPrice : lastPrice,
                LastUpdated = _ticker.LastUpdated
            });

            lastPrice = _ticker.LastPrice;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Logger.Info($"Timer elapsed: {_timer.Interval} ms");

            UpdateData();
        }
    }    
}