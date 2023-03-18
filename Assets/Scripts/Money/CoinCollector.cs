using System;
using UnityEngine;

namespace Money
{
    public class CoinCollector : MonoBehaviour
    {
        [SerializeField] private int _value;

        public void Collect()
        {
            CoinHolder.Instance.AddCoin(_value);
            Debug.Log(CoinHolder.Instance.GetBalance());
        }
    }
}