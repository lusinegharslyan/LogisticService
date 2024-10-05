using LogisticService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Interfaces;

namespace LogisticService.Classes
{
    public class UserMenu : Menu
    {
        public override void Start()
        {
            Console.WriteLine("Calculation Service start");
            Direction direction = GetingDirectionDetails();
            CarType carType = GetingCarTypeDetails();
            CarModel carModel = GetingCarModelDetails();
            Container container = GetingContaineDetails();
            CrashedCar crashed = GetingCrashedCarDetails();
            ICalculationService calculationServicerepository = new ICalculationServiceRepository();

            float result = calculationServicerepository.LogisticserviceCalculation(direction, carType, carModel, container, crashed);
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
            Console.Write("IsOpen? true or false: ");
            bool isOpen = bool.Parse(Console.ReadLine());
            Container container = new Container(isOpen);
            return container;
        }

        public CrashedCar GetingCrashedCarDetails()
        {

            Console.WriteLine("Fill CrashedCar details:");
            Console.Write("IsCrashed? true or false: ");
            bool isCrashed = bool.Parse(Console.ReadLine());
            CrashedCar crashedCar = new CrashedCar(isCrashed);
            return crashedCar;
        }

    }
}
