using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

/**
 * INSTRUCTIONS:
 *  1. Modify the codes below and make it asynchronous
 *  2. After your modification, explain what makes it asynchronous
**/

/**
 * Explanation
 * The code makes asynchronous because it doesn't need to wait to cook synchronously
 * The DoTheCook Method will start cook the Eggs, Bacon and start preparing toastbread
 * It doesn't need to wait to finish and ready each food just to proceed to next/another food.
 * By this approach it can save time because it can proceed to other task while its still waiting it to finish the previous task.
**/

namespace asynchronous_assessment_lm
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // no need to do async this function due to have single operation only
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            await DoTheCook();

            // no need to do async this function due to have single operation only
            Juice orange = PourOJ();  
            Console.WriteLine("Orange juice is ready");
            Console.WriteLine("Breakfast is ready!");

            Console.ReadLine();
        }

        private static async Task DoTheCook()
        {
            var foodToCook = new List<Task>
            {
                FryEggs(2),
                FryBacon(3),
                PrepareToastBread(2)
            };

            await Task.WhenAll(foodToCook);
            Console.WriteLine("Eggs are ready");
            Console.WriteLine("Bacon is ready");
            Console.WriteLine("toast is ready");
        }

        private static async Task PrepareToastBread(int numberOfSlices)
        {
            var toast = await ToastBread(numberOfSlices);

            ApplyButter(toast);
            ApplyJam(toast);
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();


            return new Bacon();
        }

        private static async Task<Egg> FryEggs(int count)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {count} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private class Coffee
        {
        }

        private class Egg
        {
        }

        private class Bacon
        {
        }

        private class Toast
        {
        }

        private class Juice
        {
        }
    }
}
