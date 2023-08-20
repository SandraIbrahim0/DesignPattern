using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decorator
{
    public class DesielCarEngine : DecoratorCar
    {
        private ICar car;
        public DesielCarEngine(ICar car) : base(car)
        {
            this.car = car; 
        }
        public override ICar ManufactureCar()
        {
            car.ManufactureCar();
            AddEngine(car);
            return car;
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar BMWCar)
            {
                BMWCar.Engine = "Desiel Engine";
                Console.WriteLine("PetrolCarDecorator added Desiel Engine to the Car : " + car);
            }
        }
    }
}
