using System;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose which task would you like to test:");
                Console.WriteLine("1) Task 1: Arrays");
                Console.WriteLine("2) Task 2: Fibonacci & Power");
                Console.WriteLine("3) Task 3: Phonebook");
                Console.WriteLine("4) Task 4: Shapes");
                Console.WriteLine("0) Exit");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void Task1()
        {
            Console.WriteLine("Task 1 part a: Find a sum of numbers on main diagonal in an array");
            Console.WriteLine("Task 1 part b: Find a sum of numbers in an array that can be divided by three ");
            Console.WriteLine("Set array size");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Console.WriteLine("Fill array values (one by one)");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Resulting array:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int diagonalSum = 0;
            for (int i = 0; i < n; i++)
            {
                diagonalSum += matrix[i, i];
            }
            Console.WriteLine("Sum of main diagonal: " + diagonalSum);

            int divisibleByThreeSum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] % 3 == 0)
                    {
                        divisibleByThreeSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine("Sum of numbers that can be divided by three: " + divisibleByThreeSum);
        }

        static void Task2()
        {
            while (true)
            {
                Console.WriteLine("\nTask 2: Recursive Algorithms");
                Console.WriteLine("1) Find a number in Fibonacci sequence");
                Console.WriteLine("2) Raise a number to a power");
                Console.WriteLine("0) Exit Task 2");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter position in Fibonacci sequence: ");
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            Console.WriteLine($"Fibonacci number at position {n} = {Fibonacci(n)}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter base number: ");
                        if (!int.TryParse(Console.ReadLine(), out int baseNumber))
                        {
                            Console.WriteLine("Invalid base.");
                            break;
                        }

                        Console.Write("Enter power: ");
                        if (!int.TryParse(Console.ReadLine(), out int power))
                        {
                            Console.WriteLine("Invalid power.");
                            break;
                        }

                        Console.WriteLine($"{baseNumber}^{power} = {Power(baseNumber, power)}");
                        break;

                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }

        static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static int Power(int baseNumber, int power)
        {
            if (power == 0) return 1;
            return baseNumber * Power(baseNumber, power - 1);
        }

        static void Task3()
        {
            var book = new HashPhoneBook();
            Console.WriteLine("Task 3: Phonebook");
            while (true)
            {
                Console.WriteLine("\nChoose option:");
                Console.WriteLine("1) Add/Update contact");
                Console.WriteLine("2) Delete contact");
                Console.WriteLine("3) Edit contact number");
                Console.WriteLine("4) Find number by name");
                Console.WriteLine("5) Print all");
                Console.WriteLine("0) Exit Task 3");
                Console.Write("Choose: ");

                var choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        var name1 = Console.ReadLine();
                        Console.Write("Number: ");
                        var number1 = Console.ReadLine();
                        book.AddOrUpdate(name1, number1);
                        Console.WriteLine("Saved.");
                        break;

                    case "2":
                        Console.Write("Name to delete: ");
                        var del = Console.ReadLine();
                        Console.WriteLine(book.Remove(del) ? "Deleted." : "Not found.");
                        break;

                    case "3":
                        Console.Write("Name to edit: ");
                        var name3 = Console.ReadLine();
                        Console.Write("New number: ");
                        var newNum = Console.ReadLine();
                        Console.WriteLine(book.Edit(name3, newNum) ? "Updated." : "Not found.");
                        break;

                    case "4":
                        Console.Write("Name to find: ");
                        var find = Console.ReadLine();
                        if (book.TryGet(find, out var num))
                            Console.WriteLine($"Number: {num}");
                        else
                            Console.WriteLine("Not found.");
                        break;

                    case "5":
                        book.PrintAll();
                        break;

                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }

        static void Task4()
        {
            Console.WriteLine("Task 4: Shapes");

            while (true)
            {
                Console.WriteLine("\nChoose a shape:");
                Console.WriteLine("1) Rectangle");
                Console.WriteLine("2) Square");
                Console.WriteLine("3) Rhombus");
                Console.WriteLine("4) Parallelogram");
                Console.WriteLine("5) Circle");
                Console.WriteLine("0) Exit Task 4");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                Shape shape = null;

                switch (choice)
                {
                    case "1": // Rectangle
                        Console.Write("Enter width: ");
                        double rectWidth = double.Parse(Console.ReadLine());

                        Console.Write("Enter height: ");
                        double rectHeight = double.Parse(Console.ReadLine());

                        shape = new Rectangle("Rectangle", rectWidth, rectHeight);
                        break;

                    case "2": // Square
                        Console.Write("Enter side length: ");
                        double squareSide = double.Parse(Console.ReadLine());

                        shape = new Square("Square", squareSide);
                        break;

                    case "3": // Rhombus
                        Console.Write("Enter side length: ");
                        double rhombusSide = double.Parse(Console.ReadLine());

                        Console.Write("Enter angle in degrees: ");
                        double rhombusAngle = double.Parse(Console.ReadLine());

                        shape = new Rhombus("Rhombus", rhombusSide, rhombusAngle);
                        break;

                    case "4": // Parallelogram
                        Console.Write("Enter base length: ");
                        double baseLength = double.Parse(Console.ReadLine());

                        Console.Write("Enter side length: ");
                        double sideLength = double.Parse(Console.ReadLine());

                        Console.Write("Enter angle in degrees: ");
                        double angle = double.Parse(Console.ReadLine());

                        shape = new Parallelogram("Parallelogram", baseLength, sideLength, angle);
                        break;

                    case "5": // Circle
                        Console.Write("Enter radius: ");
                        double radius = double.Parse(Console.ReadLine());

                        shape = new Circle("Circle", radius);
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (shape != null)
                {
                    Console.WriteLine($"\n{shape.Name}:");
                    if (!shape.IsValid())
                    {
                        Console.WriteLine("  Invalid dimensions!");
                    }
                    else
                    {
                        Console.WriteLine($"  Area = {shape.GetArea():F2}");
                        Console.WriteLine($"  Perimeter = {shape.GetPerimeter():F2}");
                    }
                }
            }
        }
    }


    
}
