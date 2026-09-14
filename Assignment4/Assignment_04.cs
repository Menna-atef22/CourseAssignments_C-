using System;

namespace Assignment4
{
    // ---------- enums and structs used below ----------

    enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    enum Season { Spring, Summer, Autumn, Winter }

    [Flags]
    enum Permissions { None = 0, Read = 1, Write = 2, Delete = 4, Execute = 8 }

    enum Colors { Red, Green, Blue }

    struct Person
    {
        public string Name;
        public int Age;
    }

    struct Point
    {
        public double X;
        public double Y;
    }


    class Assignment_04
    {
        static void Main(string[] args)
        {
            // ---------- Functions ----------
            Q1();
            Q2();
            Q3();
            Q4();
            Q5();
            Q6();
            Q7();
            Q8();

            // ---------- Enum and Struct ----------
            E1();
            E2();
            E3();
            E4();
            E5();
            E6();
            E7();

            Console.ReadKey();
        }


        //====================================================
        // Q1 - value type parameter, by value vs by reference
        static void Q1()
        {
            Console.WriteLine("Q1:");

            int num1 = 10;
            AddByValue(num1);
            Console.WriteLine("after AddByValue, num1 = " + num1);

            int num2 = 10;
            AddByRef(ref num2);
            Console.WriteLine("after AddByRef, num2 = " + num2);

            // by value: the function gets a copy of the variable, so anything it
            // changes inside only affects that copy, num1 stays the same outside
            // by reference (ref): the function gets the actual variable itself,
            // so changing it inside the function changes it outside too, num2 becomes 15

            Console.WriteLine();
        }

        static void AddByValue(int n)
        {
            n = n + 5;
        }

        static void AddByRef(ref int n)
        {
            n = n + 5;
        }


        //====================================================
        // Q2 - reference type parameter, by value vs by reference
        static void Q2()
        {
            Console.WriteLine("Q2:");

            int[] arrA = { 1, 2, 3 };
            ChangeFirstByValue(arrA);
            Console.WriteLine("after ChangeFirstByValue, arrA[0] = " + arrA[0]);

            int[] arrB = { 1, 2, 3 };
            ChangeFirstByRef(ref arrB);
            Console.WriteLine("after ChangeFirstByRef, arrB[0] = " + arrB[0]);

            // arrays are reference types, so even when passed "by value" the
            // reference itself is copied, but it still points to the same array
            // in memory, so changing an element like arr[0] still affects the
            // original array outside the function (arrA[0] becomes 99)
            //
            // the real difference shows up if we try to make the parameter point
            // to a whole new array. with a plain parameter that new array only
            // exists inside the function, but with ref the reassignment is seen
            // outside too, that's why arrB itself becomes a brand new array {0,0,0}

            Console.WriteLine();
        }

        static void ChangeFirstByValue(int[] arr)
        {
            arr[0] = 99;
            arr = new int[] { 0, 0, 0 }; // only changes the local copy of the reference
        }

        static void ChangeFirstByRef(ref int[] arr)
        {
            arr[0] = 99;
            arr = new int[] { 0, 0, 0 }; // this replaces the caller's array too
        }


        //====================================================
        // Q3 - function with 4 parameters, returns sum and difference of two numbers
        static void Q3()
        {
            Console.WriteLine("Q3:");

            Console.Write("enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            SumAndSubtract(a, b, out int sum, out int diff);

            Console.WriteLine("sum = " + sum);
            Console.WriteLine("difference = " + diff);

            Console.WriteLine();
        }

        // 4 parameters total: a and b are the input numbers, sum and diff are
        // "out" parameters used to send back the two results
        static void SumAndSubtract(int a, int b, out int sum, out int diff)
        {
            sum = a + b;
            diff = a - b;
        }


        //====================================================
        // Q4 - sum of the individual digits of a number
        static void Q4()
        {
            Console.WriteLine("Q4:");

            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = SumOfDigits(number);

            Console.WriteLine("The sum of the digits of the number " + number + " is: " + result);

            Console.WriteLine();
        }

        static int SumOfDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number); // so a negative number doesnt mess up the loop

            while (number > 0)
            {
                sum = sum + (number % 10); // grabs the last digit
                number = number / 10;      // chops off the last digit
            }

            return sum;
        }


        //====================================================
        // Q5 - IsPrime function
        static void Q5()
        {
            Console.WriteLine("Q5:");

            int[] testValues = { 1, 2, 7, 15, 17, 20 };

            foreach (int n in testValues)
            {
                Console.WriteLine(n + " is prime? " + IsPrime(n));
            }

            Console.WriteLine();
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false; // 0, 1 and negatives are not prime

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false; // found a divisor, so its not prime
            }

