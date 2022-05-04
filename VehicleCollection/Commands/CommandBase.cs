using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VehicleCollection.Models;
using VehicleCollection.ViewModels;

namespace VehicleCollection.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected readonly VehicleViewModel _vehicleVM;
        protected readonly VehicleDatabase _vehicleDB;

        public event EventHandler? CanExecuteChanged;
        public CommandBase(VehicleViewModel vm, VehicleDatabase model)
        {
            _vehicleVM = vm;
            _vehicleDB = model;
            _vehicleVM.PropertyChanged += OnCanExecuteChanged;
        }

        public virtual bool CanExecute(object? param)
        {
            return this._vehicleVM.Vehicles is not null;
        }
        public abstract void Execute(object? param);

        protected void OnCanExecuteChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
