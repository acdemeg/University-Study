namespace lab3
{
    class CoffeeBean
    {
        public string Name { get; private set; }
        public int Quantity { get; set; }

        public CoffeeBean(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
