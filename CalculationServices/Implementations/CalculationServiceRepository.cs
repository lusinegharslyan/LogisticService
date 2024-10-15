using LogisticService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticService.Models;
using LogisticService.CalculationServices.Abstractions;
using LogisticService.CalculationServices.Models;
using LogisticService.Repositories;

namespace LogisticService.CalculationServices.Implementations
{
    public class CalculationServiceRepository : ICalculationService
    {
        public async Task<float> LogisticServiceCalculation(CalculationModel calculationModel)
        {
            float amount = await GetDirectionAmount(new DirectionRepository(), calculationModel.Direction);
            float carTypeCoef = await GetCarTypeCoefficient(new CarTypeRepository(), calculationModel.CarType);
            float carModelCoef =  await GetCarModelCoefficient(new CarModelRepository(), calculationModel.CarModel);
            float containerCoef = await GetContainerCoefficient(new ContainerRepository(), calculationModel.Container);
            float crashedCarCoef =  await GetcrashedcarCoefficient(new CrashedCarRepository(), calculationModel.Crashed);

            return amount * carTypeCoef * carModelCoef * containerCoef * crashedCarCoef;
        }

        private async Task<float> GetDirectionAmount(IRepository<Direction> directionRepository, Direction direction)
        {
            Direction foundedDirection = await directionRepository.FindAsync(direction);

            return foundedDirection.Distance * foundedDirection.Price;
        }

        private async Task<float> GetCarTypeCoefficient(IRepository<CarType> carTypeRepository, CarType carType)
        {
            CarType foundedCarType = await carTypeRepository.FindAsync(carType);

            return foundedCarType.Coefficient;
        }

        private async Task<float> GetCarModelCoefficient(IRepository<CarModel> carModelRepository, CarModel carModel)
        {
            CarModel foundedCarModel = await carModelRepository.FindAsync(carModel);

            return foundedCarModel.Coefficient;
        }

        private async Task<float> GetContainerCoefficient(IRepository<Container> containerRepository, Container container)
        {
            Container foundedContainer = await containerRepository.FindAsync(container);

            return foundedContainer.Coefficient;
        }

        private async Task<float> GetcrashedcarCoefficient(IRepository<CrashedCar> crashedCarRepository, CrashedCar crashed)
        {
            CrashedCar foundedCrashedCar = await crashedCarRepository.FindAsync(crashed);

            return foundedCrashedCar.Coefficient;
        }
    }
}
