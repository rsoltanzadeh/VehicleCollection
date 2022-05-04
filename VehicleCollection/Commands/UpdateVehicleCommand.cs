using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCollection.Models;
using VehicleCollection.ViewModels;

namespace VehicleCollection.Commands
{
    public class UpdateVehicleCommand : CommandBase
    {
        public UpdateVehicleCommand(VehicleViewModel vm, VehicleDatabase model) : base(vm, model) { }
        public override async void Execute(object? param)
        {
            await _vehicleDB.UpdateVehicle(_vehicleVM.SelectedVehicle, _vehicleVM.ModifiedVehicle);
        }
        public override bool CanExecute(object? param)
        {
            if (this._vehicleVM.SelectedVehicle is null) return false;

            return !this._vehicleVM.SelectedVehicle.Equals(this._vehicleVM.ModifiedVehicle) && base.CanExecute(param);
        }
    }
}
