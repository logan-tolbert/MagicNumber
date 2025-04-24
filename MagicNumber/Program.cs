using static System.Console;

var userChances = 0;
var difficulty = 0;
var attempts = 0;
var isValidDifficulty = false;
var guessedCorrectly = false;

const int minNumber = 1;
const int maxNumber = 100;
var rand = new Random();
var targetNumber = rand.Next(minNumber, maxNumber);

WriteLine("Welcome to the Number Guessing Game!");
WriteLine("I'm thinking of a number between 1 and 100.");

WriteLine("Please select the difficulty level:");
WriteLine("1. Easy (10 chances)");
WriteLine("2. Medium (5 chances)");
WriteLine("3. Hard (3 chances)");

while (!isValidDifficulty)
{
    Write("Enter your choice: ");
    isValidDifficulty = int.TryParse(ReadLine(), out difficulty);
    if (!isValidDifficulty)
    {
        WriteLine("Invalid input. Please enter a number between 1 and 3.");
        continue;
    }

    userChances = difficulty switch
    {
        1 => 10,
        2 => 5,
        3 => 3,
        _ => 0 
    };

    if (userChances == 0)
    {
        WriteLine("Invalid selection. Please enter 1, 2, or 3.");
        isValidDifficulty = false;
    }
}

WriteLine($"Great! You selected the {difficulty} difficulty level with {userChances} chances.");
WriteLine("Let's start the game!");

while (userChances > 0)
{
    Write($"Enter your guess (You have {userChances} chances left): ");
    if (int.TryParse(ReadLine(), out var userGuess))
    {
        attempts++;
        if (userGuess == targetNumber)
        {
            WriteLine($"Congratulations! You guessed the correct number in {attempts} {(attempts == 1 ? "attempt" : "attempts")}.");
            guessedCorrectly = true;
            break;
        }

        WriteLine(userGuess < targetNumber
            ? $"Incorrect! The number is greater than {userGuess}."
            : $"Incorrect! The number is less than {userGuess}.");
        userChances--;
    }
    else
    {
        WriteLine("Invalid input. Please enter a number.");
    }
}

if (!guessedCorrectly)
{
    WriteLine($"You ran out of chances! The correct number was {targetNumber}.");
}

WriteLine("Thanks for playing Guess the Magic Number!");
WriteLine("Press any key to exit...");
ReadKey();