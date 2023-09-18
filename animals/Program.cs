using System;

// Base class
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal is eating.");
    }
}

// Derived class
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is barking.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an object of the derived class (Dog)
        Dog myDog = new Dog();
        myDog.Eat();  // Access the Eat() method from the base class
        myDog.Bark(); // Access the Bark() method from the derived class

        Console.WriteLine();

        // Upcasting: Create an object of the base class type and assign it the derived class instance
        Animal myAnimal = myDog;

        // Now, myAnimal is of type Animal, but it still refers to the same object as myDog
        myAnimal.Eat();  // Access the Eat() method from the base class
        myAnimal.Bark(); // <== Error at compile time

        // However, you can downcast it back to Dog if needed
        Dog anotherDog = (Dog)myAnimal;
        // Dog anotherDog = (Dog)new Animal();  // <= Error at runtime
        anotherDog.Bark(); // Now you can access the Bark() method again

        Console.ReadLine();
    }
}
