using System;

namespace Assignment2
{
    // ---------- enum used below ----------

    // Part 4 - the four security privilege levels an employee can have
    enum SecurityLevel { Guest, Developer, Secretary, DBA }


    //====================================================
    // Part 2 - HiringDate class: just day/month/year plus safety checks
    // so a bad value never sneaks in and blows up later
    class HiringDate
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set
            {
                // keep it inside a sane range, if its invalid just fall back
                // to 1 instead of letting a broken date cause problems later
                if (value >= 1 && value <= 31)
                    day = value;
                else
                    day = 1;
            }
        }

        public int Month
        {
            get { return month; }
            set
            {
                if (value >= 1 && value <= 12)
                    month = value;
                else
                    month = 1;
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                // any reasonable year is fine, just guard against obviously wrong values
                if (value >= 1900 && value <= 2100)
                    year = value;
                else
                    year = 2000;
            }
        }

        // default constructor
        public HiringDate()
        {
            day = 1;
            month = 1;
            year = 2000;
        }

        // parameterized constructor, goes through the properties so the
        // validation above still applies
        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }
    }


    //====================================================
    // Part 1, 3, 5 - Employee class
    class Employee
    {
        private int id;
        private string name;
        private SecurityLevel securityLevel;
        private double salary;
        private HiringDate hireDate;
        private char gender;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                // dont allow a null/empty name to sneak in
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    name = "Unknown";
            }
        }

        public SecurityLevel SecurityLevel
        {
            get { return securityLevel; }
            set { securityLevel = value; }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                // salary cant be negative, clamp instead of crashing
                if (value >= 0)
                    salary = value;
                else
                    salary = 0;
            }
        }

        public HiringDate HireDate
        {
            get { return hireDate; }
            set { hireDate = (value != null) ? value : new HiringDate(); }
        }

        // Part 3 - restrict Gender to only M or F
        public char Gender
        {
            get { return gender; }
            set
            {
                char g = char.ToUpper(value);
                if (g == 'M' || g == 'F')
                    gender = g;
                else
                    gender = 'M'; // invalid input just falls back to a default,
                                  // never throws
            }
        }

        // default constructor
        public Employee()
        {
            id = 0;
            Name = "Unknown";
            securityLevel = SecurityLevel.Guest;
            Salary = 0;
            hireDate = new HiringDate();
            Gender = 'M';
        }

        // full constructor, goes through the properties so all the same
        // validation rules apply here too
        public Employee(int id, string name, SecurityLevel securityLevel, double salary, HiringDate hireDate, char gender)
        {
            this.id = id;
            Name = name;
            this.securityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        // Part 5 - override ToString to show all employee info as a string,
        // salary printed in currency format with String.Format
        public override string ToString()
        {
            return "ID: " + id +
                   ", Name: " + name +
                   ", Security Level: " + securityLevel +
                   ", Salary: " + String.Format("{0:C}", salary) +
                   ", Hire Date: " + hireDate.ToString() +
                   ", Gender: " + gender;
        }
    }


    class Assignment_02
    {
        static void Main(string[] args)
        {
            Part1();

            Console.ReadKey();
        }


        //====================================================
        // Part 1 & 6 - array of 3 employees: a DBA, a Guest, and a third
        // employee who is a security officer with full permissions
        // (this enum's top level, DBA, is the "full permissions" level, so
        // that's what the security officer gets too, even though their job
        // title is different from the DBA employee)
        static void Part1()
        {
            Console.WriteLine("Employees:");

            Employee[] empArr = new Employee[3];

            empArr[0] = new Employee(1, "Mona Khaled", SecurityLevel.DBA, 15000, new HiringDate(12, 3, 2019), 'F');
            empArr[1] = new Employee(2, "Youssef Adel", SecurityLevel.Guest, 4000, new HiringDate(5, 9, 2023), 'M');
            empArr[2] = new Employee(3, "Hassan Security Officer", SecurityLevel.DBA, 12000, new HiringDate(1, 1, 2021), 'M');

            foreach (Employee emp in empArr)
            {
                Console.WriteLine(emp.ToString());
            }

            Console.WriteLine();

            // quick demo that user input never crashes the program: try a
            // couple of "bad" values through the properties directly and
            // show they get cleaned up instead of throwing
            Console.WriteLine("Robustness check (deliberately bad values):");

            Employee test = new Employee();
            test.Gender = 'x';      // not M or F
            test.Salary = -500;     // negative
            test.HireDate = new HiringDate(40, 15, 1800); // out of range day/month/year

            Console.WriteLine(test.ToString());

            Console.WriteLine();
        }
    }
}
