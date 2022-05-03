using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCollection.Models
{	public class Vehicle
	{
		public int VIN { get; set; }
		public string LicensePlate { get; set; }
		public string ModelName { get; set; }
		public string Brand { get; set; }
		public string FuelType { get; set; }
		public string Color { get; set; }
		public List<String> Equipment { get; set; }
		public override string ToString()
		{
			return $"{ Brand } { ModelName } ({LicensePlate})";
		}

        public override bool Equals(object other)
        {
			Vehicle otherVehicle = (other as Vehicle) ?? new Vehicle();
			return this.VIN == otherVehicle.VIN;
        }

        public override int GetHashCode()
        {
			return HashCode.Combine(VIN);
        }
    }
}
