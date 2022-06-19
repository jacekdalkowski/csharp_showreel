using System.Threading.Tasks;

namespace CsharpShowreel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsharpNine
    {

        // While records can be mutable, they are primarily intended for supporting immutable data models. The record type offers the following features:
        // Concise syntax for creating a reference type with immutable properties
        // Behavior useful for a data-centric reference type:
        //  * Value equality
        //  * Concise syntax for nondestructive mutation
        //  * Built-in formatting for display
        //  * Support for inheritance hierarchies
        //
        // You can use structure types to design data-centric types that provide value equality and little or no behavior. But for relatively large data models, structure types have some disadvantages:
        //  * They don't support inheritance.
        //  * They're less efficient at determining value equality. For value types, the ValueType.Equals method uses reflection to find all fields. For records, the compiler generates the Equals method. In practice, the implementation of value equality in records is measurably faster.
        //  * They use more memory in some scenarios, since every instance has a complete copy of all of the data. Record types are reference types, so a record instance contains only a reference to the data.
        public class Records
        {
            // immutable-oriented reference types
            public record Person_1(string FirstName, string LastName);

            public record Person_2
            {
                public string FirstName { get; init; } = default!;
                public string LastName { get; init; } = default!;
            };

            public record Person_3
            {
                public string FirstName { get; set; } = default!;
                public string LastName { get; set; } = default!;
            };

            public Records()
            {
                Person_1 person1 = new Person_1("Sam", "Raynolds");
                System.Console.WriteLine(person1); // prints out nicely
            }
        }

        public class InitOnlySetters
        {
            public System.DateTime RecordedAt { get; init; }

            public InitOnlySetters()
            {
                RecordedAt = System.DateTime.MinValue;
            }
        }

        public class TopLevelStatements
        {
            // Omitting namespace and class block.
            // Only one file in your application may use top-level statements. 
        }

        public class PatternMatchingEnhancements
        {
            // Conjunctive, disjunctive, negated, relational
            public class TypePatternMatchingImprovements
            {
                public class Shape {}

                public class Rectangle : Shape {
                    public int Width { get; }

                    public int Height { get; }
                }

                public static int Perimeter(Shape shape)
                {
                    if (shape is null) // new feature?
                        throw new System.ArgumentNullException(nameof(shape));
                    if (shape is Rectangle) // if variable is not needed, it can be skipped (we do not even need to discard it using _)
                        return 10;
                    throw new System.Exception();
                }
            }

            public class ParenthesizedPattern
            {
                public ParenthesizedPattern(object input)
                {
                    if (input is not (float or double))
                    {
                        return;
                    }
                }
            }

            public class ConjunctiveDisjunctiveParenthesizedPattern
            {
                public static bool IsLetterOrSeparator(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

                public ConjunctiveDisjunctiveParenthesizedPattern(char c)
                {
                    if (IsLetterOrSeparator(c))
                    {
                        return;
                    }
                }
            }

            public class Relational
            {
                static string Classify(double measurement) => measurement switch
                {
                    < -4.0 => "Too low",
                    > 10.0 => "Too high",
                    double.NaN => "Unknown",
                    _ => "Acceptable",
                };

                public Relational()
                {

                }
            }

            public PatternMatchingEnhancements()
            {
                new TypePatternMatchingImprovements();
                new ParenthesizedPattern(new object());
                new ConjunctiveDisjunctiveParenthesizedPattern('s');
            }
        }

        public class WithExpressions
        {
            public WithExpressions()
            {
                Records.Person_1 person1 = new Records.Person_1("Sam", "Raynolds");
                Records.Person_1 person2 = person1 with { FirstName = "John" };
            }
        }

        public class DefaultImplementationsOfInterfaceMembers
        {
            // public data class Person { string FirstName; string LastName; }
            // equals
            // public data class Person
            // {
            // public string FirstName { get; init; }
            // public string LastName { get; init; }
            // }
        }

        public class NewTargetTypedExpressions
        {
            public class Friend
            {
                public Friend() { }

                public Friend(string firstName, string lastName)
                {
                    FirstName = firstName;
                    LastName = lastName;
                }

                public string FirstName { get; set; }
                public string LastName { get; set; }
            }

            public NewTargetTypedExpressions()
            {
                Friend friend_0 = new();
                Friend friend_1 = new("Thomas", "Huber");
            }
        }

        public CsharpNine()
        {
            new Records();
            new InitOnlySetters();
            new TopLevelStatements();
            new PatternMatchingEnhancements();
            new WithExpressions();
            new DefaultImplementationsOfInterfaceMembers();
            new NewTargetTypedExpressions();
        }
    }
}