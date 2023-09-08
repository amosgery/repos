namespace OOP_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            Person p2 = new Person("David", "Cohen");

            Console.WriteLine("Persons:");
            Console.WriteLine(p1.Print());
            Console.WriteLine(p2.Print());

            Employee e1 = new Employee();
            Employee e2 = new Employee("Lior", "Zamir", 25000);

            Console.WriteLine("\n--------------\n");
            Console.WriteLine("Employees:");
            Console.WriteLine(e1.Print());
            Console.WriteLine(e2.Print());

            int[] grades = new int[] { 90, 100, 85 };

            Student s1 = new Student();
            Student s2 = new Student("Avi", "Levi", grades);

            Console.WriteLine("\n--------------\n");
            Console.WriteLine("Students:");
            Console.WriteLine(s1.Print());
            Console.WriteLine(s2.Print());

        }
    }
}
