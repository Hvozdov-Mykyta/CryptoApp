# CryptoApp

This is multi page application created on WPF with MVVM pattern using

There is navigation panel on left side and Frame which stores opened page. Also there is close button and removed standard title bar


Aviable next pages: Home, Coins, Converter and CoinPage(last not aviable on navigation panel)

Home:
- Displays first 10 currencies that are returned from api.coincap.io/v2/assets
- Button 'Refresh' sends rest-request to API and updates information about currencies
- Button 'View Selected' becomes active when one currency is selected and opens page with detailed information about currency and markets where it is for sale
    
Coins:
- Same to 'Hone' but displays all currencies from API and has search bar to find currency by name or symbol
- Also has 'Refresh' and 'View Selected' buttons 
    
Converter:
- Has 2 comboBoxes with all coins, 2 TextBlocks to show selected coin price and 2 TextBoxes for count of each coin
- There is 'Refresh' and 'Convert' buttons
    
CoinPage:
- Displays full information about selected currency and markets where it can be bought
    

I tried to order project files by using folders, MVVM and SOLID patterns
