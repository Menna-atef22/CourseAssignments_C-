using System;

namespace Assignment3
{
    //====================================================
    // PART 1 - Static Binding (method hiding with "new")
    //====================================================

    // Q1
    class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return "(Width = " + Width + ", Height = " + Height + ")";
        }
    }

    // Q2
    class Cube : Shape
    {
        public double Depth { get; set; }

        public Cube(double width, double height, double depth) : base(width, height)
        {
            Depth = depth;
        }

        // "new" hides the base Area() instead of overriding it. this only
        // matters when the object is accessed through a Shape reference,
        // because "new" is resolved by the compile-time (declared) type,
        // not the actual runtime type
        public new double Area()
        {
            return base.Area() * Depth;
        }

        public void Print()
        {
            Console.WriteLine("Width = " + Width + ", Height = " + Height + ", Depth = " + Depth);
        }
    }


    //====================================================
    // PART 2 - Dynamic Binding (virtual / override)
    //====================================================

    // Q5
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // non-virtual, so this can only be hidden with "new", never overridden
        public void Greet()
        {
            Console.WriteLine("I am a Person.");
        }

        // virtual, so derived classes are allowed to override it and have
        // the derived version run even through a base reference
        public virtual void Display()
        {
            Console.WriteLine("ID: " + ID + ", Name: " + Name + ", Age: " + Age);
        }
    }

    // Q6
    class Doctor : Person
    {
        public string Specialty { get; set; }

        // Greet() isn't virtual in Person, so the only option here is to
        // hide it with new, we cannot use override on it
        public new void Greet()
        {
            Console.WriteLine("I am a Doctor.");
        }

        public override void Display()
        {
            Console.WriteLine("ID: " + ID + ", Name: " + Name + ", Age: " + Age + ", Specialty: " + Specialty);
        }
    }

    class Engineer : Person
    {
        public string Field { get; set; }
        public int YearsOfExperience { get; set; }

        public new void Greet()
        {
            Console.WriteLine("I am an Engineer.");
        }

        public override void Display()
        {
            Console.WriteLine("ID: " + ID + ", Name: " + Name + ", Age: " + Age +
                               ", Field: " + Field + ", YearsOfExperience: " + YearsOfExperience);
        }
    }


    //====================================================
    // PART 3 - Interfaces
    //====================================================

    // Q10
    interface IMoveable
    {
        void MoveForward();
        void MoveBackward();
    }

    interface IFlyable
    {
        void MoveUp();
        void MoveDown();
    }

    // Q11
    class Car : IMoveable
    {
        public void MoveForward()
        {
            Console.WriteLine("Car is moving forward on the ground.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Car is moving backward on the ground.");
        }
    }

    // Q14 - Ship implements MoveForward() explicitly, just to show what that
    // looks like and how it changes the way you're allowed to call it
    class Ship : IMoveable
    {
        // explicit interface implementation: no access modifier, and the
        // interface name is part of the method name
        void IMoveable.MoveForward()
        {
            Console.WriteLine("Ship is moving forward across the sea.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Ship is moving backward across the sea.");
        }
    }

    class Airplane : IMoveable, IFlyable
    {
        public void MoveForward()
        {
            Console.WriteLine("Airplane is moving forward through the air.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Airplane is moving backward through the air.");
        }

        public void MoveUp()
        {
            Console.WriteLine("Airplane is climbing up.");
        }

        public void MoveDown()
        {
            Console.WriteLine("Airplane is descending.");
        }
    }

    // Q13 - an interface can inherit other interfaces without adding any
    // members of its own, it just bundles them together under one name
    interface IVehicle : IMoveable, IFlyable
    {
    }

    class Vehicle : IVehicle
    {
        // marking these virtual (even though interface members can't be
        // virtual by themselves) lets a class that inherits from Vehicle
        // override them later if it needs its own behavior
        public virtual void MoveForward()
        {
            Console.WriteLine("Vehicle is moving forward.");
        }

        public virtual void MoveBackward()
        {
            Console.WriteLine("Vehicle is moving backward.");
        }

        public virtual void MoveUp()
        {
            Console.WriteLine("Vehicle is moving up.");
        }

        public virtual void MoveDown()
        {
            Console.WriteLine("Vehicle is moving down.");
        }
    }


    class Assignment_03
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
            Part3();
            Theory();

            Console.ReadKey();
        }


        //====================================================
        // Q3, Q4 - static binding demo
        static void Part1()
        {
            Console.WriteLine("Part 1 - Static Binding:");

            Shape shape = new Shape(2, 3);
            Console.WriteLine("shape.Area() = " + shape.Area()); // 6

            Cube cube = new Cube(2, 3, 4);
            Console.WriteLine("cube.Area() = " + cube.Area()); // 24, uses Cube's own Area()

            // Q3 - Shape reference pointing at a Cube object
            Shape shapeRef = new Cube(2, 3, 4);
            Console.WriteLine("shapeRef.Area() = " + shapeRef.Area());
            // prints 6, NOT 24. even though the object is really a Cube, Area()
            // was hidden with "new" instead of overridden, so which version runs
            // is decided by the declared type of the variable (Shape) at compile
            // time, not by the actual object at runtime. that's exactly what
            // "static/early binding" means: the compiler bakes in the call to
            // Shape.Area() when it compiles this line, because as far as the
            // compiler is concerned shapeRef is a Shape

            // Q4 - ToString() behaves differently because Shape.ToString() is an
            // override of object.ToString(), which IS virtual. Cube never redefines
            // ToString(), so it just inherits Shape's overridden version and that
            // stays polymorphic
            object obj = new Cube(1, 2, 3);
            Console.WriteLine("obj.ToString() = " + obj.ToString());
            // this prints the Shape-style "(Width = ..., Height = ...)" string
            // because ToString() is virtual all the way from object, so the call
            // is resolved at runtime based on the actual object type (late/dynamic
            // binding), unlike Area() above. that's why ToString() "follows" the
            // real object but Area() does not - virtual/override methods look at
            // the runtime type, new-hidden methods look at the compile-time type

            Cube cube2 = new Cube(2, 3, 4);
            cube2.Print();

            Console.WriteLine();
        }


        //====================================================
        // Q7, Q8 - dynamic binding demo
        static void Part2()
        {
            Console.WriteLine("Part 2 - Dynamic Binding:");

            Person doctorAsPerson = new Doctor { ID = 1, Name = "Dr. Amir", Age = 40, Specialty = "Cardiology" };
            Person engineerAsPerson = new Engineer { ID = 2, Name = "Nourhan", Age = 27, Field = "Software", YearsOfExperience = 5 };

            ProcessPerson(doctorAsPerson);
            ProcessPerson(engineerAsPerson);
            // predicted output: Greet() always prints "I am a Person." for both,
            // because Greet() is not virtual - it was hidden with "new" in the
            // derived classes, and "new" only applies when you access the member
            // through the derived type directly. Through a Person reference (which
            // is exactly what ProcessPerson receives as its parameter type), the
            // compiler resolves Greet() to Person.Greet() at compile time - static
            // binding again.
            //
            // Display() on the other hand prints the Doctor/Engineer version for
            // each, because it's virtual in Person and overridden in the derived
            // classes. override methods are resolved at runtime based on the
            // actual object, regardless of the reference type used to call them -
            // that's dynamic/late binding.
            //
            // Q8 - if "virtual" is removed from Person.Display(), then "override"
            // in Doctor/Engineer no longer compiles. C# gives a compiler ERROR
            // (not just a warning): "Doctor.Display(): cannot override inherited
            // member 'Person.Display()' because it is not marked virtual,
            // abstract, or override." The fix the compiler suggests is to use
            // "new" instead - but that changes the behavior back to static
            // binding, so ProcessPerson(Person) would go back to always printing
            // the base Person.Display() no matter what derived object was passed.

            Console.WriteLine();
        }

        static void ProcessPerson(Person person)
        {
            person.Greet();
            person.Display();
        }


        //====================================================
        // Q9, Q12, Q14 - interfaces
        static void Part3()
        {
            Console.WriteLine("Part 3 - Interfaces:");

            // Q9 - before interfaces: if every vehicle class had to implement
            // MoveForward/MoveBackward/MoveUp/MoveDown directly, a Car class
            // would be forced to also write MoveUp() and MoveDown() even
            // though a car can't fly. those methods would either throw, do
            // nothing, or just be silently wrong - forcing unrelated behavior
            // onto a class it doesn't need is exactly the problem interfaces
            // solve, by letting Car implement only the abilities it actually has

            Car car = new Car();
            car.MoveForward();
            car.MoveBackward();

            Ship ship = new Ship();
            // ship.MoveForward(); // this line would NOT compile - see Q14 below
            ship.MoveBackward();

            Airplane airplane = new Airplane();
            airplane.MoveForward();
            airplane.MoveBackward();
            airplane.MoveUp();
            airplane.MoveDown();

            Console.WriteLine();

            // Q12 - calling through interface references
            IMoveable carRef = new Car();
            IMoveable planeRef = new Airplane();

            carRef.MoveForward();
            carRef.MoveBackward();
            planeRef.MoveForward();
            planeRef.MoveBackward();

            // planeRef.MoveUp(); // this would NOT compile either.
            // even though the actual object is an Airplane which does have
            // MoveUp(), the variable planeRef is declared as IMoveable, and
            // IMoveable doesn't know about MoveUp() - it's only declared on
            // IFlyable. to call MoveUp() here you'd need a reference typed as
            // IFlyable (or Airplane itself), e.g.:
            IFlyable flyRef = (IFlyable)planeRef;
            flyRef.MoveUp();
            flyRef.MoveDown();

            Console.WriteLine();

            // Q14 - explicit interface implementation
            // ship.MoveForward() does not compile directly on a Ship variable,
            // because void IMoveable.MoveForward() is only visible through an
            // IMoveable reference, not through the concrete Ship type. you have
            // to go through the interface instead:
            IMoveable shipAsMoveable = ship;
            shipAsMoveable.MoveForward();

            Console.WriteLine();

            // Q13 - IVehicle bundles IMoveable + IFlyable with no extra members,
            // so a class implementing IVehicle is guaranteed to support both
            // movement and flight through a single interface reference, instead
            // of having to reference two separate interface types
            Vehicle vehicle = new Vehicle();
            IVehicle vehicleRef = vehicle;
            vehicleRef.MoveForward();
            vehicleRef.MoveUp();

            Console.WriteLine();
        }


        //====================================================
        // Q15, Q16 - theory
        static void Theory()
        {
            Console.WriteLine("Part 4 - Theory:");

            Console.WriteLine("Q15 comparison table:");
            Console.WriteLine("Feature                     | Static Binding (new)          | Dynamic Binding (override)");
            Console.WriteLine("Keyword in base             | (none needed, or virtual)     | virtual");
            Console.WriteLine("Keyword in derived          | new                            | override");
            Console.WriteLine("Resolved at                 | compile time (declared type)  | run time (actual object type)");
            Console.WriteLine("Behavior via base reference | runs the BASE version          | runs the DERIVED version");
            Console.WriteLine();

            // Q16
            Console.WriteLine("Q16:");
            Console.WriteLine("virtual has to be on the base method before override is allowed because");
            Console.WriteLine("override is a promise to the runtime that this method takes part in dynamic");
            Console.WriteLine("dispatch - the base class has to opt into that by marking the method virtual,");
            Console.WriteLine("otherwise every call to it is just a normal, direct compile-time call and");
            Console.WriteLine("there's no dispatch table entry for a derived class to plug into.");
            Console.WriteLine("new doesn't need any cooperation from the base class because it isn't really");
            Console.WriteLine("overriding anything - it's just declaring a brand new member in the derived");
            Console.WriteLine("class that happens to have the same name, and hiding the base one from view");
            Console.WriteLine("when accessed through the derived type. since it doesn't touch the base");
            Console.WriteLine("class's dispatch behavior at all, it works on any method, virtual or not.");

            Console.WriteLine();
        }
    }
}
