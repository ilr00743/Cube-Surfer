using System;
using UnityEngine;

namespace Money
{
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private int _value;
        private CoinHolder _coinHolder;

        public void Collect()
        {
            CoinHolder.Instance.AddCoin(_value);
        }
    }
}