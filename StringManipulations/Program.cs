// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

var stringCount = 1;

List<string> inputStrings = new List<string>();
Console.WriteLine("Enter 10 Words");
while (inputStrings.Count != 10)
{
    var isValidString = isValidStringFormat(stringCount);
    while (!isValidString)
    {
        DisplayErrorMessages();
        isValidString = isValidStringFormat(stringCount);
    }

    stringCount++;
}

if(inputStrings.Count >= 10)
{
    DisplayAllStrings();

}

bool isValidStringFormat(int stringCount)
{
    var enteredString = ExtractEnteredString(stringCount);
    var isValidString = !string.IsNullOrEmpty(enteredString);
    if (isValidString)
    {
        foreach (var character in enteredString)
        {
            var letter = character.ToString();
            if ((!Regex.IsMatch(letter, @"[A-Za-z]") && !Regex.IsMatch(letter, @"[0-9]")) || string.IsNullOrEmpty(letter))
                isValidString = false;
        }
    }
    if (isValidString) inputStrings.Add(enteredString);
    return isValidString;
}


string ExtractEnteredString(int stringCount)
{
    Console.WriteLine(String.Format("Enter {0} Word", stringCount));
    var enteredString = Console.ReadLine();
    return enteredString;
}

void DisplayAllStrings()
{
    Console.WriteLine("\n");
    Console.WriteLine("List of entered 10 strings");
    int count = 1;
    foreach (var inputString in inputStrings)
    {
        Console.WriteLine(String.Format("{0} word:{1}", count, inputString));
        count++;
    }
    Console.ReadLine(); 
}

void DisplayErrorMessages()
{
    Console.WriteLine("Entered string is not a valid format");
    Console.WriteLine("string should have following criteria");
    Console.WriteLine("1) string should start with Letters and should ends with numbers");
    Console.WriteLine("2) string should have either only letters or numbers");
    Console.WriteLine("3) string should starts with letter and ends with leters and can include numbers in between");
}

