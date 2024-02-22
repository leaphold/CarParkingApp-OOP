using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace upg2
{   //Base class with two interfaces
    public class Vehicle : IDriveable, IParkable
    {   //Empty list to store vehicles
        private static List<Vehicle> vehiclesList = new List<Vehicle>();
        private static int count = 0;

        public static List<Vehicle> VehiclesList
        {
            get { return vehiclesList; }
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string LicenseToDrive { get; set; }
        public int Parkingspot { get; set; }

        // Constructor
        public Vehicle(string brand, string model, int price, string licenseToDrive)
        {
            Brand = brand;
            Model = model;
            Price = price;
            LicenseToDrive = licenseToDrive;
            Parkingspot = 0;
            vehiclesList.Add(this); // Adds created vehicle to list
        }
        //Describe method default print of an undefined vehicle
        public virtual string Describe()
        {
            return $"The {Brand} of the model {Model} costs {Price} ";
        }
        //Method from interface IDrivable
        public string NeedToDriveVehicle()
        {
            return LicenseToDrive;
        }
        //Method from IParkable interface - returns parkingspot number
        public int ParkingspotNumber()
        {
            count++;
            return Parkingspot + count;
        }
        //Method from IParkable interface - generates message to user about what spot to use
        public void ParkVehicle()
        {
            Console.WriteLine("Vehicle is being parked at parkingspot " + ParkingspotNumber());
        }
    }
    //Car Class - Subclass to Vehicle
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public string FuelType { get; set; }

        public Car(string brand, string model, int price, int numberOfDoors, string fuelType, string licenseToDrive)
            : base(brand, model, price, licenseToDrive)
        {
            NumberOfDoors = numberOfDoors;
            FuelType = fuelType;
        }
        //Method to describe cars - Overrides Base method 
        public override string Describe()
        {
            return $"Brand: {Brand}\nModel: {Model} \nPrice: {Price}$\nDoors: {NumberOfDoors}\nFuel Type:{FuelType}";
        }
    }

    //Truck Class - Subclass to Vehicle
    class Truck : Vehicle
    {
        public int TowingCapacity { get; set; }
        public int CargoCapacity { get; set; }
        public string FuelType { get; set; }

        
        public Truck(string brand, string model, int price, string licenseToDrive, string fuelType, int towingCapacity, int cargoCapacity)
            : base(brand, model, price, licenseToDrive)
        {
            TowingCapacity = towingCapacity;
            CargoCapacity = cargoCapacity;
            FuelType = fuelType;
        }
        
        //Method to describe Trucks - Overrides Base method 
        public override string Describe()
        {
            return $"\nBrand: {Brand}\nModel: {Model} \nPrice: {Price}$\nTowing Capacity:{TowingCapacity} Tons\nCargo Capacity: {CargoCapacity}\nFuel Type:{FuelType}";
        }
    }

    //Motorcycle Class - Subclass to Vehicle
    class Motorcycle : Vehicle
    {
        public string FuelType { get; set; }
        public int MaxSpeed { get; set; }

        public Motorcycle(string brand, string model, int price, string licenseToDrive, string fuelType, int maxSpeed)
            : base(brand, model, price, licenseToDrive)
        {
            FuelType = fuelType;
            MaxSpeed = maxSpeed;
        }

        //Method to describe Motorcycles - Overrides Base method 
        public override string Describe()
        {
            return $"Brand: {Brand}\nModel: {Model} \nPrice: {Price}$\nMax Speed:{MaxSpeed} Km/h \nFuel Type:{FuelType}";
        }
    }
}




