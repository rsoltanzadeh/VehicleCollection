using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCollection.Models
{
    public class VehicleDatabase
    {
        private string _apiEndpoint;

        public ObservableCollection<Vehicle> GetVehicles()
        {
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
            vehicles.Add(new Vehicle("43817", "ABC123", "S70", "Volvo", "Bensin", "Vit", new HashSet<string>()));
            vehicles.Add(new Vehicle("14145", "ZXC987", "Civic Sport Plus", "Honda", "Bensin", "Metallic Svart", new HashSet<string>()));
            return vehicles;
        }

        public Boolean UpdateVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            return true;
        }

        public Boolean DeleteVehicle(Vehicle v)
        {
            return true;
        }

        public Boolean CreateVehicle(Vehicle v)
        {
            return true;
        }

        public VehicleDatabase(string ApiEndpoint)
        {
            this._apiEndpoint = ApiEndpoint;
        }
    }
}
