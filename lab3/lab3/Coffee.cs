namespace lab3
{
    class Coffee
    {
        public int Quantity { get; set; }
        public CoffeeSelection CoffeeSelection { get; set; }

        public Coffee(int quantity, CoffeeSelection coffeeSelection)
        {
            Quantity = quantity;
            CoffeeSelection = coffeeSelection;
        }
    }
}
    