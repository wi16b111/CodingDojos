using Dojo03.Commands;
using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo03.ViewModels
{
    class MainVM : Notification
    {

        // Collections

        private ObservableCollection<StockEntryVM> softwarePackages = new ObservableCollection<StockEntryVM>();
        public ObservableCollection<StockEntryVM> SoftwarePackages
        {
            get { return this.softwarePackages; }
            set { this.softwarePackages = value; }
        }

        private List<Currencies> currencyList = new List<Currencies>();
        public List<Currencies> CurrencyList
        {
            get { return currencyList; }
            set { currencyList = value; }
        }

        // Stand-alone properties

        private Currencies selectedCurrency;
        public Currencies SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                NotifyOnChange("SelectedCurrency");
                UpdatePrices();
            }
        }

        private StockEntryVM selectedPackage;
        public StockEntryVM SelectedPackage
        {
            get { return selectedPackage; }
            set
            {
                selectedPackage = value;
                NotifyOnChange("SelectedPackage");
            }
        }

        // Commands

        private Command addCommand;
        public Command AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; }
        }

        private Command editCommand;
        public Command EditCommand
        {
            get { return editCommand; }
            set { editCommand = value; }
        }

        private Command deleteCommand;
        public Command DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        // Constructors

        public MainVM()
        {
            foreach (var ccy in Enum.GetValues(typeof(Currencies)))
            {
                CurrencyList.Add((Currencies)ccy);
            }

            foreach (var stockEntry in (new SampleManager().CurrentStock.OnStock))
            {
                SoftwarePackages.Add(new StockEntryVM(stockEntry));
            }

            AddCommand = new Command(new Action(AddSoftwarePackage), new Func<bool>(CanAdd));
            EditCommand = new Command(new Action(EditSoftwarePackage), new Func<bool>(CanEdit));
            DeleteCommand = new Command(new Action(DeleteSoftwarePackage), new Func<bool>(CanDelete));
        }

        // Helper methods

        private void UpdatePrices()
        {
            foreach (var package in SoftwarePackages)
            {
                package.UpdatePrices(SelectedCurrency);
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private bool CanEdit()
        {
            if (SelectedPackage == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CanDelete()
        {
            if (SelectedPackage == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private void AddSoftwarePackage()
        {
            SoftwarePackages.Add(new StockEntryVM());
        }

        private void EditSoftwarePackage()
        {
            SoftwarePackages[SoftwarePackages.IndexOf(SelectedPackage)] = SelectedPackage;
        }

        private void DeleteSoftwarePackage()
        {
            SoftwarePackages.Remove(SelectedPackage);
        }
    }
}
