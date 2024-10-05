using LogisticService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Classes;



namespace LogisticService.Repositories
{
    public class ICalculationServiceRepository : ICalculationService
    {
        public float LogisticserviceCalculation(Direction direction, CarType carType, CarModel carModel, Container container, CrashedCar crashed)
        {
            float amount = GetDirectionAmount(new DirectionRepository(), direction);
            float carTypeCoef = GetCarTypeCoefficient(new CarTypeRepository(), carType);
            float carModelCoef = GetCarModelCoefficient(new CarModelRepository(), carModel);
            float containerCoef = GetContainerCoefficient(new ContainerRepository(), container);
            float crashedCarCoef = GetcrashedcarCoefficient(new CrashedCarRepository(), crashed);


            return amount * (carTypeCoef + carModelCoef + containerCoef + crashedCarCoef);
        }

        private float GetDirectionAmount(IRepository<Direction> directionRepository, Direction direction)
        {
            Direction foundedDirection = directionRepository.Find(direction);

            return foundedDirection.Distance * foundedDirection.Price;
        }

        private float GetCarTypeCoefficient(IRepository<CarType> carTypeRepository, CarType carType)
        {
            CarType foundedCarType = carTypeRepository.Find(carType);

            return foundedCarType.Coefficient;
        }

        private float GetCarModelCoefficient(IRepository<CarModel> carModelRepository, CarModel carModel)
        {
            CarModel foundedCarModel = carModelRepository.Find(carModel);

            return foundedCarModel.Coefficient;
        }


        private float GetContainerCoefficient(IRepository<Container> containerRepository, Container container)
        {
            Container foundedContainer = containerRepository.Find(container);

            return foundedContainer.Coefficient;
        }

        private float GetcrashedcarCoefficient(IRepository<CrashedCar> crashedCarRepository, CrashedCar crashed)
        {
            CrashedCar foundedCrashedCar = crashedCarRepository.Find(crashed);

            return foundedCrashedCar.Coefficient;
        }

    }
}
