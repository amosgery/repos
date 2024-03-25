

Console.WriteLine("Enter the number of students:");
int numOfStudents = int.Parse(Console.ReadLine());


int[] grades = new int[numOfStudents];


Console.WriteLine("Enter the grade of each student:");
for (int i = 0; i < numOfStudents; i++)
{
    grades[i] = int.Parse(Console.ReadLine());
}

int sum = 0;
for (int i = 0;i < numOfStudents; i++)
{
    sum += grades[i];
}
Console.WriteLine("The average grade is: " +  sum/numOfStudents);

Console.WriteLine("Enter the grade to search for:");
int grade = int.Parse(Console.ReadLine());
bool exists = false; 
for (int i = 0; i < numOfStudents; i++)
{
    if (grades[i] == grade)
    {
        Console.WriteLine("Exists");
        exists = true;
    }
}
if (!exists)
    Console.WriteLine("Doesn't exist");

bool exist = false;
int i = 0;
while (i <  numOfStudents && !exist && grades[i] <= grade)
{
    if (grades[i] == grade)
    {
        Console.WriteLine("Exists");
        exists = true;
        i++;
    }

}
if (!exists)
    Console.WriteLine("Doesn't exist");