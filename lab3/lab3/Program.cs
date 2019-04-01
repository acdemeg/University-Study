using System;
using System.Collections.Generic;

namespace lab3
{
    enum CoffeeSelection { Cappuccino = 1, Espresso = 2, FilterCoffee = 3 };
    
    class Program
    {
        private const int MAX_BEANS = 100;

        static int Main(string[] args)
        {
             Dictionary<CoffeeSelection, CoffeeBean> beans = new Dictionary<CoffeeSelection,CoffeeBean>();
             beans.Add(CoffeeSelection.Cappuccino, new CoffeeBean("Arabica", MAX_BEANS));
             beans.Add(CoffeeSelection.Espresso, new CoffeeBean("Robusta", MAX_BEANS));
             beans.Add(CoffeeSelection.FilterCoffee, new CoffeeBean("Liberica", MAX_BEANS));
             CoffeeMachine coffeeMachine = new CoffeeMachine(beans);
             do
             {

                 try
                 {

                     do
                     {
                         Console.WriteLine("-------------------------------------------------------------------------------");
                         Console.WriteLine("CoffeeMachine wait order");
                         Console.WriteLine("");
                         Console.WriteLine("To choose kind coffee:");
                         Console.WriteLine("1. Cappuccino\n2. Espresso\n3. FilterCoffee");
                         Console.WriteLine("");
                         CoffeeSelection coffeType = (CoffeeSelection)getNumber(Enum.GetNames(typeof(CoffeeSelection)).Length);
                         int quantity = getQuantity();
                         Coffee coffee = coffeeMachine.BrewCoffee(coffeType, quantity);
                         Console.WriteLine("Coffee {0} , {1} milliliters. ", coffee.CoffeeSelection, coffee.Quantity);
                         Console.WriteLine("Grains residue: Arabica {0}, Robusta {1}, Liberica {2} ", beans[CoffeeSelection.Cappuccino].Quantity,
                         beans[CoffeeSelection.Espresso].Quantity, beans[CoffeeSelection.FilterCoffee].Quantity);
                         Console.WriteLine();
                         Console.WriteLine("In order to exit press key ESC and ENTER");
                         Console.WriteLine("");
                         Console.WriteLine("You want add coffeebean into CoffeeMachine ?  y - yes  anyKey - no");

                         //add of coffeeBeans to CoffeeMachine
                         if (Console.ReadKey().Key == ConsoleKey.Y)
                         {
                             addBeans(beans);
                         }
                         else if (Console.ReadKey().Key == ConsoleKey.Escape)
                         {
                             return 0;
                         }
                     }
                     while (Console.ReadKey().Key != ConsoleKey.Escape);
                 }
                 catch (CoffeeExeption ex)
                 {
                     Console.WriteLine("-------------------------------------------------------------------------------");
                     Console.WriteLine(ex.Message);
                     Console.WriteLine();

                 }
                 finally 
                 {
                     Console.WriteLine("In order to exit press key ESC or ENTER to continue");
                 } 
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
             return 0;
         } 

        public static int getNumber(int max)
        {
           Console.Write("\nChoose Coffee: ");
           string strNumber = Console.ReadLine();
           int value;
           if (Int32.TryParse(strNumber, out value))
           { 
              if (value >= 1 && value <= max)
              {
                 return value;     
              }
              else
              {
                 throw new CoffeeExeption("Choose right number");
              }                                
           }
           throw new CoffeeExeption("Integer expected");
         }        
          
        public static int getQuantity()
        {
           Console.Write("\nEnter amount in grams: ");
           string strQuantity = Console.ReadLine();
           int value;
           if (Int32.TryParse(strQuantity, out value))
           {
               if (value > 0)
               {
                   return value;
               }
               else
               {
                   throw new CoffeeExeption("Amount don't be less or equal 0 ");
               }   
           }
           throw new CoffeeExeption("Integer expected");   
        }

        public static void addBeans(Dictionary<CoffeeSelection, CoffeeBean> beans)
        {
            Console.WriteLine("Select type: 1 - Arabica, 2 - Robusta, 3 - Liberica");
            string strNumber = Console.ReadLine();
            Console.WriteLine("Entered quantity less than 100");
            string quantityBeans = Console.ReadLine();
            int intQuantityBeans;
            Int32.TryParse(quantityBeans, out intQuantityBeans);
            switch (strNumber)
            {
                case "1": beans[CoffeeSelection.Cappuccino].Quantity = intQuantityBeans;
                    break;
                case "2": beans[CoffeeSelection.Espresso].Quantity = intQuantityBeans;
                    break;
                case "3": beans[CoffeeSelection.FilterCoffee].Quantity = intQuantityBeans;
                    break;
                default: throw new CoffeeExeption("Choose right number");
            }
        }
            
    }
}
