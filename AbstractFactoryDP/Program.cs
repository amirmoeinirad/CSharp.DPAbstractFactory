
// Amir Moeini Rad
// September 2025

// Main Concept: The Abstract Factory Design Pattern

// In this pattern, we create an interface for creating families of related or dependent objects without specifying their concrete classes.
// This pattern is particularly useful when the system needs to be independent of how its products are created, composed, and represented.

// The difference between Factory Method and Abstract Factory is that:
// Factory Method uses inheritance and relies on a subclass to handle the desired object instantiation,
// Abstract Factory uses composition to delegate the responsibility of object instantiation to another object via interfaces.

// To put this more simply:
// (1) In Factory Method, each factory method creates one product. (based on class hierarchy)
// (2) In Abstract Factory, each factory creates a family of products. (based on composition and interfaces)


namespace AbstractFactoryDP
{
    // Products Family defined as interfaces
    interface IButton
    {
        void Paint();
    }


    interface ICheckbox
    {
        void Paint();
    }

    
    ////////////////////////////////////////////////////
    

    // Concrete Products Family (Windows)
    class WindowsButton : IButton
    {
        public void Paint() => Console.WriteLine("Rendering a Windows Button.");
    }


    class WindowsCheckbox : ICheckbox
    {
        public void Paint() => Console.WriteLine("Rendering a Windows Checkbox.");
    }


    ////////////////////////////////////////////////////
    

    // Concrete Products Family (Mac)
    class MacButton : IButton
    {
        public void Paint() => Console.WriteLine("Rendering a Mac Button.");
    }


    class MacCheckbox : ICheckbox
    {
        public void Paint() => Console.WriteLine("Rendering a Mac Checkbox.");
    }

    
    ////////////////////////////////////////////////////
    

    // Factory defined as an interface
    interface IUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }


    ////////////////////////////////////////////////////
    
    
    // Concrete Factories
    class WindowsFactory : IUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }


    class MacFactory : IUIFactory
    {
        public IButton CreateButton() => new MacButton();
        public ICheckbox CreateCheckbox() => new MacCheckbox();
    }


    ////////////////////////////////////////////////////


    // Client
    // The client chooses which factory to use and creates products from the same family.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("The Abstract Factory Method Design Pattern in C#.NET.");
            Console.WriteLine("-----------------------------------------------------\n");


            // Create a factory (e.g., Windows)
            // Create products from the same family
            IUIFactory factory = new WindowsFactory();           
            IButton button = factory.CreateButton();
            ICheckbox checkbox = factory.CreateCheckbox();


            button.Paint();
            checkbox.Paint();


            // Now switch to Mac factory
            factory = new MacFactory();
            button = factory.CreateButton();
            checkbox = factory.CreateCheckbox();


            button.Paint();
            checkbox.Paint();


            Console.WriteLine("\nDone.");
        }
    }
}
