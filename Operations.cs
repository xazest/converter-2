using System.Windows.Controls;

namespace WpfApp1
{
    class Operations
    {
        private MainWindow _mainWindow;

        public Operations(MainWindow mainWindow) { _mainWindow = mainWindow; }


        float amountOfMoney;
        float result;
        string action = "";
        public bool huesos = true;

        public void MainOperation()
        {
            if (float.TryParse(_mainWindow.inputTextBox.Text, out amountOfMoney) && amountOfMoney >= 0)
            {
                Calculation();
                _mainWindow.outputTextBox.Text = $"{result}";
            }
            else
            {
                _mainWindow.outputTextBox.Text = "пошел нахуй";
            }

        }
        void Calculation()
        {
            FindCurrency();
            SellOrBuy();
            if (MainWindow.FromOrTo == "from")
            {
                result = amountOfMoney * Exchange.GetRates(action);
                result = (float)Math.Round(result, 2);
            }
            else if (MainWindow.FromOrTo == "to")
            {
                result = amountOfMoney / Exchange.GetRates(action);
                result = (float)Math.Round(result, 2);
            }
            action = "";
        }

        void FindCurrency()
        {
            if (_mainWindow.fromUSD.IsChecked == true || _mainWindow.toUSD.IsChecked == true) { action += "usd"; }
            else if (_mainWindow.fromEUR.IsChecked == true || _mainWindow.toEUR.IsChecked == true) { action += "eur"; }
            else if (_mainWindow.fromRUB.IsChecked == true || _mainWindow.toRUB.IsChecked == true) { action += "rub"; }
            else if (_mainWindow.fromUAH.IsChecked == true || _mainWindow.toUAH.IsChecked == true) { action += "uah"; }
            else if (_mainWindow.fromMDL.IsChecked == true || _mainWindow.toMDL.IsChecked == true) { action += "mdl"; }
        }
        void SellOrBuy()
        {
            if (_mainWindow.SellButton.IsChecked == true)
            {
                action += "buy";
            }
            else if (_mainWindow.BuyButton.IsChecked == true)
            {
                action += "sell";
            }
        }

        public void HuesosOrNo()
        {
            bool huesos1 = true;
            bool huesos2 = true;
            foreach (var item1 in _mainWindow.ConversionPanel.Children)
            {
                if (item1 is RadioButton button1)
                    if (button1.IsChecked == true)
                    { huesos1 = false; break; }
            }
            foreach (var item2 in _mainWindow.SellOrBuyPanel.Children)
            {
                if (item2 is RadioButton button2)
                    if (button2.IsChecked == true)
                    { huesos2 = false; break; }
            }
            if (!huesos1 && !huesos2) huesos = false;
        }
    }
}
