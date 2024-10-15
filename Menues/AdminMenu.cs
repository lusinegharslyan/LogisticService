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



namespace LogisticService.Menues
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

                int choice;

                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                if (choice == 0)
                {
                    Console.WriteLine("Exit AdminMenu");
                    break;
                }
                switch (choice)
                {
                    case 1:
                        ShowDirectionsAdminMenu(new DirectionRepository());
                        break;
                    case 2:
                        ShowCaTypesAdminMenu(new CarTypeRepository());
                        break;
                    case 3:
                        ShowCarModelsAdminMenu(new CarModelRepository());
                        break;
                    case 4:
                        ShowContainersAdminMenu(new ContainerRepository());
                        break;
                    case 5:
                        ShowCrashedCarsAdminMenu(new CrashedCarRepository());
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

                int choice;
                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                if (choice == 0)
                {
                    break;
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
                            await directionRepository.AddAsync(direction);
                            Console.WriteLine("Direction added to Directions ");

                        };
                        break;
                    case 2:
                        {
                            Console.WriteLine("Deleting direction");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            await directionRepository.DeleteAsync(id);
                            Console.WriteLine("Direction deleted ");
                        };
                        break;
                    case 3:
                        {
                            Console.WriteLine("Type new Direction details");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.Write("From: ");
                            string from = Console.ReadLine();
                            Console.Write("To: ");
                            string to = Console.ReadLine();
                            Console.Write("Distance: ");
                            float distance = float.Parse(Console.ReadLine());
                            Console.Write("Price: ");
                            float price = float.Parse(Console.ReadLine());
                            Direction direction = new Direction(from, to, distance, price);
                            await directionRepository.UpdateAsync(direction, id);
                            Console.WriteLine("Direction updated ");
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Find Direction");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var direction = await directionRepository.FindByIdAsync(id);
                            Console.WriteLine("Founded Direction details");
                            PrintDetails(direction);
                        };
                        break;
                    case 5:
                        {
                            Console.WriteLine("Geting All Directions");

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
            int choice;
            while (true)
            {
                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                else
                {
                    break;
                }
            }
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
                        CarType carType = new CarType(type, coefficient);
                        await carTypeRepository.AddAsync(carType);
                        Console.WriteLine("CarType added to CarTypes ");

                    };
                    break;
                case 2:
                    {
                        Console.WriteLine("Deleting carType");
                        int id;
                        while (true)
                        {
                            Console.Write("Id: ");
                            Console.ReadLine().IntValidation(out id);

                            if (id == -1)
                            {
                                Console.WriteLine("Invalid choice");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                        await carTypeRepository.DeleteAsync(id);
                        Console.WriteLine("CarType deleted ");
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine("Type new CarType details");
                        int id;
                        while (true)
                        {
                            Console.Write("Id: ");
                            Console.ReadLine().IntValidation(out id);

                            if (id == -1)
                            {
                                Console.WriteLine("Invalid choice");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.Write("Type: ");
                        string type = Console.ReadLine();
                        Console.Write("Coefficient: ");
                        float coefficient = float.Parse(Console.ReadLine());

                        CarType carType = new CarType(type, coefficient);
                        await carTypeRepository.UpdateAsync(carType, id);
                        Console.WriteLine("CarType updated ");
                    };
                    break;
                case 4:
                    {
                        Console.WriteLine("Find CarType");
                        int id;
                        while (true)
                        {
                            Console.Write("Id: ");
                            Console.ReadLine().IntValidation(out id);

                            if (id == -1)
                            {
                                Console.WriteLine("Invalid choice");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        var carType = await carTypeRepository.FindByIdAsync(id);
                        Console.WriteLine("Founded CarType details");
                        PrintDetails(carType);
                    };
                    break;
                case 5:
                    {
                        Console.WriteLine("Geting All CarTypes");

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
            int choice;
            while (true)
            {
                ShowDataOperations();

                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
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
                            await carModelRepository.AddAsync(carModel);
                            Console.WriteLine("CarModel added to CarModels ");

                        };
                        break;
                    case 2:
                        {
                            Console.WriteLine("Deleting carModel");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            await carModelRepository.DeleteAsync(id);
                            Console.WriteLine("CarModel deleted ");
                        };
                        break;
                    case 3:
                        {
                            Console.WriteLine("Type new CarModel details");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.Write("Type: ");
                            string model = Console.ReadLine();
                            Console.Write("Coefficient: ");
                            float coefficient = float.Parse(Console.ReadLine());

                            CarModel carModel = new CarModel(model, coefficient);
                            await carModelRepository.UpdateAsync(carModel, id);
                            Console.WriteLine("CarModel updated ");
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Find CarModel");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var carModel = await carModelRepository.FindByIdAsync(id);
                            Console.WriteLine("Founded CarModel details");
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


        }

        private async Task ShowContainersAdminMenu(IRepository<Container> containerRepository)
        {
            void PrintDetails(Container container)
            {
                Console.WriteLine($"Id: {container.Id} | IsOpen: {container.IsOpen} | Coefficient: {container.Coefficient} ");
            }
            int choice;
            while (true)
            {
                ShowDataOperations();

                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                if (choice == 0)
                {
                    return;
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Fill Container type IsOpen?");
                          
                            bool isOpen;
                            while (true)
                            {
                                Console.Write("Input true or false: ");
                                try
                                {
                                    isOpen = Console.ReadLine().BooleanValidation();
                                   break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }

                            Console.Write("Coefficient: ");
                            float coefficient = float.Parse(Console.ReadLine());
                            Container container = new Container(isOpen, coefficient);
                            await containerRepository.AddAsync(container);
                            Console.WriteLine("Container added to Containers ");

                        };
                        break;
                    case 2:
                        {
                            Console.WriteLine("Deleting Container");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            await containerRepository.DeleteAsync(id);
                            Console.WriteLine("Container deleted ");
                        };
                        break;
                    case 3:
                        {
                            Console.WriteLine("Type new Container details");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            bool isOpen;
                            while (true)
                            {
                                Console.Write("IsOpen? Input true of false:  ");
                                try
                                {
                                    isOpen = Console.ReadLine().BooleanValidation();
                                    break;
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                           
                           
                            Console.Write("Coefficient: ");
                            float coefficient = float.Parse(Console.ReadLine());

                            Container container = new Container(isOpen, coefficient);
                            await containerRepository.UpdateAsync(container, id);
                            Console.WriteLine("Container updated ");
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Find Container");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var container = await containerRepository.FindByIdAsync(id);
                            Console.WriteLine("Founded container details");
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
        }

        private async Task ShowCrashedCarsAdminMenu(IRepository<CrashedCar> crashedCarRepository)
        {
            void PrintDetails(CrashedCar crashedCar)
            {
                Console.WriteLine($"Id: {crashedCar.Id} | IsCrashed: {crashedCar.IsCrashed} | Coefficient: {crashedCar.Coefficient} ");
            }
            int choice;
            while (true)
            {
                ShowDataOperations();

                Console.ReadLine().IntValidation(out choice);

                if (choice == -1)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                if (choice == 0)
                {
                    return;
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Fill CrashedCar details");
                            bool isCrashed;
                            while (true)
                            {
                                Console.Write("IsCrashed? Input true or false:  ");
                                try
                                {
                                    isCrashed = Console.ReadLine().BooleanValidation();
                                    break;
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }

                            }
                           
                          
                            Console.Write("Coefficient: ");
                            float coefficient = float.Parse(Console.ReadLine());
                            CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                            await crashedCarRepository.AddAsync(crashedCar);
                            Console.WriteLine("CrashedCar added to CrashedCars ");

                        };
                        break;
                    case 2:
                        {
                            Console.WriteLine("Deleting CrashedCar");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            await crashedCarRepository.DeleteAsync(id);
                            Console.WriteLine("CrashedCar deleted ");
                        };
                        break;
                    case 3:
                        {
                            Console.WriteLine("Type new CrashedCar details");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.Write("IsCrashed: ");
                            bool isCrashed = bool.Parse(Console.ReadLine());
                            Console.Write("Coefficient: ");
                            float coefficient = float.Parse(Console.ReadLine());
                            CrashedCar crashedCar = new CrashedCar(isCrashed, coefficient);
                            await crashedCarRepository.UpdateAsync(crashedCar, id);
                            Console.WriteLine("CrashedCar updated ");
                        };
                        break;
                    case 4:
                        {
                            Console.WriteLine("Find CrashedCar");
                            int id;
                            while (true)
                            {
                                Console.Write("Id: ");
                                Console.ReadLine().IntValidation(out id);

                                if (id == -1)
                                {
                                    Console.WriteLine("Invalid choice");
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var crashedCar = await crashedCarRepository.FindByIdAsync(id);
                            Console.WriteLine("Founded crashedCar details");
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
}
