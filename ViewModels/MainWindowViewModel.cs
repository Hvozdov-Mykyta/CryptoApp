using CryptoApp.Commands;
using System.Windows.Input;

namespace CryptoApp.ViewModels
{
    internal class MainWindowViewModel
    {
        private ICommand _appCloser;
        public ICommand CloseApp
        {
            get
            {
                if (_appCloser == null)
                    _appCloser = new AppCloser();
                return _appCloser;
            }
            set
            {
                _appCloser = value;
            }
        }
    }
}
