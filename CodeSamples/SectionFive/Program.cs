Console.WriteLine("Generating random numbers:");
DisplayRandomNumbers();

void DisplayRandomNumbers() 
{
    Random random = new Random();

    for (int i = 0; i < 5; i++) 
    {
        Console.Write($"{random.Next(1, 100)} ");
    }

    Console.WriteLine();
}

//

Random random = new Random();
int luck = random.Next(100);

string[] text = {"You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"};
string[] good = {"look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"};
string[] bad = {"fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."};
string[] neutral = {"appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."};

TellFortune();
luck = random.Next(100);
TellFortune();

void TellFortune() 
{
    Console.WriteLine("A fortune teller whispers the following words:");
    string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
    for (int i = 0; i < 4; i++) 
    {
        Console.Write($"{text[i]} {fortune[i]} ");
    }
}

//

string[,] corporate = 
{
	{"Robert", "Bavin"}, {"Simon", "Bright"},
	{"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
	{"Sarah", "Delucchi"}, {"Sinan", "Ali"}};

string[,] external = 
{
	{"Vinnie", "Ashton"}, {"Cody", "Dysart"},
	{"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

for (int i = 0; i < corporate.GetLength(0); i++) 
{
	DisplayEmail(first: corporate[i,0], last: corporate[i,1]);
}

for (int i = 0; i < external.GetLength(0); i++) 
{
	DisplayEmail(first: external[i,0], last: external[i,1], domain: externalDomain);
}

void DisplayEmail(string first, string last, string domain = "contoso.com") 
{
	string email = first.Substring(0, 2) + last;
	email = email.ToLower();
	Console.WriteLine($"{email}@{domain}");
}


//




bool IsPalindrome(string word) 
{
    int start = 0;
    int end = word.Length - 1;

    while (start < end) 
    {
        if (word[start] != word[end]) 
        {
            return false;
        }
        start++;
        end--;
    }

    return true;
}




//====


int target = 30;
int[] coins = new int[] {5, 5, 50, 25, 25, 10, 5};
int[,] result = TwoCoins(coins, target);

if (result.Length == 0) 
{
    Console.WriteLine("No two coins make change");
} 
else 
{
    Console.WriteLine("Change found at positions:");
    for (int i = 0; i < result.GetLength(0); i++) 
    {
        if (result[i,0] == -1) 
        {
            break;
        }
        Console.WriteLine($"{result[i,0]},{result[i,1]}");
    }
}

int[,] TwoCoins(int[] coins, int target) 
{
    int[,] result = {{-1,-1},{-1,-1},{-1,-1},{-1,-1},{-1,-1}};
    int count = 0;

    for (int curr = 0; curr < coins.Length; curr++) 
    {
        for (int next = curr + 1; next < coins.Length; next++) 
        {    
            if (coins[curr] + coins[next] == target) 
            {
                result[count, 0] = curr;
                result[count, 1] = next;
                count++;
            }
            if (count == result.GetLength(0)) 
            {
                return result;
            }
        }
    }
    return (count == 0) ? new int[0,0] : result;
}

/*
In the code that you start with, there are two unavailable methods referenced:

ShouldPlay: This method should retrieve user input and determine if the user wants to play again WinOrLose: This method should determine if the player has won or lost

There are also two uninitialized variables:

target: The random target number between 1 and 5 roll: The result of a random six-sided die roll

Your challenge is to create the ShouldPlay and WinOrLose methods, and create methods that set target and roll to random values in the correct range. When all the methods are complete, the game should run successfully.

Ensure that you have an empty Program.cs file open in Visual Studio Code.

If necessary, open Visual Studio Code, and then complete the following steps to prepare a Program.cs file in the Editor:

On the File menu, select Open Folder.

Use the Open Folder dialog to navigate to, and then open, the CsharpProjects folder.

In the Visual Studio Code EXPLORER panel, select Program.cs.

On the Visual Studio Code Selection menu, select Select All, and then press the Delete key.
*/


Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay()) 
{
    PlayGame();
}

// void PlayGame() 
// {
//     var play = true;

//     while (play) 
//     {
//         var target;
//         var roll;

//         Console.WriteLine($"Roll a number greater than {target} to win!");
//         Console.WriteLine($"You rolled a {roll}");
//         Console.WriteLine(WinOrLose());
//         Console.WriteLine("\nPlay again? (Y/N)");

//         play = ShouldPlay();
//     }
// }

//======


Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay()) 
{
    PlayGame();
}

bool ShouldPlay() 
{
    string response = Console.ReadLine();
    return response.ToLower().Equals("y");
}

void PlayGame() 
{
    var play = true;

    while (play) {
        var target = GetTarget();
        var roll = RollDice();

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(roll, target));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();
    }
}

int GetTarget() 
{
    return random.Next(1, 6);
}

int RollDice() 
{
    return random.Next(1, 7);
}

string WinOrLose(int roll, int target) 
{
    if (roll > target) 
    {
        return "You win!";
    }
    return "You lose!";
}

//===

