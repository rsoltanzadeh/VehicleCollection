using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCollection.Models;
using VehicleCollection.ViewModels;

namespace VehicleCollection.Commands
{
    public class DeleteVehicleCommand : CommandBase
    {
        private readonly VehicleViewModel _vehicleVM;
        private readonly VehicleDatabase _vehicleDB;
        public DeleteVehicleCommand(VehicleViewModel vm, VehicleDatabase model)
        {
            _vehicleVM = vm;
            _vehicleDB = model;
            _vehicleVM.PropertyChanged += OnCanExecuteChanged;
        }
        public override void Execute(object? param)
        {
            this._vehicleDB.UpdateVehicle(_vehicleVM.SelectedVehicle, _vehicleVM.ModifiedVehicle);
        }
        public override bool CanExecute(object? param)
        {
            return this._vehicleVM.SelectedVehicle is not null;
        }
    }
}
