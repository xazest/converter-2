
namespace WpfApp1
{
    class Exchange
    {
        static public readonly Dictionary<string, float> Rates = new Dictionary<string, float>
        {//28.05.2025
            {"usdbuy", 16.3000f},
            {"usdsell", 16.3500f},

            {"eurbuy",  18.1000f},
            {"eursell",  18.8500f},

            {"rubbuy",  0.1860f},
            {"rubsell",  0.2010f},

            {"uahbuy",  0.3400f},
            {"uahsell",  0.4000f},

            {"mdlbuy",  0.9000f},
            {"mdlsell",  0.9800f}
        };
        static public float GetRates(string currency) => Rates.TryGetValue(currency, out float rate) ? rate : 0f;
    }
}
