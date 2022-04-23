using System.Threading.Tasks;

namespace CsharpShowreel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsharpEight
    {

        /// <summary>
        /// Nullable reference types includes three features that help you avoid these exceptions, including the ability to explicitly mark a reference type as nullable:
        ///  - Improved static flow analysis that determines if a variable may be null before dereferencing it.
        ///  - Attributes that annotate APIs so that the flow analysis determines null-state.
        ///  - Variable annotations that developers use to explicitly declare the intended null-state for a variable.
        ///
        /// Feature enabled by   <nullable>Enable</nullable>
        /// </summary>
        public class NullableReferenceTypes
        {
            public void NullStateAnalysis()
            {
                string message = null;

                try
                {
                    // warning: dereference null.
                    System.Console.WriteLine($"The length of the message is {message.Length}");
                }
                catch {}
                

                var originalMessage = message;
                message = "Hello, World!";

                // No warning. Analysis determined "message" is not null.
                System.Console.WriteLine($"The length of the message is {message.Length}");

                // warning!
                try
                {
                    System.Console.WriteLine(originalMessage.Length);
                }
                catch {}
            }

            public void AttributesOnAPISignatures([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] object graphToTraverse)
            {

            }

            public void NullableVariableAnnotations(string? text)
            {
                try
                {
                    var nameLength1 = text.Length; // warning here
                    var nameLength2 = text!.Length; // no warning here
                }
                catch
                {

                }
            }

            public NullableReferenceTypes()
            {
                NullStateAnalysis();
                AttributesOnAPISignatures(null); // warning here because passing null
                NullableVariableAnnotations(null);
            }
        }

        public class RangesAndIndices
        {
            public RangesAndIndices()
            {
                var array = new int[] { 1, 2, 3, 4, 5 };
                var thirdItem = array[2];    // array[2]
                var lastItem = array[^1];    // array[new Index(1, fromEnd: true)]
                var slice1 = array[2..^3];    // array[new Range(2, new Index(3, fromEnd: true))]
                var slice2 = array[..^3];     // array[Range.EndAt(new Index(3, fromEnd: true))]
                var slice3 = array[2..];      // array[Range.StartAt(2)]
                var slice4 = array[..];       // array[Range.All]
            }
        }

        public class DefaultImplementationsOfInterfaceMembers
        {

        }

        public class SwitchExpressions
        {

        }

        public class NewTargetTypedExpressions
        {
            
        }

        public class IAsyncEnumerable
        {

        }

        public class ReadonlyInstanceMembers
        {

        }

        public CsharpEight()
        {
            new NullableReferenceTypes();
            new RangesAndIndices();
            new DefaultImplementationsOfInterfaceMembers();
            new SwitchExpressions();
            new NewTargetTypedExpressions();
            new IAsyncEnumerable();
            new ReadonlyInstanceMembers();
        }
    }
}