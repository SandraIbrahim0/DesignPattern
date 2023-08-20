
namespace DesignPattern.Decorator
{
    public class PetrolCarEngine : DecoratorCar
    {
        private ICar car { get; set; }
        public PetrolCarEngine(ICar car) : base(car)
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
                BMWCar.Engine = "Petrol Engine";
                Console.WriteLine("PetrolCarDecorator added Petrol Engine to the Car : " + car);
            }
        }
    }
}
