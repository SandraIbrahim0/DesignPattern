using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder
{
    public class StepWiseBuilder
    {
        // we have the car with type and wheelSize but the Wheelsize depend on the car type 
        public class Car
        {
            public CarTypes Type { get; set; }
            public int WheelSize { get; set; }
            public override string ToString()
            {
                return $"{nameof(Type)}: {Type.ToString()}, {nameof(WheelSize)}: {WheelSize.ToString()}";
            }
        }
        public enum CarTypes
        {
            sedan = 0,
            crossover = 1
        }
        //Solution to have Interface Segration each Interface depend on intalizate specific part 
        public interface ICarTypeBuilder
        {
            public ICarWheelSizeBuilder CarType(CarTypes type);
        }
        public interface ICarWheelSizeBuilder
        {
            public ICarBuilder BuildCarWheelSize(int size);
        }
        public interface ICarBuilder
        {
            public Car BuildCar();
        }
        // to hide the complexity of the interface not explosure the details of the implemnation

        public class CarBuilder
        {
            public ICarTypeBuilder CreateCar()
            {
                return new Implementation();
            }
            private class Implementation : ICarTypeBuilder, ICarWheelSizeBuilder, ICarBuilder
            {
                private Car car = new Car();
                public ICarWheelSizeBuilder CarType(CarTypes type)
                {
                    car.Type = type;
                    return this; // == return this
                }
                public ICarBuilder BuildCarWheelSize(int size)
                {
                    switch (car.Type)
                    {
                        case CarTypes.crossover when size < 17 || size > 20:
                            car.WheelSize = size;
                            break;
                        case CarTypes.sedan when size < 15 || size > 17:
                            car.WheelSize = size;
                            break;
                    }
                    return this;
                }
                public Car BuildCar()
                {
                    return car;
                }

            }
        }
    }
}
