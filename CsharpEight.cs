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

        public interface DefaultImplementationsOfInterfaceMembers
        {
            void ToBeImplemented(string data);
            void AlreadyImplemented(string data) => ToBeImplemented(data);
        }

        public class SwitchExpressions
        {
            public enum Direction
            {
                Up,
                Down,
                Right,
                Left
            }

            public enum Orientation
            {
                North,
                South,
                East,
                West
            }

            public static Orientation ToOrientation(Direction direction) => direction switch
            {
                Direction.Up    => Orientation.North,
                Direction.Right => Orientation.East,
                Direction.Down  => Orientation.South,
                Direction.Left  => Orientation.West,
                _ => throw new System.ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
            };
        }

        public class IAsyncEnumerable
        {
            public static async System.Collections.Generic.IAsyncEnumerable<int> RangeAsync(int start, int count, int delay)
            {
                for (int i = start; i < start + count; i++) 
                {
                    await Task.Delay(delay);
                    yield return i;
                }
            }

            public async void RunIAsyncEnumerable()
            {
                await foreach (int item in RangeAsync(10, 3, 50)) { // IAsyncEnumerable
                    System.Console.Write(item + " "); // Prints 10 11 12
                }
            }
        }

        public struct StructReadonlyInstanceMembers
        {
            public double Height { get; set; }
            public double Width { get; set; }
            public readonly double Area => (Height * Width);
            public StructReadonlyInstanceMembers(double height, double width)
            {
                Height = height;
                Width = width;
            }
            public readonly override string ToString()
            {
                return $"(Total area for height: {Height}, width: {Width}) is {Area}";
            } 
        }

        public CsharpEight()
        {
            new NullableReferenceTypes();
            new RangesAndIndices();
            // DefaultImplementationsOfInterfaceMembers
            new SwitchExpressions();
            new IAsyncEnumerable().RunIAsyncEnumerable();
            new StructReadonlyInstanceMembers(2, 4);
        }
    }
}