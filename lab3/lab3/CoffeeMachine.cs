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
            //_beans = new Dictionary<CoffeeSelection, CoffeeBean>(beans);
            _beans = beans;
            _grinderUnit = new GrinderUnit();
            _brewingUnit = new BrewingUnit();
        }
        
        ////add a beans to coffee Machine
        //public bool addBeas(CoffeeSelection coffeeSelection, CoffeeBean coffeeBean)
        //{   
        //    // check have if same key
        //    if (_beans.ContainsKey(coffeeSelection))
        //    {   
        //        //remove old record
        //        _beans.Remove(coffeeSelection);
        //        _beans.Add(coffeeSelection, coffeeBean);
        //        return true;
        //    }
        //    return false;
        //}

        public Coffee BrewCoffee (CoffeeSelection coffeeSelection, int guantity)
        {   
            //get for key CoffeeBean -> get GroundCoffee -> get Coffee
            return _brewingUnit.Brew(coffeeSelection, _grinderUnit.Grind(_beans[coffeeSelection], guantity));
            
        }
    }
}
