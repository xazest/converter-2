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
    }

}