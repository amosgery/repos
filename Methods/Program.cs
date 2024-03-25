// See https://aka.ms/new-console-template for more information
class Program
{
    static double Average3(int num1, int num2, int num3)
    //פעולה מקבלת שלושה מספרים שלמים
    //פעולה מחזירה ממוצע שלהם
    {
        double avg = (double)(num1 + num2 + num3) / 3;
        return avg;
    }

    static int DigitSum(int num)
    //פעולה מקבלת מספר שלם
    //פעולה מחזירה את סכום הספרות
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;

        }
        return sum;
    }

    static int MaxDigit(int num1, int num2, int num3)
    //פעולה מקבלת מספר שלם
    //פעולה מחזירה את סכום הספרות
    {
        int sum1 = DigitSum(num1);
        int sum3 = DigitSum(num3);
        int sum2 = DigitSum(num2);
        if (sum1 >= sum2 && sum1 >= sum3)
            return num1;
        if (sum2 >= sum1 && sum2 >= sum3)
            return num2;
        if (sum3 >= sum2 && sum3 >= sum1)
            return num3;
        return 0;
    }
    static void Main(String[] args)
    {
        int num1, num2, num3;
        Console.WriteLine("please enter 3 numbers");
        num1 = int.Parse(Console.ReadLine());// קליטת מספר ראשון
        num2 = int.Parse(Console.ReadLine()); // קליטת מספר שני
        num3 = int.Parse(Console.ReadLine()); // קליטת מספר שלישי

        int avg = (int)Average3(num1, num2, num3);
        Console.WriteLine("Average is: "+avg);

        Console.WriteLine("Digit sum for num1: " + DigitSum(num1));
        Console.WriteLine("Digit sum for num2: " + DigitSum(num2));
        Console.WriteLine("Digit sum for num3: " + DigitSum(num3));

        Console.WriteLine("The number with the highest digit sum is: " + MaxDigit(num1, num2, num3));
    }
}
