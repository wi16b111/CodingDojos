using Dojo04.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Dojo04.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        // ------------------------------------

        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        private int ssn;
        public int Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        private DateTime birthdate;
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
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

        private void Init()
        {
            Dudes.Add(new Dude("one", "one", 1, new DateTime()));
            Dudes.Add(new Dude("two", "two", 2, new DateTime()));
            Dudes.Add(new Dude("three", "three", 3, new DateTime()));
        }

        private void Add()
        {
            MessageBox.Show("Add btn pressed");
        }

        private void Save()
        {
            MessageBox.Show("Save btn pressed");
        }

        private void Load()
        {
            MessageBox.Show("Load btn pressed");
        }

        private bool CanAdd()
        {
            return true;
        }

        private bool CanSave()
        {
            return true;
        }

        private bool CanLoad()
        {
            return true;
        }

        // -------------------------------------

        public MainViewModel()
        {
            this.Dudes = new ObservableCollection<Dude>();
            Init();

            this.ButtonAdd = new RelayCommand(Add, CanAdd);
            this.ButtonSave = new RelayCommand(Save, CanSave);
            this.ButtonAdd = new RelayCommand(Load, CanLoad);
        }
    }
}