            return true;
        }


        //====================================================
        // Q6 - MinMaxArray, using reference parameters
        static void Q6()
        {
            Console.WriteLine("Q6:");

            int[] numbers = { 8, 3, 27, 15, -4, 9 };

            int min = 0;
            int max = 0;
            MinMaxArray(numbers, ref min, ref max);

            Console.WriteLine("min = " + min);
            Console.WriteLine("max = " + max);

            Console.WriteLine();
        }

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr[0];
            max = arr[0];

            foreach (int num in arr)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
        }


        //====================================================
        // Q7 - iterative (non-recursive) factorial
        static void Q7()
        {
            Console.WriteLine("Q7:");

            Console.Write("enter a number to get its factorial: ");
            int n = Convert.ToInt32(Console.ReadLine());

            long result = Factorial(n);

            Console.WriteLine(n + "! = " + result);

            Console.WriteLine();
        }

        static long Factorial(int n)
        {
            long result = 1;

            // just multiplying step by step with a loop instead of the function
            // calling itself, thats what makes this iterative instead of recursive
            for (int i = 2; i <= n; i++)
            {
                result = result * i;
            }

            return result;
        }


        //====================================================
        // Q8 - ChangeChar, modify a letter at a certain position in a string
        static void Q8()
        {
            Console.WriteLine("Q8:");

            string word = "Hello";
            string changed = ChangeChar(word, 1, 'a');

            Console.WriteLine("original: " + word);
            Console.WriteLine("changed: " + changed);

            Console.WriteLine();
        }

        static string ChangeChar(string str, int position, char newChar)
        {
            // strings in c# are immutable, cant just do str[position] = newChar
            // so we convert to a char array, edit that, then build a new string
            char[] chars = str.ToCharArray();
            chars[position] = newChar;
            return new string(chars);
        }


        //====================================================
        // E1 - WeekDays enum, print all the days
        static void E1()
        {
            Console.WriteLine("E1:");

            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }

            Console.WriteLine();
        }


        //====================================================
        // E2 - Person struct, array of 3, display all
        static void E2()
        {
            Console.WriteLine("E2:");

            Person[] people = new Person[3];
            people[0] = new Person { Name = "Ahmed", Age = 20 };
            people[1] = new Person { Name = "Sara", Age = 22 };
            people[2] = new Person { Name = "Omar", Age = 19 };

            foreach (Person p in people)
            {
                Console.WriteLine("Name: " + p.Name + ", Age: " + p.Age);
            }

            Console.WriteLine();
        }


        //====================================================
        // E3 - Season enum, input a season name, show its month range
        static void E3()
        {
            Console.WriteLine("E3:");

            Console.Write("enter a season name (Spring, Summer, Autumn, Winter): ");
            string input = Console.ReadLine();

            if (Enum.TryParse<Season>(input, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring:
                        Console.WriteLine("Spring is from March to May");
                        break;
                    case Season.Summer:
                        Console.WriteLine("Summer is from June to August");
                        break;
                    case Season.Autumn:
                        Console.WriteLine("Autumn is from September to November");
                        break;
                    case Season.Winter:
                        Console.WriteLine("Winter is from December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("that's not a valid season name");
            }

            Console.WriteLine();
        }


        //====================================================
        // E4 - Permissions enum, add/remove/check permissions on a variable
        static void E4()
        {
            Console.WriteLine("E4:");

            // Permissions is marked [Flags] so we can combine values with the
            // bitwise OR operator and store more than one permission at once
            Permissions perms = Permissions.Read | Permissions.Write;
            Console.WriteLine("starting permissions: " + perms);

            // add a permission with OR
            perms = perms | Permissions.Delete;
            Console.WriteLine("after adding Delete: " + perms);

            // remove a permission with AND + NOT
            perms = perms & ~Permissions.Write;
            Console.WriteLine("after removing Write: " + perms);

            // check if a permission exists with AND
            bool hasExecute = (perms & Permissions.Execute) == Permissions.Execute;
            Console.WriteLine("has Execute permission? " + hasExecute);

            bool hasRead = (perms & Permissions.Read) == Permissions.Read;
            Console.WriteLine("has Read permission? " + hasRead);

            Console.WriteLine();
        }


        //====================================================
        // E5 - Colors enum, check if input color is a primary color
        static void E5()
        {
            Console.WriteLine("E5:");

            Console.Write("enter a color name (Red, Green, Blue): ");
            string input = Console.ReadLine();

            if (Enum.TryParse<Colors>(input, true, out Colors color))
            {
                // all three members of this enum happen to be primary colors
                Console.WriteLine(color + " is a primary color");
            }
            else
            {
                Console.WriteLine(input + " is not one of the basic colors in this enum");
            }

            Console.WriteLine();
        }


        //====================================================
        // E6 - Point struct, distance between two points
        static void E6()
        {
            Console.WriteLine("E6:");

            Point p1 = ReadPoint("first");
            Point p2 = ReadPoint("second");

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

            Console.WriteLine("distance between the two points = " + distance);

            Console.WriteLine();
        }

        static Point ReadPoint(string label)
        {
            Point p = new Point();

            Console.Write("enter X of the " + label + " point: ");
            p.X = Convert.ToDouble(Console.ReadLine());

            Console.Write("enter Y of the " + label + " point: ");
            p.Y = Convert.ToDouble(Console.ReadLine());

            return p;
        }


        //====================================================
        // E7 - Person struct, 3 persons input from user, show the oldest
        static void E7()
        {
            Console.WriteLine("E7:");

            Person[] people = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("enter name of person " + (i + 1) + ": ");
                string name = Console.ReadLine();

                Console.Write("enter age of person " + (i + 1) + ": ");
                int age = Convert.ToInt32(Console.ReadLine());

                people[i] = new Person { Name = name, Age = age };
            }

            Person oldest = people[0];
            foreach (Person p in people)
            {
                if (p.Age > oldest.Age)
                {
                    oldest = p;
                }
            }

            Console.WriteLine("the oldest person is " + oldest.Name + ", age " + oldest.Age);

            Console.WriteLine();
        }
    }
}
