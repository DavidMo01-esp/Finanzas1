using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finanzas1.Models;
using Finanzas1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Security.RightsManagement;

namespace Finanzas1.ViewModels
{
   public class MainViewModels : INotifyPropertyChanged
    {
        private readonly MovementService _service = new MovementService();
        private decimal _balance;

        private string _newCategory;
        public string NewCategory
        {
            get => _newCategory;
            set { _newCategory = value; OnPropertyChanged(nameof(NewCategory)); }
        }

        private decimal _newQuantity;
        public decimal NewQuantity
        {
            get => _newQuantity;
            set { _newQuantity = value; OnPropertyChanged(nameof(NewQuantity)); }
        }

        public ObservableCollection<Movement> Movements { get; set; }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public MainViewModels()
        {
            _service.SaveDB();
            Movements = new ObservableCollection<Movement>(_service.TakeMovements());
            Balance = _service.GetBalance();
        }
        public void AddMovement(MovementType Type)
        {
            var nuevo = new Movement
            {
                Quantity = NewQuantity,
                Category = NewCategory,
                Date = DateTime.Now,
                Type = Type,
                Description = "Movimiento añadido"

            };

            _service.InsertMovement(nuevo);
            Movements.Insert(0, nuevo);
            Balance = _service.GetBalance();
            NewQuantity = 0;
            NewCategory = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
