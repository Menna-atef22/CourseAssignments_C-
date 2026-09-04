using System;

namespace Assignment2
{
    class Assignment_02
    {
        static void Main(string[] args)
        {
            Q1();
            Q2();
            Q3();
            Q4();
            Q5();
            Q6();
            Q7();

            Console.ReadKey();
        }


        //====================================================
        // Q1 - enter a number then print it
        static void Q1()
        {
            Console.WriteLine("Q1:");

            Console.Write("enter a number: ");
            string input = Console.ReadLine();
            Console.WriteLine("you entered " + input);

            Console.WriteLine();
        }


        //====================================================
        // Q2 - convert string to int, string has non numeric chars
        static void Q2()
        {
            Console.WriteLine("Q2:");

            string str = "12a3";

            try
            {
                int num = Convert.ToInt32(str);
                Console.WriteLine(num);
            }
            catch (FormatException)
            {
                // string has a letter in it so Convert.ToInt32 cant read it as a number
                // it throws FormatException, thats why we need the try/catch
                Console.WriteLine("error, the string is not a valid number");
            }

            Console.WriteLine();
        }

        //====================================================
        // Q3 - simple arithmetic with floating point numbers
        static void Q3()
        {
            Console.WriteLine("Q3:");

            float a = 5.5f;
            float b = 2.2f;
            float result = a + b;

            Console.WriteLine(result);

            // floating point numbers are not always 100% exact because of how
            // decimals get stored in binary, so sometimes the result comes out
            // a little off like 7.6999998 instead of 7.7

            Console.WriteLine();
        }

        //====================================================
        // Q4 - extract a substring from a string
        static void Q4()
        {
            Console.WriteLine("Q4:");

            string str = "Hello World";
            string sub = str.Substring(6, 5);

            Console.WriteLine(sub);

            Console.WriteLine();
        }

        //====================================================
        // Q5 - value type, assign then modify one of them
        static void Q5()
        {
            Console.WriteLine("Q5:");

            int x = 10;
            int y = x;
            y = 20;

            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);

            // x stays 10, y becomes 20
            // int is a value type, so y got its own separate copy of the value
            // changing y after that has nothing to do with x

            Console.WriteLine();
        }

        //====================================================
        // Q6 - reference type, assign then modify through one of them
        static void Q6()
        {
            Console.WriteLine("Q6:");

            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = arr1;
            arr2[0] = 99;

            Console.WriteLine("arr1[0] = " + arr1[0]);
            Console.WriteLine("arr2[0] = " + arr2[0]);

            // both come out 99
            // arrays are reference types, arr2 is not a new copy, its pointing to
            // the same object as arr1, so editing it from arr2 also shows up in arr1

            Console.WriteLine();
        }

        //====================================================
        // Q7 - two string variables printed as one
        static void Q7()
        {
            Console.WriteLine("Q7:");

            string first = "Ahmed";
            string second = "Ali";
            string full = first + " " + second;

            Console.WriteLine(full);

            Console.WriteLine();
        }
    }
}


//====================================================
// Q8
// answer: b) A value 1 will be assigned to d.

//====================================================
// Q9
// answer: d) 6 1


//====================================================
// Q10
// answer: d) 7 7
