using System.Windows;
using System.Windows.Controls;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Operations operations;
        public MainWindow()
        {
            InitializeComponent();
            operations = new Operations(this);

        }

        static public string FromOrTo = "";


        private void from_Checked(object sender, RoutedEventArgs e)
        {
            FromOrTo = "from";
            inputChanged(null, null);
        }
        private void to_Checked(object sender, RoutedEventArgs e)
        {
            FromOrTo = "to";
            inputChanged(null, null);
        }

        private void SB_Checked(object sender, RoutedEventArgs e)
        {
            inputChanged(null, null);
        }

        private void inputChanged(object sender, TextChangedEventArgs e)
        {
            if (operations != null)
            {
                if (!operations.huesos)
                    operations.MainOperation();
                else
                {
                    operations.HuesosOrNo();
                    if (!operations.huesos) operations.MainOperation();
                }
            }
        }

        private void input_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                var text = (TextBox)sender;
                int index = text.CaretIndex;
                if (text.Text.Length < text.MaxLength - 1)
                {
                    text.Text = text.Text.Insert(index, ",");
                    text.CaretIndex = index + 1;
                }
                e.Handled = true;
            }
            else
            {
                bool hueta = true;
                foreach (char item in e.Text)
                {
                    if (char.IsDigit(item) || item == ',')
                    {
                        hueta = false; break;
                    }
                }
                e.Handled = hueta;
            }
        }
    }

}