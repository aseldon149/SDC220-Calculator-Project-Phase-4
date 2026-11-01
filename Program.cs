/*******************************************************************
 * Name: Anthony Seldon
 * Date: November 1, 2026
 * Assignment: SDC220 Calculator Project - Phase 4
 *
 * Main application class.
 * This program performs division and demonstrates exception
 * handling for division by zero and invalid numeric input.
 *******************************************************************/

using System;

public class CalculatorPhase4
{
    static void Main(string[] args)
    {
        DisplayHeader();
        DisplayWelcome();

        bool running = true;

        while (running)
        {
            DisplayMenu();

            Console.Write("Select an option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1":
                    PerformDivision();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    Console.WriteLine(
                        "Invalid selection. Please choose 1 or 0.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Thank you for using the calculator!");
    }

    static void DisplayHeader()
    {
        Console.WriteLine(
            "Anthony Seldon - Week 4 Calculator Project - Phase 4");
        Console.WriteLine();
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("This program divides one number by another.");
        Console.WriteLine(
            "Enter two numeric values to calculate the result.");
        Console.WriteLine(
            "If an error occurs, you will be able to try again.");
        Console.WriteLine();
    }

    static void DisplayMenu()
    {
        Console.WriteLine("===== CALCULATOR MENU =====");
        Console.WriteLine("1. Divide two numbers");
        Console.WriteLine("0. Quit");
        Console.WriteLine();
    }

    static void PerformDivision()
    {
        bool completed = false;

        while (!completed)
        {
            try
            {
                Console.Write("Enter the first number: ");
                string? input = Console.ReadLine();
                double firstNumber = Convert.ToDouble(input);

                Console.Write("Enter the second number: ");
                input = Console.ReadLine();
                double secondNumber = Convert.ToDouble(input);

                if (secondNumber == 0)
                {
                    throw new DivideByZeroException(
                        "Division by zero is not allowed.");
                }

                double result = firstNumber / secondNumber;

                Console.WriteLine(
                    "\nResult: {0} / {1} = {2}",
                    firstNumber, secondNumber, result);

                completed = true;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("\nException: {0}", e);
                Console.WriteLine(
                    "Cannot divide by zero. Please enter a different value.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("\nException: {0}", e);
                Console.WriteLine(
                    "Invalid input. Please enter numeric values.");
            }

            Console.WriteLine();
        }
    }
}