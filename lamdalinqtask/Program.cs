using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lamdalinqtask
{

    class Program
    {
        
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>
{
         new Fruit{ Id = "f1", Name = "Apple", Color = Color.Red, Price = 23.0,},

         new Fruit{ Id = "f2", Name = "Banana", Color = Color.Yellow, Price= 10.0,},

         new Fruit{ Id = "f3", Name = "Pineapple", Color = Color.Yellow, Price = 55.0,},

         new Fruit{ Id = "f4", Name = "Cherry", Color = Color.Red, Price = 40.0,},

         new Fruit{ Id = "f5", Name ="Watermelon", Color = Color.Green, Price = 28.0,},

          new Fruit{ Id = "f6" , Name = "Strawberry", Color = Color.Red, Price  = 33.0,}

    };


            //descending order.
            var newDetailslamda = fruits.OrderByDescending(Fruit => Fruit.Name).ToList();
            var newDetailslinq = (from Fruit in fruits
                                   orderby Fruit.Name descending
                                  select Fruit).ToList();

            //ascending order.
            var newDetailslamda2 = fruits.OrderBy(Fruit => Fruit.Name).ToList();
            var newDetailslinq2 = (from Fruit in fruits
                                   orderby Fruit.Name 
                                   select Fruit).ToList();

            //red and green fruits.
            var newDetailslamda3 = fruits.Where(Fruit => Fruit.Color== Color.Red || Fruit.Color == Color.Green).ToList();
            var newDetailslinq3 = (from Fruit in fruits
                                   where Fruit.Color ==Color.Red || Fruit.Color == Color.Green
                                   select Fruit).ToList();

            //cheapest fruit.
            var cheapestprice = 10.0;

            var newDetailslamda4 = fruits.Where(Fruit => Fruit.Price <=cheapestprice ).ToList();
            var newDetailslinq4 = (from Fruit in fruits
                                   where Fruit.Price <=cheapestprice
                                   select Fruit).ToList();
            // most expensive fruit.
            var hightestprice = 50.0;
            var newDetailslamda5 = fruits.Where(Fruit => Fruit.Price > hightestprice).ToList();
            var newDetailslinq5= (from Fruit in fruits
                                   where Fruit.Price > hightestprice
                                  select Fruit).ToList();

            // budget of 40 RS.
            var budget = 40.0;

            var newDetailslamda6 = fruits.Where(Fruit => Fruit.Price <= budget).ToList();
            var newDetailslinq6 = (from Fruit in fruits
                                   where Fruit.Price <= budget
                                   select Fruit).ToList();



            //count of red fruits.
            var newDetailslamda7 = fruits.Count(Fruit => Fruit.Color == Color.Red);
              Console.WriteLine(newDetailslamda7);
              Console.ReadKey();
              var newDetailslinq7 = (from Fruit in fruits
                                     where Fruit.Color == Color.Red 

                                     select Fruit).Count();
              Console.WriteLine(newDetailslinq7);
              Console.ReadKey();



            //Group fruits with colors.


            var newDetailslamda8 = fruits.GroupBy(fruit => fruit.Color);

            var newDetailslinq8 = from fruit in fruits
                                      group fruit by fruit.Color into fruitGroup
                                      select fruitGroup;

             foreach (var fruitGroup in newDetailslinq8)
             {
                 Console.WriteLine(fruitGroup.Key);
                 foreach (var fruit in fruitGroup)
                 {

                     Console.WriteLine("    " + fruit.Name);


                 }

             }
            Console.ReadKey();
            foreach (var fruitGroup in newDetailslamda8)
            {
                Console.WriteLine(fruitGroup.Key);
                foreach (var fruit in fruitGroup)
                {

                    Console.WriteLine("    " + fruit.Name);


                }

            }
            Console.ReadKey();





            display(newDetailslamda);

        }
        public enum Color
        {
            Red, Green, Yellow
        }
        public class Fruit
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public Color Color { get; set; }
            public double Price { get; set; }
        }
        static void display(List<Fruit> fruits)
        {
            foreach (var fruit in fruits)
            {
                {
                    Console.WriteLine(fruit.Name);

                }

            }
            Console.ReadKey();
        }
    }

}
