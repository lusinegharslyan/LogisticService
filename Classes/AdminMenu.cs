using LogisticService.Interfaces;
using LogisticService.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace LogisticService.Classes
{
    public class AdminMenu : Menu
    {

        public void ShowDataTypes()
        {
            Console.WriteLine("1-Directions | 2-CarTypes | 3-CarModels | 4-Containers | 5-CrashedCars | 0-Exit");
            Console.Write("Choose data: ");
        }

        public void ShowDataOperations()
        {
            Console.WriteLine("1-Add | 2-Delete | 3-Update | 4-FindById | 5-GetAll | 0-Exit");
            Console.Write("Choose operation: ");
        }

      
        public override void Start()
        {
            while (true)
            {
                ShowDataTypes();
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("Exit AdminMenu");
                    break;
                }
                switch (choice)
                {
                    case 1:
                        showDirectionsAdminMenu(new DirectionRepository());
                        break;
                    case 2:
                        showCaTypesAdminMenu(new CarTypeRepository());
                        break;
                    case 3:
                        showCarModelsAdminMenu(new CarModelRepository());
                        break;
                    case 4:
                        showContainersAdminMenu(new ContainerRepository());
                        break;
                    case 5:
                        showCrashedCarsAdminMenu(new CrashedCarRepository());
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }


        private void showDirectionsAdminMenu(IRepository<Direction> directionRepository)
        {
             void PrintDetails(Direction direction)
            {
                Console.WriteLine($"Id: {direction.Id} | From: {direction.From} | To: {direction.To} | Distance: {direction.Distance} | Price: {direction.Price}");
            }
            ShowDataOperations();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Type new Direction details");
                        Console.Write("From: ");
                        string from = Console.ReadLine();
                        Console.Write("To: ");
                        string to = Console.ReadLine();
                        Console.Write("Distance: ");
                        float distance = float.Parse(Console.ReadLine());
                        Console.Write("Price: ");
                        float price = float.Parse(Console.ReadLine());
                        Direction direction = new Direction(from, to, distance, price);
                        directionRepository.Add(direction);
                        Console.WriteLine("Direction added to Directions ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting direction");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        directionRepository.Delete(id);
                        Console.WriteLine("Direction deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new Direction details");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("From: ");
                        string from = Console.ReadLine();
                        Console.Write("To: ");
                        string to = Console.ReadLine();
                        Console.Write("Distance: ");
                        float distance = float.Parse(Console.ReadLine());
                        Console.Write("Price: ");
                        float price = float.Parse(Console.ReadLine());
                        Direction direction = new Direction(from, to, distance, price);
                        directionRepository.Update(direction, id);
                        Console.WriteLine("Direction updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find Direction");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var direction = directionRepository.FindById(id);
                        Console.WriteLine("Founded Direction details");
                        PrintDetails(direction);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All Directions");

                        directionRepository.GetAll().ForEach(direction => PrintDetails(direction));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }


        private void showCaTypesAdminMenu(IRepository<CarType> carTypeRepository)
        {
            void PrintDetails(CarType carType)
            {
                Console.WriteLine($"Id: {carType.Id} | Type: {carType.Type} | Coefficient: {carType.Coefficient} ");
            }
            ShowDataOperations();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Type new CarType details");
                        Console.Write("Type: ");
                        string type = Console.ReadLine();
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());
                        CarType carType = new CarType(type,coefficient);
                        carTypeRepository.Add(carType);
                        Console.WriteLine("CarType added to CarTypes ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting carType");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        carTypeRepository.Delete(id);
                        Console.WriteLine("CarType deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new CarType details");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Type: ");
                        string type = Console.ReadLine();
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());

                        CarType carType = new CarType(type, coefficient);
                        carTypeRepository.Update(carType, id);
                        Console.WriteLine("CarType updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find CarType");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var carType = carTypeRepository.FindById(id);
                        Console.WriteLine("Founded CarType details");
                        PrintDetails(carType);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CarTypes");

                        carTypeRepository.GetAll().ForEach(carType => PrintDetails(carType));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }



        private void showCarModelsAdminMenu(IRepository<CarModel> carModelRepository)
        {
            void PrintDetails(CarModel carModel)
            {
                Console.WriteLine($"Id: {carModel.Id} | Type: {carModel.Model} | Coefficient: {carModel.Coefficient} ");
            }
            ShowDataOperations();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Type new CarModel details");
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());
                        CarModel carModel = new CarModel(model, coefficient);
                        carModelRepository.Add(carModel);
                        Console.WriteLine("CarModel added to CarModels ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting carModel");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        carModelRepository.Delete(id);
                        Console.WriteLine("CarModel deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new CarModel details");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Type: ");
                        string model = Console.ReadLine();
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());

                        CarModel carModel = new CarModel(model, coefficient);
                        carModelRepository.Update(carModel, id);
                        Console.WriteLine("CarModel updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find CarModel");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var carModel = carModelRepository.FindById(id);
                        Console.WriteLine("Founded CarModel details");
                        PrintDetails(carModel);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CarModels");

                        carModelRepository.GetAll().ForEach(carModel => PrintDetails(carModel));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }




        private void showContainersAdminMenu(IRepository<Container> containerRepository)
        {
            void PrintDetails(Container container)
            {
                Console.WriteLine($"Id: {container.Id} | IsOpen: {container.IsOpen} | Coefficient: {container.Coefficient} ");
            }
            ShowDataOperations();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Type new Container details");
                        Console.Write("IsOpen: ");
                        bool isOpen =bool.Parse(Console.ReadLine());
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());
                        Container container = new Container(isOpen, coefficient);
                        containerRepository.Add(container);
                        Console.WriteLine("Container added to Containers ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting Container");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        containerRepository.Delete(id);
                        Console.WriteLine("Container deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new Container details");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("IsOpen: ");
                        bool isOpen = bool.Parse(Console.ReadLine());
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());

                        Container container = new Container(isOpen, coefficient);
                        containerRepository.Update(container, id);
                        Console.WriteLine("Container updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find Container");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var container = containerRepository.FindById(id);
                        Console.WriteLine("Founded container details");
                        PrintDetails(container);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All Containers");

                        containerRepository.GetAll().ForEach(container => PrintDetails(container));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }



        private void showCrashedCarsAdminMenu(IRepository<CrashedCar> crashedCarRepository)
        {
            void PrintDetails(CrashedCar crashedCar)
            {
                Console.WriteLine($"Id: {crashedCar.Id} | IsCrashed: {crashedCar.IsCrashed} | Coefficient: {crashedCar.Coefficient} ");
            }
            ShowDataOperations();
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Type new CrashedCar details");
                        Console.Write("IsCrashed: ");
                        bool isCrashed = bool.Parse(Console.ReadLine());
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());
                        CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                        crashedCarRepository.Add(crashedCar);
                        Console.WriteLine("CrashedCar added to CrashedCars ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting CrashedCar");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        crashedCarRepository.Delete(id);
                        Console.WriteLine("CrashedCar deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new CrashedCar details");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("IsCrashed: ");
                        bool isCrashed = bool.Parse(Console.ReadLine());
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());

                        CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                        crashedCarRepository.Update(crashedCar, id);
                        Console.WriteLine("CrashedCar updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find CrashedCar");
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());
                        var crashedCar = crashedCarRepository.FindById(id);
                        Console.WriteLine("Founded crashedCar details");
                        PrintDetails(crashedCar);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CrashedCars");

                        crashedCarRepository.GetAll().ForEach(crashedCar => PrintDetails(crashedCar));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
