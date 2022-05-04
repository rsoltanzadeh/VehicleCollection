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
                NotifyPropertyChanged(nameof(SelectedVehicle));
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
                NotifyPropertyChanged(nameof(VIN));
                NotifyPropertyChanged(nameof(Color));
                NotifyPropertyChanged(nameof(Brand));
                NotifyPropertyChanged(nameof(ModelName));
                NotifyPropertyChanged(nameof(LicensePlate));
                NotifyPropertyChanged(nameof(Equipment));
                NotifyPropertyChanged(nameof(FuelType));
            }
        }
        public string VIN
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.VIN;
            }
            set
            {
                _modifiedVehicle.VIN = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(VIN));
            }
        }
        public string Color
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.Color;
            }
            set
            {
                _modifiedVehicle.Color = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(Color));
            }
        }
        public string Brand
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.Brand;
            }
            set
            {
                _modifiedVehicle.Brand = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(Brand));
            }
        }
        public string ModelName
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.ModelName;
            }
            set
            {
                _modifiedVehicle.ModelName = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(ModelName));
            }
        }
        public string FuelType
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.FuelType;
            }
            set
            {
                _modifiedVehicle.FuelType = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(FuelType));
            }
        }
        public string LicensePlate
        {
            get
            {
                if (_modifiedVehicle is null) return "";
                return _modifiedVehicle.LicensePlate;
            }
            set
            {
                _modifiedVehicle.LicensePlate = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(LicensePlate));
            }
        }
        public ObservableCollection<String> Equipment
        {
            get
            {
                if (_modifiedVehicle is null) return new ObservableCollection<string>();
                return _modifiedVehicle.Equipment;
            }
            set
            {
                _modifiedVehicle.Equipment = value;
                NotifyPropertyChanged(nameof(ModifiedVehicle));
                NotifyPropertyChanged(nameof(Equipment));
            }
        }

        public CommandBase DeleteVehicle { get; set; }
        public CommandBase CreateVehicle { get; set; }
        public CommandBase UpdateVehicle { get; set; }
        public CommandBase GetVehicles { get; set; }


        public VehicleViewModel()
        {
            _vehicleDB = new VehicleDatabase("https://jsonplaceholder.typicode.com/albums"); // example endpoint
            UpdateVehicle = new UpdateVehicleCommand(this, _vehicleDB);
            CreateVehicle = new CreateVehicleCommand(this, _vehicleDB);
            DeleteVehicle = new DeleteVehicleCommand(this, _vehicleDB);
            GetVehicles = new GetVehiclesCommand(this, _vehicleDB);
        }

        public void CreateNewVehicle()
        {
            SelectedVehicle = new Vehicle("XXX", "XXX", "Xxx", "Xxx", "XXX", "Xxx", new ObservableCollection<string>());
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
