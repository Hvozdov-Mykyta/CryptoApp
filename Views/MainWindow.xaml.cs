using System.Windows;
using System.Windows.Controls;

namespace CryptoApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _homePage = new HomePage();
            _marketPage = new MarketPage();
            _converterPage = new ConverterPage();

            MainFrame.Content = _homePage;
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (sender as Button).Content.ToString();

            switch(buttonText) 
            {
                case "Home":
                    MainFrame.Content = _homePage; break;
                case "Market":
                    MainFrame.Content = _marketPage; break;
                case "Converter":
                    MainFrame.Content = _converterPage; break;
                default:
                    return;
            }
        }

        private HomePage _homePage;
        private MarketPage _marketPage;
        private ConverterPage _converterPage;
    }
}
