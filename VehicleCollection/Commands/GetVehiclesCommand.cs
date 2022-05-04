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
    public class GetVehiclesCommand : CommandBase
    {
        public GetVehiclesCommand(VehicleViewModel vm, VehicleDatabase model) : base(vm, model) { }
        public override async void Execute(object? param)
        {
            _vehicleVM.Vehicles = await this._vehicleDB.GetVehicles();
        }
        public override bool CanExecute(object? param)
        {
            return true;
        }
    }
}
