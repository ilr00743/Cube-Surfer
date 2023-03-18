using System;

namespace Money
{
    public class CoinHolder
    {
        private int _balance;
        public event Action BalanceChanged;
        private static CoinHolder _instance;
        public static CoinHolder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CoinHolder();
                return _instance;
            }
        }

        private CoinHolder(){}
        
        public void AddCoin(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _balance += value;
            BalanceChanged?.Invoke();
        }

        public void SaveBalance()
        {
            throw new NotImplementedException();
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}