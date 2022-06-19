using System.Linq;
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

        public class NullCoalescingAssignment
        {

            public NullCoalescingAssignment()
            {            
                // You can use the ??= operator to assign the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null.
                System.Collections.Generic.List<int> numbers = null;
                int? i = null;

                numbers ??= new System.Collections.Generic.List<int>();
                numbers.Add(i ??= 17);
                numbers.Add(i ??= 20);
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

        public class PropertyPattern
        {
            // A property pattern matches an expression when an expression result is non-null and every nested pattern matches the corresponding property or field of the expression result.
            static bool IsConferenceDay(System.DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

            // You can also add a run-time type check and a variable declaration to a property pattern, as the following example shows:
            static string TakeFive(object input) => input switch
            {
                string { Length: >= 5 } s => s.Substring(0, 5),
                string s => s,

                System.Collections.Generic.ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
                System.Collections.Generic.ICollection<char> symbols => new string(symbols.ToArray()),

                null => throw new System.ArgumentNullException(nameof(input)),
                _ => throw new System.ArgumentException("Not supported input type."),
            };
        }

        public class PositionalPattern
        {
            //  the type of an expression contains the Deconstruct method, which is used to deconstruct an expression result
            public readonly struct Point
            {
                public int X { get; }
                public int Y { get; }

                public Point(int x, int y) => (X, Y) = (x, y);

                public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            }

            static string Classify(Point point) => point switch
            {
                (0, 0) => "Origin",
                (1, 0) => "positive X basis end",
                (0, 1) => "positive Y basis end",
                _ => "Just a point",
            };

            // You can also match expressions of tuple types against positional patterns. In that way, you can match multiple inputs against various patterns, as the following example shows
            static decimal GetGroupTicketPriceDiscount(int groupSize, System.DateTime visitDate)
                => (groupSize, visitDate.DayOfWeek) switch
                {
                    (<= 0, _) => throw new System.ArgumentException("Group size must be positive."),
                    (_, System.DayOfWeek.Saturday or System.DayOfWeek.Sunday) => 0.0m,
                    (>= 5 and < 10, System.DayOfWeek.Monday) => 20.0m,
                    (>= 10, System.DayOfWeek.Monday) => 30.0m,
                    (>= 5 and < 10, _) => 12.0m,
                    (>= 10, _) => 15.0m,
                    _ => 0.0m,
                };

            public PositionalPattern()
            {

            }
        }

        public class TuplePattern
        {
            public static string RockPaperScissors(string first, string second)
                => (first, second) switch
                {
                    ("rock", "paper") => "rock is covered by paper. Paper wins.",
                    ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                    ("paper", "rock") => "paper covers rock. Paper wins.",
                    ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                    ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                    ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                    (_, _) => "tie"
                };
        }

        /// In C# 7.3 and earlier, a constructed type (a type that includes at least one type argument) can't be an unmanaged type. 
        /// Starting with C# 8.0, a constructed value type is unmanaged if it contains fields of unmanaged types only.
        public class UnmanagedConstructedTypes
        {

            public struct Coords<T>
            {
                public T X;
                public T Y;
            }

            public UnmanagedConstructedTypes()
            {
                System.Span<Coords<int>> coordinates = stackalloc[]
                {
                    new Coords<int> { X = 0, Y = 0 },
                    new Coords<int> { X = 0, Y = 3 },
                    new Coords<int> { X = 4, Y = 0 }
                };
            }   
        }

        public class StaticLocalFunctions
        {
            public StaticLocalFunctions()
            {
                int y;
                LocalFunction();

                void LocalFunction() => y = 0;
            }
        }

        public CsharpEight()
        {
            new NullableReferenceTypes();
            new NullCoalescingAssignment();
            new RangesAndIndices();
            // DefaultImplementationsOfInterfaceMembers
            new SwitchExpressions();
            new IAsyncEnumerable().RunIAsyncEnumerable();
            new StructReadonlyInstanceMembers(2, 4);
            new PropertyPattern();
            new PositionalPattern();
            new TuplePattern();
            new UnmanagedConstructedTypes();
            new StaticLocalFunctions();
        }
    }
}