namespace DesignPattern.Decorator
{
    public class DecoratorCar : ICar
    {
        private ICar car;
        public DecoratorCar(ICar car)
        {
            this.car = car;
        }

        public virtual ICar ManufactureCar()
        {
            return car.ManufactureCar();
        }
    }
}
