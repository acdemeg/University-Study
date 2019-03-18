using System;

namespace lab3
{
    class GrinderUnit
    {
        public GroundCoffee Grind (CoffeeBean coffeeBean, int guantity)
        {
            if (coffeeBean.Quantity < guantity)
            {
                throw new CoffeeExeption("Not enough grains " + coffeeBean.Name);
            }
            coffeeBean.Quantity -= guantity;
            return new GroundCoffee(guantity);
       }
    }
}
