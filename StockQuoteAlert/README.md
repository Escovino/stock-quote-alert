# Stock Price Monitor

## Overview
The Stock Price Monitor is a C# console application that tracks the stock prices of specified assets from B3 (the Brazilian Stock Exchange). It sends email alerts when the stock price falls below a defined selling price or rises above a defined buying price.

## Project Structure
```
StockPriceMonitor
├── src
│   ├── Program.cs
│   ├── Services
│   │   └── StockPriceService.cs
│   ├── Models
│   │   └── StockPrice.cs
│   └── Utils
│       └── EmailService.cs
├── StockPriceMonitor.csproj
└── README.md
```

## Setup Instructions
1. Clone the repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Restore the project dependencies using the command:
   ```
   dotnet restore
   ```

## Usage
To run the application, use the following command in the terminal:
```
dotnet run -- <AssetSymbol> <SellingPrice> <BuyingPrice>
```
Replace `<AssetSymbol>`, `<SellingPrice>`, and `<BuyingPrice>` with the desired values.

## Configuration
### SMTP Settings
To configure email notifications, update the SMTP settings in the `EmailService.cs` file. Ensure you provide valid credentials and server details.

### Alert Email Addresses
Specify the email addresses that will receive alerts in the `EmailService.cs` file.

## Example
To monitor the stock price of "PETR3" with a selling price of 25.00 and a buying price of 30.00, run:
```
dotnet run -- PETR3 25.00 30.00
```

## License
This project is licensed under the MIT License. See the LICENSE file for more details.