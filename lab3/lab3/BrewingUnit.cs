namespace lab3
{
    class BrewingUnit      
    {
        public Coffee Brew (CoffeeSelection coffeeSelecton, GroundCoffee groundCoffee)
        {
            return new Coffee(groundCoffee.Quantity, coffeeSelecton);
        }
    }
}
