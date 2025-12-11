using System;
Console.WriteLine("\n====================\n");

string[] qustionsList = {
    "What is the capital of Kentucky",
    "When did Kentucky become a state.",
    "What is Kentucky's official nickname?",
    "What famous horse race is held annually in Louisville?",
    "What is the longest known cave system in the world, located in Kentucky?",
    "What precious metal is stored at Fort Knox?",
    "What is Kentucky's state bird?",
    "What famous fast-food chain was founded in Kentucky by Colonel Sanders?",
    "What is Kentucky most famous for producing?",
    "Which U.S. President was born in Kentucky in a log cabin?"
};

string[] answersList = {
    "Frankfort.Louisville.Lexington.Owensboro",
    "1792.1795.1802.1797",
    "The Bluegrass State.The Cardinal State.The Bourbon State.The Basketball State",
    "The Kentucky Derby.The Kentucky Oaks.The Keeneland Stakes.The Turfland Classic",
    "Mammoth Cave.Russell Cave.Carter Caves.Jewel Caves",
    "Gold.Silver.Platinum.Cooper",
    "Cardinal.Blue Jay.Bald Eagle.Wild Turkey",
    "KFC.Moonlite BBQ.Big Dipper.Parkette Drive-In ",
    "Bourbon.Gold.Horses.Tobacco",
    "Abraham Lincoln.Henry Clay.Thomas Jefferson.Andrew Jackson"
};

Random randomQuestion = new Random();
Random swapAnswers = new Random();

string usedQuestions = "";
string userChoice = "";


int numCorrectAnswers = 0;
int numOfQuestions = 7;
int correctIndex = 1;
string correctAnswer = "";
int q=1;

Console.WriteLine($"Welcome to the Kentucky quiz!");
Console.WriteLine($"You will be asked {numOfQuestions} questions.\n ");

while (q <= numOfQuestions) {
    int nextQuestion = randomQuestion.Next(0,9);
    if (!usedQuestions.Contains(nextQuestion.ToString())) {
        Console.WriteLine($"{q}: {qustionsList[nextQuestion]}");


        DisplayAnswers(nextQuestion);

        Console.Write("  Your guess:  ");
        userChoice = Console.ReadLine();

        if (userChoice == (correctIndex+1).ToString()) {
            Console.WriteLine("  Correct!! \n");
            numCorrectAnswers++;
        } else {
            Console.WriteLine($"  Wrong! \t The correct answer is {correctAnswer} \n");
        }

        usedQuestions += $"{nextQuestion},";
        q++;
    }
}

double correctPercent = CalculateResults(numCorrectAnswers, numOfQuestions);
Console.WriteLine($"You got {numCorrectAnswers} out of {numOfQuestions}.  That is a {correctPercent:F2} %");


void DisplayAnswers(int nextQuestion) {
    string[] randomChoices =  RandomizeAnswer(nextQuestion);
    for (int a = 0; a < 4; a++) {
        Console.WriteLine($"  {(a+1)}: {randomChoices[a]}");
    }
}


string[] RandomizeAnswer(int question) {
    //  Split the answer list string into an array.
    string[] choices = answersList[question].Split(".");

    //  Swap correct answer into new location
    correctIndex = swapAnswers.Next(0, 4);
    var temp = choices[0];
    choices[0] = choices[correctIndex];
    choices[correctIndex] = temp;

    correctAnswer = choices[correctIndex];
    return choices;
}


double CalculateResults(int correct, int total) {
    return ( (double) correct * 100 / (double) total );
}


Console.WriteLine("\n====================");