using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Domain
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CreateCar()
        {
            var car = new Car
            {
                Manufacturer = "Tesla",
                Model = "Model 3",
                Registration = "XYZ123",
                Year = 2023
            };

            await _carRepository.AddAsync(car);
        }
        public async Task GetAllCars()
        {
            var cars = await _carRepository.GetAllAsync();

            foreach (var car in cars)
            {
                Console.WriteLine($"Id: {car.Id}, Manufacturer: {car.Manufacturer}, Model: {car.Model}, Year: {car.Year}");
            }
        }

        public async Task UpdateCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car != null)
            {
                car.Year = 2024;
                car.Model = "Updated Model";

                await _carRepository.UpdateAsync(car);
            }
        }

        public async Task DeleteCar(int id)
        {
            await _carRepository.DeleteAsync(id);
        }

    }

}
