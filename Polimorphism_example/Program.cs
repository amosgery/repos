class Program
{
    static void Main(string[] args)
    {
        Base a = new Base();
        Console.WriteLine(a.Print() + " X= " + a.X);

        Base b = new Derived();
        Console.WriteLine(b.Print() + " X= " + b.X);

        Derived d = new Derived();
        Console.WriteLine(d.Print() + " X= " + d.X + " Y= " + d.Y);

        //Derived e = new Base();
        //Console.WriteLine(e.Print() + " X= " + e.X + " Y= " + e.Y);

    }
}

class Base
{
    public int X { get; set; }

    public virtual string Print()
    {
        return "Base print";
    }
}

class Derived : Base
{
    public int Y { get; set; }

    public override string Print()
    {
        return "Derived print";
    }
}