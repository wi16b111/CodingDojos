using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace Dojo03.ViewModels
{
    class StockEntryVM : Notification, IValueConverter
    {
        private string name;
        private double salesPrice;
        private double salesPriceEur;
        private double purchasePrice;
        private double purchasePriceEur;
        private int amount;
        private string softwareGroup;
        private SolidColorBrush stockCategory;
        
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                NotifyOnChange("Name");
            }
        }

        public double SalesPrice
        {
            get { return this.salesPrice; }
            set
            {
                this.salesPrice = value;
                NotifyOnChange("SalesPrice");
            }
        }

        public double PurchasePrice
        {
            get { return this.purchasePrice; }
            set
            {
                this.purchasePrice = value;
                NotifyOnChange("PurchasePrice");
            }
        }

        public string SoftwareGroup
        {
            get { return this.softwareGroup; }
            set
            {
                this.softwareGroup = value;
                NotifyOnChange("SoftwareGroup");
            }
        }

        public int Amount
        {
            get { return this.amount; }
            set
            {
                this.amount = value;
                NotifyOnChange("Amount");
            }
        }

        public SolidColorBrush StockCategory
        {
            get { return this.stockCategory; }
            set
            {
                this.stockCategory = value;
                NotifyOnChange("StockCategory");
            }
        }

        public StockEntryVM()
        {
            this.Name = null;
            this.SalesPrice = 0;
            this.PurchasePrice = 0;
            this.salesPriceEur = 0;
            this.purchasePriceEur = 0;
            this.Amount = 0;
            this.softwareGroup = null;
            UpdateStockCategory();
        }

        public StockEntryVM(StockEntry baseEntry)
        {
            this.Name = baseEntry.SoftwarePackage.Name;
            this.SalesPrice = baseEntry.SoftwarePackage.SalesPrice;
            this.salesPriceEur = baseEntry.SoftwarePackage.SalesPrice;
            this.PurchasePrice = baseEntry.SoftwarePackage.PurchasePrice;
            this.purchasePriceEur = baseEntry.SoftwarePackage.PurchasePrice;
            this.Amount = baseEntry.Amount;
            
            foreach (var group in (new SampleManager().AvailableGroups)) {
                foreach (var soft in group.Software) {
                    if (soft.Name == baseEntry.SoftwarePackage.Name) { this.softwareGroup = group.Name; }
                }
            }

            UpdateStockCategory();
        }

        public void UpdatePrices(Currencies ccy)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(ccy, this.salesPriceEur);
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(ccy, this.purchasePriceEur);
        }

        public void UpdateStockCategory()
        {
            this.StockCategory = (SolidColorBrush)Convert(this.Amount, null, null, null);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value < 10) { return new SolidColorBrush(Colors.Red); }
            else if ((int)value >= 10 && (int)value <= 20) { return new SolidColorBrush(Colors.Orange); }
            else { return new SolidColorBrush(Colors.Green); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
