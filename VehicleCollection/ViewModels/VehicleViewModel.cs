using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VehicleCollection.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace VehicleCollection.ViewModels
{
	internal class VehicleViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private VehicleDatabase _vehicleDB;

		public ObservableCollection<Vehicle> Vehicles;
		public Vehicle SelectedVehicle
        {
			get
            {
				return SelectedVehicle;
            }
			set
            {
				ModifiedVehicle = new Vehicle(
					SelectedVehicle.VIN, 
					SelectedVehicle.LicensePlate, 
					SelectedVehicle.ModelName, 
					SelectedVehicle.Brand, 
					SelectedVehicle.FuelType, 
					SelectedVehicle.Color, 
					SelectedVehicle.Equipment
				);
            }
        }
		public Vehicle ModifiedVehicle;

		public string VIN
        {
			get
            {
				return ModifiedVehicle.VIN;
            }
			set
            {
				ModifiedVehicle.VIN = value;
				NotifyPropertyChanged(nameof(VIN));
            }
        }
		public string LicensePlate
		{
			get
			{
				return ModifiedVehicle.LicensePlate;
			}
			set
			{
				ModifiedVehicle.LicensePlate = value;
				NotifyPropertyChanged(nameof(LicensePlate));
			}
		}
		public string ModelName
		{
			get
			{
				return ModifiedVehicle.ModelName;
			}
			set
			{
				ModifiedVehicle.ModelName = value;
				NotifyPropertyChanged(nameof(ModelName));
			}
		}

		public string FuelType
		{
			get
			{
				return ModifiedVehicle.FuelType;
			}
			set
			{
				ModifiedVehicle.FuelType = value;
				NotifyPropertyChanged(nameof(FuelType));
			}
		}

		public ICommand SelectVehicle;
		public ICommand DeleteVehicle;
		public ICommand CreateVehicle;
		public ICommand Save;


		public VehicleViewModel()
		{
			this._vehicleDB = new VehicleDatabase("http://hardcodedendpoint");
			this.Vehicles = this._vehicleDB.GetVehicles();
		}

		private void NotifyPropertyChanged(string propertyName)
        {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}
