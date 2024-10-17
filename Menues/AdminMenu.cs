using LogisticService.Models;
using LogisticService.Interfaces;
using LogisticService.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Container = LogisticService.Models.Container;
using LogisticService.Extentions;
using LogisticService.Helpers;



namespace LogisticService.Menues
{
    public class AdminMenu : Menu
    {
        public void ShowDataTypes()
        {
            Console.WriteLine("1-Directions | 2-CarTypes | 3-CarModels | 4-Containers | 5-CrashedCars | 0-Exit");
        }

        public void ShowDataOperations()
        {
            Console.WriteLine("1-Add | 2-Delete | 3-Update | 4-FindById | 5-GetAll | 0-Exit");
        }

        public override async Task Start()
        {
            while (true)
            {
                ShowDataTypes();
                int choice = InputGeters.IntGeter("Choose data");

                if (choice == 0)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        await ShowDirectionsAdminMenu(new DirectionRepository());
                        break;
                    case 2:
                        await ShowCaTypesAdminMenu(new CarTypeRepository());
                        break;
                    case 3:
                        await ShowCarModelsAdminMenu(new CarModelRepository());
                        break;
                    case 4:
                        await ShowContainersAdminMenu(new ContainerRepository());
                        break;
                    case 5:
                        await ShowCrashedCarsAdminMenu(new CrashedCarRepository());
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
        }

        private async Task ShowDirectionsAdminMenu(IRepository<Direction> directionRepository)
        {
            void PrintDetails(Direction direction)
            {
                Console.WriteLine($"Id: {direction.Id} | From: {direction.From} | To: {direction.To} | Distance: {direction.Distance} | Price: {direction.Price}");
            }
            while (true)
            {
                ShowDataOperations();
                int choice = InputGeters.IntGeter("Choose operation");

                if (choice == 0)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Adding Direction");
                            string from = InputGeters.StringGeter("from");
                            string to = InputGeters.StringGeter("to");
                            float distance = InputGeters.FloatGeter("distance");
                            float price = InputGeters.FloatGeter("price");
                            Direction direction = new Direction(from, to, distance, price);
                            await directionRepository.AddAsync(direction);
                            Console.WriteLine("Direction added to Directions ");
                        };
                        break;
                    case 2:
                        {
                            Console.WriteLine("Deleting direction");
                            int id = InputGeters.IntGeter("id");

                            await directionRepository.DeleteAsync(id);
                            Console.WriteLine("Direction deleted ");
                        };
                        break;
                    case 3:
                        {
                            Console.WriteLine("Updating Direction");
                            int id = InputGeters.IntGeter("id");
                            string from = InputGeters.StringGeter("from");
                            string to = InputGeters.StringGeter("to");
                            float distance = InputGeters.FloatGeter("distance");
                            float price = InputGeters.FloatGeter("price");
                            Direction direction = new Direction(from, to, distance, price);
                            await directionRepository.UpdateAsync(direction, id);
                            Console.WriteLine("Direction updated ");
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Find Direction by Id");
                            int id = InputGeters.IntGeter("id");
                            var direction = await directionRepository.FindByIdAsync(id);
                            Console.WriteLine("Direction found");
                            PrintDetails(direction);
                        };
                        break;
                    case 5:
                        {
                            Console.WriteLine("Show All Directions List");
                            (await directionRepository.GetAllAsync()).ForEach(direction => PrintDetails(direction));
                        };
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private async Task ShowCaTypesAdminMenu(IRepository<CarType> carTypeRepository)
        {
            void PrintDetails(CarType carType)
            {
                Console.WriteLine($"Id: {carType.Id} | Type: {carType.Type} | Coefficient: {carType.Coefficient} ");
            }

            ShowDataOperations();

            int choice = InputGeters.IntGeter("Choose operation");

            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Adding CarType ");
                        string type = InputGeters.StringGeter("Type");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        CarType carType = new CarType(type, coefficient);
                        await carTypeRepository.AddAsync(carType);
                        Console.WriteLine("CarType added to CarTypes ");
                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting carType");
                        int id = InputGeters.IntGeter("id");
                        await carTypeRepository.DeleteAsync(id);
                        Console.WriteLine("CarType deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Updating CarType");
                        int id = InputGeters.IntGeter("id");
                        string type = InputGeters.StringGeter("Type");
                        float coefficient = InputGeters.FloatGeter("Coefficient");

                        CarType carType = new CarType(type, coefficient);
                        await carTypeRepository.UpdateAsync(carType, id);
                        Console.WriteLine("CarType updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find CarType by Id");
                        int id = InputGeters.IntGeter("id");
                        var carType = await carTypeRepository.FindByIdAsync(id);
                        Console.WriteLine("CarType found");
                        PrintDetails(carType);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Get All CarTypes List");
                        (await carTypeRepository.GetAllAsync()).ForEach(carType => PrintDetails(carType));
                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

        private async Task ShowCarModelsAdminMenu(IRepository<CarModel> carModelRepository)
        {
            void PrintDetails(CarModel carModel)
            {
                Console.WriteLine($"Id: {carModel.Id} | Type: {carModel.Model} | Coefficient: {carModel.Coefficient} ");
            }

            ShowDataOperations();
            int choice = InputGeters.IntGeter("Choose operation");

            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Adding CarModel ");
                        string model = InputGeters.StringGeter("Model");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        CarModel carModel = new CarModel(model, coefficient);
                        await carModelRepository.AddAsync(carModel);
                        Console.WriteLine("CarModel added to CarModels ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting CarModel");
                        int id = InputGeters.IntGeter("id");
                        await carModelRepository.DeleteAsync(id);
                        Console.WriteLine("CarModel deleted ");
                    };
                    break;
                case 3:
                    {

                        Console.WriteLine("Updating CarModel");
                        int id = InputGeters.IntGeter("id");
                        string model = InputGeters.StringGeter("model");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        CarModel carModel = new CarModel(model, coefficient);
                        await carModelRepository.UpdateAsync(carModel, id);
                        Console.WriteLine("CarModel updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find Model by Id");
                        int id = InputGeters.IntGeter("id");
                        var carModel = await carModelRepository.FindByIdAsync(id);
                        Console.WriteLine("CarModel found");
                        PrintDetails(carModel);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CarModels");
                        (await carModelRepository.GetAllAsync()).ForEach(carModel => PrintDetails(carModel));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }



        }

        private async Task ShowContainersAdminMenu(IRepository<Container> containerRepository)
        {
            void PrintDetails(Container container)
            {
                Console.WriteLine($"Id: {container.Id} | IsOpen: {container.IsOpen} | Coefficient: {container.Coefficient} ");
            }

            ShowDataOperations();
            int choice = InputGeters.IntGeter("Choose operation");
            if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {

                        Console.WriteLine("Adding Container ");
                        bool isOpen = InputGeters.BoolGeter("IsOpen");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        Container container = new Container(isOpen, coefficient);
                        await containerRepository.AddAsync(container);
                        Console.WriteLine("Container added to Containers ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting Container");
                        int id = InputGeters.IntGeter("id");
                        await containerRepository.DeleteAsync(id);
                        Console.WriteLine("Container deleted ");
                    };
                    break;
                case 3:
                    {

                        Console.WriteLine("Updating Container");
                        int id = InputGeters.IntGeter("id");
                        bool isOpen = InputGeters.BoolGeter("IsOpen");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        Container container = new Container(isOpen, coefficient);
                        await containerRepository.UpdateAsync(container, id);
                        Console.WriteLine("Container updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find Container by Id");
                        int id = InputGeters.IntGeter("id");
                        var container = await containerRepository.FindByIdAsync(id);
                        Console.WriteLine("Container found");
                        PrintDetails(container);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All Containers");
                        (await containerRepository.GetAllAsync()).ForEach(container => PrintDetails(container));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    

    private async Task ShowCrashedCarsAdminMenu(IRepository<CrashedCar> crashedCarRepository)
    {
        void PrintDetails(CrashedCar crashedCar)
        {
            Console.WriteLine($"Id: {crashedCar.Id} | IsCrashed: {crashedCar.IsCrashed} | Coefficient: {crashedCar.Coefficient} ");
        }

        ShowDataOperations();
        int choice = InputGeters.IntGeter("Choose operation");
        if (choice == 0)
            {
                return;
            }
            switch (choice)
            {
                case 1:
                    {
                       
                        Console.WriteLine("Adding CrashedCar ");
                        bool isCrashed = InputGeters.BoolGeter("IsCrashed");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                        await crashedCarRepository.AddAsync(crashedCar);
                        Console.WriteLine("CrashedCar added to CrashedCars ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting CrashedCar");    
                        int id = InputGeters.IntGeter("id");
                        await crashedCarRepository.DeleteAsync(id);
                        Console.WriteLine("CrashedCar deleted ");
                    };
                    break;
                case 3:
                    {
                     
                        Console.WriteLine("Updating CrashedCar");
                        int id = InputGeters.IntGeter("id");
                        bool isCrashed = InputGeters.BoolGeter("isCrashed");
                        float coefficient = InputGeters.FloatGeter("Coefficient");
                        Container container = new Container(isCrashed, coefficient);

                        CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                        await crashedCarRepository.UpdateAsync(crashedCar, id);
                        Console.WriteLine("CrashedCar updated ");
                    };
                    break;
                case 4:
                    {
                    
                        Console.WriteLine("Find CrashedCar by Id");
                        int id = InputGeters.IntGeter("id");
                        var crashedCar = await crashedCarRepository.FindByIdAsync(id);
                        Console.WriteLine("CrashedCar found");
                        PrintDetails(crashedCar);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CrashedCars");

                        (await crashedCarRepository.GetAllAsync()).ForEach(crashedCar => PrintDetails(crashedCar));

                    };
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}

