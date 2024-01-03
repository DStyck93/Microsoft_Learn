/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
int examAssignments = 5;

string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan"];

int[] sophiaScores = [90, 86, 87, 98, 100, 94, 90];
int[] andrewScores = [92, 89, 81, 96, 90, 89];
int[] emmaScores = [90, 85, 87, 98, 68, 89, 89, 89];
int[] loganScores = [90, 95, 87, 88, 96, 96];

int[] studentScores = new int[10];

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

/*
The outer foreach loop is used to:
- iterate through student names 
- assign a student's grades to the studentScores array
- sum assignment scores (inner foreach loop)
- calculate numeric and letter grade
- write the score report information
*/
foreach (string name in studentNames)
{
    string currentStudent = name;
    decimal examScore = 0;
    decimal overall = 0;
    string grade = "";
    int extraCreditAvg = 0;
    decimal extraCreditPoints = 0;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;
    
    decimal sumAssignmentScores = 0;
    int gradedAssignments = 0;
    int sumExtraCredit = 0;
    int extraCreditCount = 0;

    /* 
    the inner foreach loop sums assignment scores
    extra credit assignments are worth 10% of an exam score
    */
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
        {
            sumAssignmentScores += score;
            examScore += score;
        }
        else
        {
            sumAssignmentScores += (decimal)score / 10;
            sumExtraCredit += score;
            extraCreditCount++;
        }
    }

    examScore /= examAssignments;
    overall = sumAssignmentScores / examAssignments;

    if (overall >= 97)
        grade = "A+";
    else if (overall >= 93)
        grade = "A";
    else if (overall >= 90)
        grade = "A-";
    else if (overall >= 87)
        grade = "B+";
    else if (overall >= 83)
        grade = "B";
    else if (overall >= 80)
        grade = "B-";
    else if (overall >= 77)
        grade = "C+";
    else if (overall >= 73)
        grade = "C";
    else if (overall >= 70)
        grade = "C-";
    else if (overall >= 67)
        grade = "D+";
    else if (overall >= 63)
        grade = "D";
    else if (overall >= 60)
        grade = "D-";
    else
        grade = "F";

    extraCreditAvg = sumExtraCredit / extraCreditCount;
    extraCreditPoints = (decimal) sumExtraCredit / 10 / examAssignments;

    Console.WriteLine($"{currentStudent}\t\t{examScore}\t\t{overall}\t{grade}\t{extraCreditAvg} ({extraCreditPoints})");
}

// required for running in VS Code (keeps the Output windows open to view results)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
