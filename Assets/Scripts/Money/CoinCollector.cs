namespace Money
{
    public class CoinCollector
    {
        private readonly int _value = 3;

        public void Collect()
        {
            CoinHolder.Instance.AddCoin(_value);
        }
    }
}