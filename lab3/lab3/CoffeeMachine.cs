using System.Collections.Generic;

namespace lab3
{
    class CoffeeMachine
    {
        private Dictionary<CoffeeSelection, CoffeeBean> _beans;
        private GrinderUnit _grinderUnit;
        private BrewingUnit _brewingUnit;

        public CoffeeMachine(Dictionary<CoffeeSelection, CoffeeBean> beans)
        {
            _beans = new Dictionary<CoffeeSelection, CoffeeBean>(beans);
            _grinderUnit = new GrinderUnit();
            _brewingUnit = new BrewingUnit();
        }

        public Coffee BrewCoffee (CoffeeSelection coffeeSelection, int guantity)
        {   
            //get for key CoffeeBean -> get GroundCoffee -> get Coffee
            return new BrewingUnit().Brew(coffeeSelection, new GrinderUnit().Grind(_beans[coffeeSelection], guantity)) ;
            
        }
    }
}
