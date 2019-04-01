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
            _beans = beans;
            _grinderUnit = new GrinderUnit();
            _brewingUnit = new BrewingUnit();
        }
       
        public Coffee BrewCoffee (CoffeeSelection coffeeSelection, int guantity)
        {   
            //get for key CoffeeBean -> get GroundCoffee -> get Coffee
            return _brewingUnit.Brew(coffeeSelection, _grinderUnit.Grind(_beans[coffeeSelection], guantity));
            
        }
    }
}
