using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleCollection.Models;
using VehicleCollection.ViewModels;

namespace VehicleCollection.Commands
{
    public class CreateVehicleCommand : CommandBase
    {
        public CreateVehicleCommand(VehicleViewModel vm, VehicleDatabase model) : base(vm, model) { }
        public override void Execute(object? param)
        {
            this._vehicleVM.CreateNewVehicle();
        }
    }
}
