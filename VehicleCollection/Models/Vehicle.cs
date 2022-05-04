using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCollection.Models
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public string Brand { get; set; }
        public string FuelType { get; set; }
        public string Color { get; set; }
        public ObservableCollection<String> Equipment { get; set; }

        public string Description { get; set; }
        public override string ToString()
        {
            return $"{ Brand } { ModelName } ({LicensePlate}) {VIN}";
        }
        
        public Vehicle(string VIN, string LicensePlate, string ModelName, string Brand, string FuelType, string Color, ObservableCollection<String> Equipment)
        {
            this.VIN = VIN;
            this.LicensePlate = LicensePlate;
            this.ModelName = ModelName;
            this.Brand = Brand;
            this.FuelType = FuelType;
            this.Color = Color;
            this.Equipment = Equipment;
            this.Description = this.ToString();
        }
        public override bool Equals(object? other)
        {
            Vehicle otherVehicle = (other as Vehicle) ?? new Vehicle("", "", "", "", "", "", new ObservableCollection<string>());
            return this.VIN == otherVehicle.VIN
                && this.LicensePlate == otherVehicle.LicensePlate
                && this.ModelName == otherVehicle.ModelName
                && this.Brand == otherVehicle.Brand
                && this.FuelType == otherVehicle.FuelType
                && this.Color == otherVehicle.Color
                && new HashSet<String>(this.Equipment).SetEquals(new HashSet<String>(otherVehicle.Equipment));
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(this.VIN);
            hash.Add(this.LicensePlate);
            hash.Add(this.ModelName);
            hash.Add(this.Brand);
            hash.Add(this.FuelType);
            hash.Add(this.Color);
            hash.Add(this.Equipment.GetHashCode());
            return hash.ToHashCode();
        }
    }
}
