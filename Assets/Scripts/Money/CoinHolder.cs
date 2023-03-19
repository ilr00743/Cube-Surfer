using System;
using UnityEngine;

namespace Money
{
    public class CoinHolder
    {
        private int _balance = PlayerPrefs.GetInt("Money");
        public event Action BalanceChanged;
        private static readonly CoinHolder _instance = new CoinHolder();
        public static CoinHolder Instance => _instance;

        private CoinHolder(){}
        
        public void AddCoin(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _balance += value;
            BalanceChanged?.Invoke();
            SaveBalance();
        }

        private void SaveBalance()
        {
            PlayerPrefs.SetInt("Money", _balance);
        }

        public int GetBalance()
        {
            return _balance;
        }
    }
}