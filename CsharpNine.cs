using System.Threading.Tasks;

namespace CsharpShowreel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsharpNine
    {
        public class Records
        {
            // immutable-oriented reference types
        }

        public class InitOnlySetters
        {

        }

        public class TopLevelStatements
        {

        }

        public class PatternMatchingEnhancements
        {
            // Conjunctive, disjunctive, negated, relational
        }

        public class WithExpressions
        {
            // for records:
            // var otherPerson = person with { LastName = "Hanselman" };
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