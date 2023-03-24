using Money;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _collectedCoinsValue;
        private void Start()
        {
            _collectedCoinsValue.text = "Coins: " + CoinHolder.Instance.GetBalance();
        }

        private void OnEnable()
        {
            CoinHolder.Instance.BalanceChanged += OnBalanceChanged;
        }
        
        private void OnDisable()
        {
            CoinHolder.Instance.BalanceChanged -= OnBalanceChanged;
        }
        
        private void OnBalanceChanged()
        {
            _collectedCoinsValue.text = "Coins: " + CoinHolder.Instance.GetBalance();
        }
    }
}