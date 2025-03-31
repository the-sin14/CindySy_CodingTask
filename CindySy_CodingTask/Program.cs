using System.Text;
class Average
{
    // TODO: add comment and create README
    // TODO: clean up code

    // 
    private static double getAverage(List<double> arrayofNums) { 
        double average = 0;

        foreach (var num in arrayofNums) {
            average += num;
        }

        average = average / arrayofNums.Count;
        
        return average; 
    }

    private static void displayOptions()
    {
        Console.WriteLine("Please enter the following options: ");
        Console.WriteLine(" E: Enter numbers to add to list");
        Console.WriteLine(" Q: Query current average");
        Console.WriteLine(" L: Query current list of numbers");
        Console.WriteLine(" C: Clear console");
        Console.WriteLine(" X: Exit program");
        Console.Write("User input: ");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Cindy Sy's Coding Assessment for Noralta Technologies' Junior Software Developer position!");

        displayOptions();

        // get user input and initialize variables
        var input = Console.ReadLine().ToUpper();
        var listOfNums = new List<double>();
        double currentAverage = 0;

        // program runs until user decides to exit using 'X'
        while (input != "X")
        {
            switch (input)
            {
                // user enters a list of space-separated numbers and calculates average
                // if user enters chars or extra spaces,  then this gets ignored
                case "E":
                    Console.Write("Please enter a list of space-separated numbers: ");
                    var inputLine = Console.ReadLine();

                    // check if input is empty or only contains spaces
                    if (string.IsNullOrWhiteSpace(inputLine))
                    {
                        Console.WriteLine("Error: No valid numbers entered! Please try again.\n");
                        break;  // exit case early
                    }

                    var inputOfInts = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var num in inputOfInts)
                    {
                        if (double.TryParse(num, out currentAverage) ) {
                            listOfNums.Add(Convert.ToDouble(num));
                        } else
                        {
                            Console.WriteLine($"Warning: {num} is not a valid number! This will be ignored.");
                        }
                    }

                    currentAverage = getAverage(listOfNums);

                    Console.WriteLine($"Current average: {currentAverage.ToString("#.##")} \n");

                    break;
                // prints current average to console
                case "Q":
                    Console.WriteLine($"Current average: {currentAverage.ToString("#.##")} \n");
                    break;
                // displays all current numbers in the list and its length
                case "L":
                    if (listOfNums.Count == 0)
                    {
                        Console.WriteLine("Current list is empty! \n");
                    } else
                    {
                        Console.WriteLine($"Current list of numbers: {String.Join(", ", listOfNums)}");
                        Console.WriteLine($"Total numbers in list: {listOfNums.Count} \n");
                    }
                    break;
                // clears console for readability
                case "C":
                    Console.Clear();
                    break;
                // closes program by breaking out of loop
                case "X":
                    break;
                // any other char entered will prompt the user to enter another option from the list
                default:
                    Console.WriteLine("Please enter a valid option from the list! \n");
                    break;
            }

            displayOptions();
            input = Console.ReadLine().ToUpper();
        }
    }
}