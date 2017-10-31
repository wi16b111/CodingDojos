using Dojo04.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace Dojo04.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        // ------------------------------------

        private static string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Files"));

        // ------------------------------------

        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; RaisePropertyChanged(); }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; RaisePropertyChanged(); }
        }

        private int ssn;
        public int Ssn
        {
            get { return ssn; }
            set { ssn = value; RaisePropertyChanged(); }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Dude> dudes;
        public ObservableCollection<Dude> Dudes
        {
            get { return this.dudes; }
            set { this.dudes = value; }
        }

        private RelayCommand buttonAdd;
        public RelayCommand ButtonAdd
        {
            get { return buttonAdd; }
            set { buttonAdd = value; }
        }

        private RelayCommand buttonSave;
        public RelayCommand ButtonSave
        {
            get { return buttonSave; }
            set { buttonSave = value; }
        }

        private RelayCommand buttonLoad;
        public RelayCommand ButtonLoad
        {
            get { return buttonLoad; }
            set { buttonLoad = value; }
        }

        // -------------------------------------
        
        private void Add()
        {
            Dudes.Add(new Dude(Firstname, Lastname, Ssn, Birthdate));
            ReinitializeProperties();
        }

        private void Save()
        {
            MessageBox.Show("Save btn was pressed");
        }

        private void Load()
        {
            MessageBox.Show("Load btn pressed");
        }

        private bool CanAdd()
        {
            return Lastname.Length >= 2;
        }

        private bool CanSave()
        {
            return Dudes.Count > 0;
        }

        private bool CanLoad()
        {
            return File.Exists(Path.Combine(path, "dudes.csv"));
        }

        private void ReinitializeProperties()
        {
            Firstname = "";
            Lastname = "";
            Ssn = 00000;
            Birthdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        }

        // -------------------------------------

        public MainViewModel()
        {
            ReinitializeProperties();

            this.Dudes = new ObservableCollection<Dude>();

            this.ButtonAdd = new RelayCommand(Add, CanAdd);
            this.ButtonSave = new RelayCommand(Save, CanSave);
            this.ButtonLoad = new RelayCommand(Load, CanLoad);
        }
    }
}