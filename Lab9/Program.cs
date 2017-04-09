using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class CircleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Circle Tester");

            int numberOfCircles = 0;

            bool run = true;
            while (run)
            {
                Console.WriteLine("Enter radius:");
                double radius = GetInput();

                Circle circle1 = new Circle(radius);
                numberOfCircles++;

                Circle.PrintCircumference(Circle.circumference);
                Circle.PrintArea(Circle.area);
         
                Console.WriteLine("Continue? (y/n):");
                run = Continue();
                //Goodbye message if user wants to quit
                if (run == false)
                {
                    Console.WriteLine("\nGoodbye. You created " + numberOfCircles + " Circle object(s).");
                }
            }
        }

        public static double GetInput()
        {
            double outputNum = -1;
            bool isValidInput = false;
            string input;

            //Get and check input
            do
            {
                input = Console.ReadLine();
                isValidInput = Validator(input);
            } while (isValidInput == false);

            outputNum = double.Parse(input);

            return outputNum;
        }

        //Validate user input
        public static bool Validator(string input)
        {
            double parsedInput;
            try
            {
                parsedInput = double.Parse(input);
                //Check if negative number
                if (parsedInput <= 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return true;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Value must be greater than 0! Try again:");
                return false;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Value must be a number! Try again:");
                return false;
            }
        }


        //Continue program?
        public static bool Continue()
        {
            string input = Console.ReadLine().ToLower();
            bool run = false;

            if (input.Equals("n"))
            {
                run = false;
            }
            else if (input.Equals("y"))
            {
                run = true;
            }
            else
            {
                Console.WriteLine("\nInvalid input! Please type y/n:");
                run = Continue();
            }

            return run;
        }
    }
    
    class Circle
    {
        public static double pi = Math.PI;
        public static double circumference = -1;
        public static double area = -1;

        //Create circle object
        public Circle(double radius)
        {
            circumference = GetCircumference(radius);
            area = GetArea(radius);
        }

        public static double GetCircumference(double radius)
        {
            return 2*pi*radius;
        }

        public static void PrintCircumference(double circumference)
        {
            Console.WriteLine("Circumference: " + circumference);
        }

        public static double GetArea(double radius)
        {
            return pi * (radius * radius);
        }

        public static void PrintArea(double area)
        {
            Console.WriteLine("Area: " + area);
        }
    }
}
