using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
