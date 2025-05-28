
namespace WpfApp1
{
    class Exchange
    {
        static public readonly Dictionary<string, float> Rates = new Dictionary<string, float>
        {
            {"usdbuy", 16.3000f},
            {"usdsell", 16.3500f},

            {"eurbuy",  17.9000f},
            {"eursell",  18.8000f},

            {"rubbuy",  0.1840f},
            {"rubsell",  0.2000f},

            {"uahbuy",  0.3400f},
            {"uahsell",  0.4000f},

            {"mdlbuy",  0.9200f},
            {"mdlsell",  1.0000f}
        };
        static public float GetRates(string currency) => Rates.TryGetValue(currency, out float rate) ? rate : 0f;
    }
}
