using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VehicleCollection.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VehicleCollection.Commands;

namespace VehicleCollection.ViewModels
{
    public class VehicleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly VehicleDatabase _vehicleDB;
        private Vehicle _selectedVehicle;
        private Vehicle _modifiedVehicle;

        public ObservableCollection<Vehicle> Vehicles
        {
            get; set;
        }
        public Vehicle SelectedVehicle
        {
            get
            {
                return _selectedVehicle;
            }
            set
            {
                if (value is null) return;

                _selectedVehicle = value;

                ModifiedVehicle = new Vehicle(
                    _selectedVehicle.VIN,
                    _selectedVehicle.LicensePlate,
                    _selectedVehicle.ModelName,
                    _selectedVehicle.Brand,
                    _selectedVehicle.FuelType,
                    _selectedVehicle.Color,
                    _selectedVehicle.Equipment
                );
            }
        }
        public Vehicle ModifiedVehicle
        {
            get
            {
                return _modifiedVehicle;
            }
            set
            {
                _modifiedVehicle = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
            }
        }
        public string VIN
        {
            get
            {
                return _modifiedVehicle.VIN;
            }
            set
            {
                _modifiedVehicle.VIN = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
            }
        }

        public CommandBase DeleteVehicle;
        public CommandBase CreateVehicle;
        public CommandBase UpdateVehicle;


        public VehicleViewModel()
        {
            this._vehicleDB = new VehicleDatabase("http://hardcodedendpoint");
            this.Vehicles = this._vehicleDB.GetVehicles();
            this.UpdateVehicle = new UpdateVehicleCommand(this, this._vehicleDB);
            this.CreateVehicle = new CreateVehicleCommand(this, this._vehicleDB);
            this.DeleteVehicle = new DeleteVehicleCommand(this, this._vehicleDB);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
