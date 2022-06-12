namespace CsharpShowreel
{
    using System.Collections;
    using System.Collections.Generic;
    using static System.String;

    /// <summary>
    /// C# 6 isn’t about doing more; it is about doing the same work with less code.
    /// </summary>
    public class CsharpSix
    {

        public class AutoPropertyInitializers
        {
            public string Property { get; set; } = "value";
        }

        public class NullConditionalOperator
        {
            public NullConditionalOperator()
            {
                string someString = null;
                int? someStringLength = someString?.Length;

                string[] someStrings = null;
                int? secondStringLength = someStrings?[1].Length;
            }
        }

        public class ExpressionBodiedMembers
        {
            public void DisplayName() => System.Console.WriteLine(ToString());

            public override string ToString() => "ExpressionBodiedMembers";

            public string SomeProperty => ToString();
        }

        public class StringyFeatures
        {
            private string text = $"Today is {System.DateTime.Now.ToShortDateString()}";
        }

        public class ExceptionFilters
        {
            public ExceptionFilters()
            {
                int val1 = 0;  
                int val2 = 0;  
                try  
                {   
                    val1 = 10; 
                    // val2 = 0;  
                }  
                catch (System.Exception ex) when (val2 == 0)  
                {  
                    System.Console.WriteLine("Divided by zero!");  
                }  
                catch (System.Exception ex)  
                {  
                    System.Console.WriteLine(ex.Message);  
                }  
            }
        }

        public class ImportingStaticMembers
        {
            public ImportingStaticMembers()
            {
                string someText = "";
                System.String.IsNullOrEmpty(someText);
                IsNullOrEmpty(someText);
            }
        }

        public class ReadonlyAutomaticallyImplementedProperties
        {
            public string Foo { get; }

            public ReadonlyAutomaticallyImplementedProperties()
            {
                Foo = "bar";
            }
        }

        public class AutomaticallyImplementedPropertiesInStructs
        {
            struct Structure
            {
                public int Foo { get; private set; }

                public Structure(int foo)
                {
                    Foo = foo;
                }
            }
        }

        public class ObjectInitializersWithIndexers
        {
            public ObjectInitializersWithIndexers()
            {
                var identity = new Matrix
                {
                    [0, 0] = 1.0,
                    [0, 1] = 0.0,
                    [0, 2] = 0.0,

                    [1, 0] = 0.0,
                    [1, 1] = 1.0,
                    [1, 2] = 0.0,

                    [2, 0] = 0.0,
                    [2, 1] = 0.0,
                    [2, 2] = 1.0,
                };
            }
        }
        
        public class CollectionInitializersWithExtensionMethods
        {
            private CollectionWithoutAdd _collectionWithoutAdd = new CollectionWithoutAdd { 1, 2, "3", new object() };
        }

        public CsharpSix()
        {
            new AutoPropertyInitializers();
            new NullConditionalOperator();
            new ExpressionBodiedMembers();
            new StringyFeatures();
            new ExceptionFilters();
            new ImportingStaticMembers();
            new ReadonlyAutomaticallyImplementedProperties();
            new AutomaticallyImplementedPropertiesInStructs();
            new ObjectInitializersWithIndexers();
            new CollectionInitializersWithExtensionMethods();
        }
    }

    public class Matrix
    {
        private double[,] storage = new double[3, 3];

        public double this[int row, int column]
        {
            // The embedded array will throw out of range exceptions as appropriate.
            get { return storage[row, column]; }
            set { storage[row, column] = value; }
        }
    }

    public class CollectionWithoutAdd : IEnumerable
    {
        public IList<object> Store { get; private set; } = new List<object>();  

        public IEnumerator GetEnumerator()
        {
            return Store.GetEnumerator();
        }
    }

    public static class Extensions
    {
        public static void Add<T>(this CollectionWithoutAdd collection, T item)
        {
            collection.Store.Add(item);
        }
    }
}