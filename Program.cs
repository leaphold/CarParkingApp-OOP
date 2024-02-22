using System.Linq.Expressions;

namespace upg2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            int choice2 = 0;
            int choice3 = 0;
            int choice4 = 0;
            bool programRunning = true;

            // Create vehicle objects
            Car car = new Car("Ford", "Fiesta", 45000, 5, "Diesel", "BE - license");
            Car car1 = new Car("Volvo", "240GL", 200, 5, "Petrol", "BE - license");
            Car car2 = new Car("Mazda", "Coral", 50300, 5, "Petrol", "BE-license");
            Truck truck = new Truck("Ford", "Explorer", 150000, "CE-license", "Diesel", 130, 20);
            Truck truck1 = new Truck("Volvo", "Gigant", 150500, "CE-license", "Diesel", 150, 35);
            Motorcycle bike = new Motorcycle("Yamaha", "x300", 40000, "helmet and some balls", "Petrol", 320);
            Motorcycle bike1 = new Motorcycle("Suzuki", "Mobilia", 3000, "helmet and some balls", "Petrol", 200);

           
            //Program runs as long as programRunning=true
            while (programRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Vehicle Shop & Parking Service!\n\nChoose service from the menu below:\n");

                Console.WriteLine("1.Display available vehicles\n2.Park vehicle\n3.Display license needed to drive\n4.Shutdown");
                //Tryparse to catch any letters instead of numbers
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out choice);
                //main menu to choose service
                switch (choice)
                {
                    case 1:// List Vehicles avaliable
                        Console.WriteLine("1.Cars\n2.Trucks\n3.Motorcycles");
                        string input4 = Console.ReadLine();
                        bool result4 = int.TryParse(input4, out choice4);
                        switch (choice4)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("***Current Available Cars: \n");

                                var availableCars = Vehicle.VehiclesList.OfType<Car>();

                                foreach (Car currentCar in availableCars)
                                {
                                    Console.WriteLine(currentCar.Describe() + "\n");
                                }

                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("***Current Available Trucks: \n");
                                var availableTrucks = Vehicle.VehiclesList.OfType<Truck>();

                                foreach (Truck currentTruck in availableTrucks)
                                {
                                    Console.WriteLine(currentTruck.Describe() + "\n");
                                }

                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("***Current Available Motorcycles: \n");
                                
                                var availableMotorcycles = Vehicle.VehiclesList.OfType<Motorcycle>();

                                foreach (Motorcycle currentMotorcycle in availableMotorcycles)
                                {
                                    Console.WriteLine(currentMotorcycle.Describe() + "\n");
                                }

                                break;

                            default:
                                Console.WriteLine("Invalid entry, hit enter to try again");
                                Console.ReadKey();

                                break;
                        }


                        Console.WriteLine("\n---Press enter to go back to the main menu---");

                        Console.ReadKey();
                        break;
                    //Park vehicle service - returns a number which is assigned to parking spaces
                    case 2:
                        Console.Clear();
                        Console.WriteLine("What type of vehicle would you like to park?\n1.Car\n2.Truck\n3.Bike");
                        string input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out choice2);

                        switch (choice2)
                        {
                            case 1:
                                car.ParkVehicle();
                                Console.WriteLine("\n---Press enter to go back to the main menu---");
                                Console.ReadKey();
                                break;

                            case 2:
                                truck.ParkVehicle();
                                Console.WriteLine("\n---Press enter to go back to the main menu---");
                                Console.ReadKey();
                                break;

                            case 3:
                                bike.ParkVehicle();
                                Console.WriteLine("\n---Press enter to go back to the main menu---");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("Invalid entry, hit enter to try again");
                                Console.ReadKey();

                                break;
                        }
                        break;
                    //Returns info on what license is needed to dive a certain vehicle
                    case 3:
                        Console.WriteLine("What type of vehicle would you like to see information on?\n1.Car\n2.Truck\n3.Bike");
                        string input3 = Console.ReadLine();
                        bool result3 = int.TryParse(input3, out choice3);

                        switch (choice3)
                        {
                            case 1:
                                Console.WriteLine("\nYou need a " + car.NeedToDriveVehicle());
                                break;

                            case 2:
                                Console.WriteLine("\nYou need a " + truck.NeedToDriveVehicle());
                                break;

                            case 3:
                                Console.WriteLine("\nYou need a " + bike.NeedToDriveVehicle() + " to ride our bikes");
                                break;

                            default:
                                Console.WriteLine("Something went wrong, try again");
                                break;
                        }

                        Console.WriteLine("\n---Press enter to go back to the main menu---");
                        Console.ReadKey();
                        break;
                    //Shut down Program: programRunning = false;
                    case 4:
                        Console.WriteLine("\n---Shutting Down program---\n\n                           Have a nice day!\n\n ");
                        programRunning = false;
                        break;
                    //Catch any misspellings or invalid input in main menu
                    default:
                        Console.WriteLine("Invalid entry, hit enter to try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
