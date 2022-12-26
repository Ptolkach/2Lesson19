using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task1.Models;

namespace Task1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int r_circ;

        public int R_circ
        {
            get => r_circ;
            set
            {
                r_circ = value;
                OnPropertyChanged();
            }
        }


        private double l_circ;

        public double L_circ
        {
            get => l_circ;
            set
            {
                l_circ = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }

        private void OnAddCommandExecute(object p)
        {
             L_circ = Result_L.L_length(R_circ);
        }

        private bool CanAddCommandExecuted(object p)
        {
            if (R_circ != 0)
                return true;
            else
            {
                return false;
            }
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}
