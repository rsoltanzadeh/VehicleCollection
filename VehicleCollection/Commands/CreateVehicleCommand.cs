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
        private readonly VehicleViewModel _vehicleVM;
        private readonly VehicleDatabase _vehicleDB;
        public CreateVehicleCommand(VehicleViewModel vm, VehicleDatabase model)
        {
            _vehicleVM = vm;
            _vehicleDB = model;
            _vehicleVM.PropertyChanged += OnCanExecuteChanged;
        }
        public override void Execute(object? param)
        {
            this._vehicleVM.CreateNewVehicle();
        }
    }
}
