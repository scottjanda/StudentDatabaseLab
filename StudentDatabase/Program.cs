
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

string[] name = { "Adam", "Barb", "Chris" };
string[] hometown = { "Atlanta","Boston", "Cleveland"};
string[] favoriteFood = { "Avacado Toast", "Buritos","Clam Chowder"};
//int maxNameLength = name.OrderByDescending(s => s.Length).First().Length;

string userContinue = "y";
do
{
    Console.Write($"To learn about a student, please Enter a number 1 - {name.Length} or enter a student name to search by name. You may also enter \"list\" to see a list of all students:");
    string inputCheck = Console.ReadLine();

    if (inputCheck.Trim().ToLower().StartsWith("list"))
    {
        Console.WriteLine("\nHere is a list of all students:\n");
        for (int i = 0; i < name.Length; i++)
        {
            Console.WriteLine($"{name[i]}");
        }
        Console.WriteLine();
        continue;
    }

    bool validNumber = int.TryParse(inputCheck, out int userInput);
    Console.WriteLine();

    if (validNumber == false)
    {


        int counter = 0;
        do
        {


        foreach (var item in name)
        {
            //if (inputCheck.Trim().ToLower().Contains(item.ToLower()))
            if (inputCheck.Trim().ToLower().Contains(item.ToLower().Remove(item.Length - counter))) //doest work with single character string
            {
                userInput = Array.IndexOf(name, item) + 1;
            }
        }

        counter += 1;

        } while (counter <= inputCheck.Length);


    }

    if (userInput > name.Length || userInput < 1)
    {
        Console.WriteLine($"That number is not between 1 and {name.Length}!");
        Console.WriteLine();
        continue;
    }

        bool loopContinue = false;
        do
        {
            Console.WriteLine($"Student {userInput} is {name[userInput - 1]}. What would you like to know? Enter hometown or favorite food:");
            string userInput2 = Console.ReadLine();
            
            if (userInput2.Trim().ToLower().StartsWith("hometown"))
            {
                Console.WriteLine($"{name[userInput - 1]} is from {hometown[userInput - 1]}");
            }
            else if (userInput2.Trim().ToLower().StartsWith("favorite"))
            {
                Console.WriteLine($"{name[userInput - 1]} likes to eat {favoriteFood[userInput - 1]}");
            }
            else
            {
                Console.WriteLine("That is not a valid category.");
                Console.WriteLine();
                loopContinue = true;
            }

        } while (loopContinue);

        Console.WriteLine("Would you like to learn about another student? Enter \"y\" or \"n\":");
        userContinue = Console.ReadLine();
        Console.Clear();
    
    } while (userContinue.ToLower() == "y");

Console.WriteLine("Thanks!");
