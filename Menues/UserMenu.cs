using System;
using LogisticService.Models;
using LogisticService.CalculationServices.Abstractions;
using LogisticService.CalculationServices.Implementations;
using LogisticService.Extentions;
using System.Threading.Tasks;

namespace LogisticService.Menues
{
    public class UserMenu : Menu
    {
        public override async Task Start()
        {
            Console.WriteLine("Calculation Service start");

            Direction direction = GetingDirectionDetails();
            CarType carType = GetingCarTypeDetails();
            CarModel carModel = GetingCarModelDetails();
            Container container = GetingContaineDetails();
            CrashedCar crashed = GetingCrashedCarDetails();

            ICalculationService calculationServiceRepository = new CalculationServiceRepository();

            var result = await calculationServiceRepository.LogisticServiceCalculation(new CalculationServices.Models.CalculationModel(direction, carType, carModel, container, crashed));

            Console.WriteLine($"Logistic Calculation result is: {result}");
        }

        public Direction GetingDirectionDetails()
        {
            Console.WriteLine("Fill direction details:");
            Console.Write("From: ");

            string from = Console.ReadLine();

            Console.Write("To: ");

            string to = Console.ReadLine();

            Direction direction = new Direction(from, to);

            return direction;
        }

        public CarType GetingCarTypeDetails()
        {
            Console.WriteLine("Fill CarType details:");
            Console.Write("CarType: ");

            string carTypeName = Console.ReadLine();

            CarType carType = new CarType(carTypeName);

            return carType;
        }

        public CarModel GetingCarModelDetails()
        {
            Console.WriteLine("Fill CarModel details:");
            Console.Write("CarModel: ");

            string carModelName = Console.ReadLine();

            CarModel carModel = new CarModel(carModelName);

            return carModel;
        }

        public Container GetingContaineDetails()
        {
            Console.WriteLine("Fill Container details:");

            while (true)
            {
                Console.Write("IsCrashed? true or false: ");
                try
                {
                    var res = Console.ReadLine().BooleanValidation();
                    Container container = new Container(res);
                    return container;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public CrashedCar GetingCrashedCarDetails()
        {
            Console.WriteLine("Fill CrashedCar details:");

            while (true)
            {
                Console.Write("IsCrashed? true or false: ");
                try
                {
                    var res = Console.ReadLine().BooleanValidation();
                    CrashedCar crashedCar = new CrashedCar(res);
                    return crashedCar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
