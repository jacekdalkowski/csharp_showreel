
namespace CsharpShowreel
{
    /// <summary>
    /// C# 3 new features:
    ///   - LINQ: 
    ///     - vars, 
    ///     - lambdas, 
    ///     - extension methods
    /// </summary>
    public class CsharpThree
    {
        public class AutomaticallyImplementedProperties
        {
            public string Name { get; private set; }
        }

        public class EnhancedCollectionAndObjectInitialization
        {
            System.Collections.Generic.List<int> digits = new System.Collections.Generic.List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 

            Person person = new Person()
            {
                Id = "1",
                Name = "Jack"
            };

            private class Person
            {
                public string Id { get; set; }

                public string Name { get; set; }
            }
        }

        public class ImplicitlyTypedLocalVariables
        {
            public static void SomeMethod()
            {
                var idx = 1;
                System.Console.WriteLine(idx + 10);
            }
        }

        public class Lambdas
        {
            private System.Func<int, int, int> _add = (a, b) => a + b;
        }

        public class AnonymousTypes
        {
            public AnonymousTypes()
            {
                var someData = new 
                {
                    Timestamp = 123L,
                    Value = 1.23m
                };
            }
        }

        public class ExtensionMethods
        {
            public ExtensionMethods()
            {
                int two = 1.IncreaseByOne();
            }
        }

        public CsharpThree()
        {
            new AutomaticallyImplementedProperties();
            new EnhancedCollectionAndObjectInitialization();
            new ImplicitlyTypedLocalVariables();
            new Lambdas();
            new AnonymousTypes();
            new ExtensionMethods();
        }
    }

    public static class ExtensionMethods
    {
        public static int IncreaseByOne(this int i)
        {
            return i + 1;
        }
    }
}

