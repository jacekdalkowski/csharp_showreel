namespace CsharpShowreel
{
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
                int? secondStringLength = someStrings[1].Length;
            }
        }

        public class ExpressionBodiedMembers
        {

        }

        public class StringyFeatures
        {

        }

        public class ExceptionFilters
        {

        }

        public class ImportingStaticMembers
        {

        }

        public class ReadonlyAutomaticallyImplementedProperties
        {

        }

        public class AutomaticallyImplementedPropertiesInStructs
        {

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