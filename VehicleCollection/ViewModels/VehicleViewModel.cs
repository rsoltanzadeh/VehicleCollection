using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using VehicleCollection.Models;
using System.Windows.Input;

namespace VehicleCollection.ViewModels
{
	internal class VehicleViewModel : INotifyPropertyChanged
	{
		public List<Vehicle> vehicles;
		public Vehicle currentVehicle;

		public ICommand SaveChanges;
		public ICommand DeleteVehicle;


		public VehicleViewModel()
		{
			vehicles = new List<Vehicle>();
		}

	}
}
