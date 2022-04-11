namespace CsharpShowreel
{
    using static System.String;

    /// <summary>
    /// C# 6 isn’t about doing more; it is about doing the same work with less code.
    /// </summary>
    public class CsharpSix
    {

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
            
        }
        
        public class CollectionInitializersWithExtensionMethods
        {

        }

        public CsharpSix()
        {
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
}