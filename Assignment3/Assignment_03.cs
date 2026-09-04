using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3
{
    class Assignment_03
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("=== C# Assignment 3 ===");
                Console.WriteLine(" 1  - Divisible by 3 and 4");
                Console.WriteLine(" 2  - Positive or Negative");
                Console.WriteLine(" 3  - Max and Min of 3 numbers");
                Console.WriteLine(" 4  - Even or Odd");
                Console.WriteLine(" 5  - Vowel or Consonant");
                Console.WriteLine(" 6  - Print numbers 1 to n");
                Console.WriteLine(" 7  - Multiplication table up to 12");
                Console.WriteLine(" 8  - Even numbers 1 to n");
                Console.WriteLine(" 9  - Power (a^b)");
                Console.WriteLine("10  - Marks: total, average, percentage");
                Console.WriteLine("11  - Days in month");
                Console.WriteLine("12  - Simple calculator");
                Console.WriteLine("13  - Reverse a string");
                Console.WriteLine("14  - Reverse an integer");
                Console.WriteLine("15  - Prime numbers in a range");
                Console.WriteLine("16  - Decimal to binary (no array)");
                Console.WriteLine("17  - Check if 3 points are collinear");
                Console.WriteLine("18  - Worker efficiency");
                Console.WriteLine("19  - Identity matrix");
                Console.WriteLine("20  - Sum of array elements");
                Console.WriteLine("21  - Merge two sorted arrays");
                Console.WriteLine("22  - Frequency of each element");
                Console.WriteLine("23  - Max and Min in an array");
                Console.WriteLine("24  - Second largest element");
                Console.WriteLine("25  - Longest distance between equal cells");
                Console.WriteLine("26  - Reverse order of words");
                Console.WriteLine("27  - Copy multidimensional array");
                Console.WriteLine("28  - Print 1D array in reverse");
                Console.WriteLine(" 0  - Exit");
                Console.Write("Choose an exercise: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": Problem1(); break;
                    case "2": Problem2(); break;
                    case "3": Problem3(); break;
                    case "4": Problem4(); break;
                    case "5": Problem5(); break;
                    case "6": Problem6(); break;
                    case "7": Problem7(); break;
                    case "8": Problem8(); break;
                    case "9": Problem9(); break;
                    case "10": Problem10(); break;
                    case "11": Problem11(); break;
                    case "12": Problem12(); break;
                    case "13": Problem13(); break;
                    case "14": Problem14(); break;
                    case "15": Problem15(); break;
                    case "16": Problem16(); break;
                    case "17": Problem17(); break;
                    case "18": Problem18(); break;
                    case "19": Problem19(); break;
                    case "20": Problem20(); break;
                    case "21": Problem21(); break;
                    case "22": Problem22(); break;
                    case "23": Problem23(); break;
                    case "24": Problem24(); break;
                    case "25": Problem25(); break;
                    case "26": Problem26(); break;
                    case "27": Problem27(); break;
                    case "28": Problem28(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        // 1- Write a program that takes a number from the user then print yes if
        // that number can be divided by 3 and 4 otherwise print no.
        static void Problem1()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine((n % 3 == 0 && n % 4 == 0) ? "Yes" : "No");
        }

        // 2- Write a program that allows the user to insert an integer then print
        // negative if it is negative number otherwise print positive.
        static void Problem2()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n < 0 ? "negative" : "positive");
        }

        // 3- Write a program that takes 3 integers from the user then prints the max
        // element and the min element.
        static void Problem3()
        {
            Console.Write("Enter three integers separated by space: ");
            var parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(parts[0]);
            int b = int.Parse(parts[1]);
            int c = int.Parse(parts[2]);

            int max = Math.Max(a, Math.Max(b, c));
            int min = Math.Min(a, Math.Min(b, c));

            Console.WriteLine("max element = " + max);
            Console.WriteLine("min element = " + min);
        }

        // 4- Write a program that allows the user to insert an integer number then
        // check if a number is even or odd.
        static void Problem4()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n % 2 == 0 ? "Even" : "Odd");
        }

        // 5- Write a program that takes a character from the user then if it is a
        // vowel char (a, e, i, o, u) then print (vowel) otherwise print (consonant).
        static void Problem5()
        {
            Console.Write("Enter a character: ");
            char c = char.ToLower(Console.ReadLine().Trim()[0]);
            if ("aeiou".IndexOf(c) >= 0)
                Console.WriteLine("vowel");
            else
                Console.WriteLine("Consonant");
        }

        // 6- Write a program that allows the user to insert an integer then print
        // all numbers between 1 to that number.
        static void Problem6()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            var nums = new List<string>();
            for (int i = 1; i <= n; i++)
                nums.Add(i.ToString());
            Console.WriteLine(string.Join(", ", nums));
        }

        // 7- Write a program that allows the user to insert an integer then
        // print a multiplication table up to 12.
        static void Problem7()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            var results = new List<string>();
            for (int i = 1; i <= 12; i++)
                results.Add((n * i).ToString());
            Console.WriteLine(string.Join(" ", results));
        }

        // 8- Write a program that allows the user to insert a number then print
        // all even numbers between 1 to this number.
        static void Problem8()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            var evens = new List<string>();
            for (int i = 1; i <= n; i++)
                if (i % 2 == 0)
                    evens.Add(i.ToString());
            Console.WriteLine(string.Join(" ", evens));
        }

        // 9- Write a program that takes two integers then prints the power.
        static void Problem9()
        {
            Console.Write("Enter base and exponent separated by space: ");
            var parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int baseNum = int.Parse(parts[0]);
            int exponent = int.Parse(parts[1]);

            long result = 1;
            for (int i = 0; i < exponent; i++)
                result *= baseNum;

            Console.WriteLine(result);
        }

        // 10- Write a program to enter marks of five subjects and calculate total,
        // average and percentage.
        static void Problem10()
        {
            Console.Write("Enter Marks of five subjects: ");
            var parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int total = 0;
            foreach (var p in parts)
                total += int.Parse(p);

            double average = total / 5.0;
            double percentage = (total / 500.0) * 100;

            Console.WriteLine("Total marks = " + total);
            Console.WriteLine("Average Marks = " + average);
            Console.WriteLine("Percentage = " + percentage);
        }

        // 11- Write a program to input the month number and print the number of days
        // in that month.
        static void Problem11()
        {
            Console.Write("Enter Month Number: ");
            int m = int.Parse(Console.ReadLine());
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (m >= 1 && m <= 12)
                Console.WriteLine("Days in Month: " + days[m - 1]);
            else
                Console.WriteLine("Invalid month number.");
        }

        // 12- Write a program to create a Simple Calculator.
        static void Problem12()
        {
            Console.Write("Enter first number: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter an operator (+, -, *, /): ");
            char op = Console.ReadLine().Trim()[0];
            Console.Write("Enter second number: ");
            double b = double.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("Result = " + (a + b));
                    break;
                case '-':
                    Console.WriteLine("Result = " + (a - b));
                    break;
                case '*':
                    Console.WriteLine("Result = " + (a * b));
                    break;
                case '/':
                    if (b == 0)
                        Console.WriteLine("Error: Division by zero.");
                    else
                        Console.WriteLine("Result = " + (a / b));
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }
        }

        // 13- Write a program to allow the user to enter a string and print the
        // REVERSE of it.
        static void Problem13()
        {
            Console.Write("Enter a string: ");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }

        // 14- Write a program to allow the user to enter an int and print the
        // REVERSED of it.
        static void Problem14()
        {
            Console.Write("Enter an integer: ");
            int n = int.Parse(Console.ReadLine());
            bool isNegative = n < 0;
            n = Math.Abs(n);

            int reversed = 0;
            while (n > 0)
            {
                reversed = reversed * 10 + n % 10;
                n /= 10;
            }

            if (isNegative)
                reversed = -reversed;

            Console.WriteLine(reversed);
        }

        // 15- Write a program in C# to find prime numbers within a range of numbers.
        static void Problem15()
        {
            Console.Write("Input starting number of range: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Input ending number of range: ");
            int end = int.Parse(Console.ReadLine());

            Console.WriteLine($"The prime numbers between {start} and {end} are :");
            var primes = new List<string>();

            for (int num = Math.Max(start, 2); num <= end; num++)
            {
                bool isPrime = true;
                for (int d = 2; d * d <= num; d++)
                {
                    if (num % d == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    primes.Add(num.ToString());
            }

            Console.WriteLine(string.Join(" ", primes));
        }

        // 16- Write a program in C# to convert a decimal number into binary
        // without using an array.
        static void Problem16()
        {
            Console.Write("Enter a number to convert: ");
            int n = int.Parse(Console.ReadLine());
            int original = n;
            string binary = "";

            if (n == 0)
            {
                binary = "0";
            }
            else
            {
                while (n > 0)
                {
                    binary = (n % 2) + binary;
                    n /= 2;
                }
            }

            Console.WriteLine($"The Binary of {original} is {binary}.");
        }

        // 17- Create a program that asks the user to input three points (x1, y1),
        // (x2, y2), and (x3, y3), and determines whether these points lie on a
        // single straight line.
        static void Problem17()
        {
            Console.Write("Enter x1 y1: ");
            var p1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double x1 = double.Parse(p1[0]), y1 = double.Parse(p1[1]);

            Console.Write("Enter x2 y2: ");
            var p2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double x2 = double.Parse(p2[0]), y2 = double.Parse(p2[1]);

            Console.Write("Enter x3 y3: ");
            var p3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double x3 = double.Parse(p3[0]), y3 = double.Parse(p3[1]);

            // Area of the triangle formed by the 3 points (times 2).
            // If the area is 0, the points are collinear.
            double area = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);

            if (Math.Abs(area) < 1e-9)
                Console.WriteLine("The points lie on a single straight line.");
            else
                Console.WriteLine("The points do NOT lie on a single straight line.");
        }

        // 18- Within a company, the efficiency of workers is evaluated based on the
        // duration required to complete a specific task (highly efficient, increase
        // speed, needs training, or must leave the company).
        static void Problem18()
        {
            Console.Write("Enter the time taken for the task (in hours): ");
            double t = double.Parse(Console.ReadLine());

            if (t >= 2 && t <= 3)
                Console.WriteLine("Highly efficient.");
            else if (t > 3 && t <= 4)
                Console.WriteLine("Instructed to increase speed.");
            else if (t > 4 && t <= 5)
                Console.WriteLine("Provided with training to enhance speed.");
            else if (t > 5)
                Console.WriteLine("Required to leave the company.");
            else
                Console.WriteLine("Invalid time entered.");
        }

        // 19- Write a program that prints an identity matrix using a for loop,
        // taking a value n from the user and showing the identity table of size n * n.
        static void Problem19()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write((i == j ? 1 : 0) + " ");
                }
                Console.WriteLine();
            }
        }

        // 20- Write a program in C# to find the sum of all elements of the array.
        static void Problem20()
        {
            int[] arr = ReadArray();
            int sum = 0;
            foreach (int x in arr)
                sum += x;
            Console.WriteLine("Sum = " + sum);
        }

        // 21- Write a program in C# to merge two arrays of the same size
        // sorted in ascending order.
        static void Problem21()
        {
            Console.Write("Enter size of the arrays: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter " + n + " sorted elements for the first array, separated by space:");
            var p1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[n];
            for (int i = 0; i < n; i++) a[i] = int.Parse(p1[i]);

            Console.WriteLine("Enter " + n + " sorted elements for the second array, separated by space:");
            var p2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] b = new int[n];
            for (int i = 0; i < n; i++) b[i] = int.Parse(p2[i]);

            int[] merged = new int[2 * n];
            int x = 0, y = 0, k = 0;

            while (x < n && y < n)
            {
                if (a[x] <= b[y]) merged[k++] = a[x++];
                else merged[k++] = b[y++];
            }
            while (x < n) merged[k++] = a[x++];
            while (y < n) merged[k++] = b[y++];

            Console.WriteLine("Merged sorted array: " + string.Join(" ", merged));
        }

        // 22- Write a program in C# to count the frequency of each element of an array.
        static void Problem22()
        {
            int[] arr = ReadArray();
            var freq = new Dictionary<int, int>();

            foreach (int x in arr)
            {
                if (freq.ContainsKey(x)) freq[x]++;
                else freq[x] = 1;
            }

            foreach (var kv in freq)
                Console.WriteLine(kv.Key + " occurs " + kv.Value + " time(s)");
        }

        // 23- Write a program in C# to find maximum and minimum element in an array.
        static void Problem23()
        {
            int[] arr = ReadArray();
            int max = arr[0], min = arr[0];

            foreach (int x in arr)
            {
                if (x > max) max = x;
                if (x < min) min = x;
            }

            Console.WriteLine("Max element = " + max);
            Console.WriteLine("Min element = " + min);
        }

        // 24- Write a program in C# to find the second largest element in an array.
        static void Problem24()
        {
            int[] arr = ReadArray();
            int first = int.MinValue, second = int.MinValue;

            foreach (int x in arr)
            {
                if (x > first)
                {
                    second = first;
                    first = x;
                }
                else if (x > second && x != first)
                {
                    second = x;
                }
            }

            if (second == int.MinValue)
                Console.WriteLine("There is no distinct second largest element.");
            else
                Console.WriteLine("Second largest element = " + second);
        }

        // 25- Given an array of integer values, find the longest distance between
        // two equal cells (measured by the number of cells between them).
        static void Problem25()
        {
            int[] arr = ReadArray();
            int maxDist = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        int dist = j - i - 1; // number of cells between i and j
                        if (dist > maxDist) maxDist = dist;
                    }
                }
            }

            Console.WriteLine("The longest distance is " + maxDist);
        }

        // 26- Given a list of space separated words, reverse the order of the words.
        static void Problem26()
        {
            Console.Write("Enter a sentence: ");
            string s = Console.ReadLine();
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            Console.WriteLine(string.Join(" ", words));
        }

        // 27- Write a program to create two multidimensional arrays of the same
        // size, accept values from the user into the first array, then copy all
        // elements of the first array into the second array and print it.
        static void Problem27()
        {
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] first = new int[rows, cols];
            Console.WriteLine("Enter elements for the first array:");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Element[{i},{j}]: ");
                    first[i, j] = int.Parse(Console.ReadLine());
                }

            int[,] second = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    second[i, j] = first[i, j];

            Console.WriteLine("Second array (copied):");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(second[i, j] + " ");
                Console.WriteLine();
            }
        }

        // 28- Write a Program to Print One Dimensional Array in Reverse Order.
        static void Problem28()
        {
            int[] arr = ReadArray();
            for (int i = arr.Length - 1; i >= 0; i--)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Helper method used by several array-based exercises to read
        // an array's size and its elements from the console.
        static int[] ReadArray()
        {
            Console.Write("Enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter " + n + " elements separated by space:");
            var parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(parts[i]);

            return arr;
        }
    }
}
