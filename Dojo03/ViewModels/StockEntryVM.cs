using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo03.ViewModels
{
    class StockEntryVM : Notification
    {
        private string name;
        private double salesPrice;
        private double salesPriceEur;
        private double purchasePrice;
        private double purchasePriceEur;
        private int amount;
        private string softwareGroup;
        private int stockCategory;
        
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

        public int StockCategory
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
            if (this.Amount < 10) { this.StockCategory = 1; }
            else if (this.Amount >= 10 && this.Amount <= 20) { this.StockCategory = 2; }
            else { this.StockCategory = 3; }
        }
    }
}
