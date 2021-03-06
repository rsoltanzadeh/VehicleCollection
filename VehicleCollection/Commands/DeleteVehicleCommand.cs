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
        public DeleteVehicleCommand(VehicleViewModel vm, VehicleDatabase model) : base(vm, model) { }
        public override async void Execute(object? param)
        {
            await this._vehicleDB.DeleteVehicle(_vehicleVM.SelectedVehicle);
        }
        public override bool CanExecute(object? param)
        {
            return this._vehicleVM.SelectedVehicle is not null && base.CanExecute(param);
        }
    }
}
