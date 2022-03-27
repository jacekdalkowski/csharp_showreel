namespace CsharpShowreel
{
    /// <summary>
    /// C# 7.0 new features:
    ///  - pattern matching: constant, type, var
    ///  - 
    /// </summary>
    public class CsharpSevenZero
    {
        public class ConstantPatternMatching
        {
            static void Match(object input)
            {
                if (input is "hello") {
                    System.Console.WriteLine("hello");
                } else if (input is 5L) {
                    System.Console.WriteLine("input is long 5");
                } else if (input is 10) {
                    System.Console.WriteLine("input is int 10");
                } else {
                    System.Console.WriteLine("input is sth else");
                }
            }
        }

        public class TypePatternMatching
        {
            public class Shape {}

            public class Rectangle : Shape {
                public int Width { get; }

                public int Height { get; }
            }

            public static int Perimeter(Shape shape)
            {
                if (shape == null)
                    throw new System.ArgumentNullException(nameof(shape));
                if (shape is Rectangle rect)
                    return 2 * (rect.Width + rect.Height);
                throw new System.Exception();
            }

        }

        public class VarPatternMatching
        {
            private string GetId()
            {
                return "321";
            }

            public VarPatternMatching()
            {
                if (GetId() is var id && id != null)
                {
                    System.Console.WriteLine("Got id");
                }
            }
        }

        public class SystemValueTuple
        {
            (int start, int stop) RangeWithNames { get; }
            (int, int) RangeWithoutNames { get; }

            (int start, int stop) CalculateRangeWithNames(int start, int length)
            {
                return (start, start + length);
            }

            (int, int) CalculateRangeWithoutNames(int start, int length)
            {
                return (start, start + length);
            }

            public SystemValueTuple()
            {
                RangeWithNames = (1, 1);
                RangeWithNames = (start: 1, stop: 1);
                RangeWithNames = (a: 1, b: 1);

                RangeWithoutNames = (1, 1);
                RangeWithoutNames = (start: 1, stop: 1);

                RangeWithNames = CalculateRangeWithNames(2, 10);
                RangeWithoutNames = CalculateRangeWithNames(2, 10);

                RangeWithoutNames = CalculateRangeWithoutNames(2, 10);
                RangeWithNames = CalculateRangeWithoutNames(2, 10);

                (long start, long stop) LongRange = RangeWithNames;
                LongRange.stop = 100;
            }
        }

        public class DeconstructionOfTuples
        {
            private (System.Guid, string) GetUserData()
            {
                return (System.Guid.NewGuid(), "Beverly Hills 90210");
            }

            private void GetByItem()
            {
                (System.Guid, string) userData = GetUserData();
                System.Guid id = userData.Item1;
                string address = userData.Item2;
            }

            private void GetByExplicitlyTypedVariables()
            {
                (System.Guid id, string address) = GetUserData();
            }

            public void GetByVar()
            {
                var (id, address) = GetUserData();
            }

            public void GetByMixed()
            {
                (var id, string address) = GetUserData();
            }

            public DeconstructionOfTuples()
            {
                GetByItem();
                GetByExplicitlyTypedVariables();
                GetByVar();
                GetByMixed();
            }
        }

        public class DeconstructionOfAnythingWithDeconstructMethod
        {
            public class Person
            {
                public System.Guid Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }

                public Person(System.Guid id, string fname, string lname) => (Id, FirstName, LastName) = (id, fname, lname);

                public void Deconstruct(out string fname, out string lname)
                {
                    fname = FirstName;
                    lname = LastName;
                }

                public void Deconstruct(out System.Guid id, out string fname, out string lname)
                {
                    id = Id;
                    fname = FirstName;
                    lname = LastName;
                }
            }

            public DeconstructionOfAnythingWithDeconstructMethod()
            {
                var person = new Person(System.Guid.NewGuid(), "Joe", "Doe");
                var (fname, lname) = person;
                var (id, fname_2, lname_2) = person;
            }
        }

        public class RefLocals
        {
            public RefLocals()
            {
                int x = 10;
                ref int y = ref x;
                x++;
                y++;
                System.Console.WriteLine(x);
            }
        }

        public class RefReturns
        {
            static ref int RefReturn(ref int p)
            {
                return ref p;
            }

            public RefReturns()
            {
                int x = 10;
                ref int y = ref RefReturn(ref x);
                y++;
                System.Console.WriteLine(x);
            }
        }

        public CsharpSevenZero()
        {
            new ConstantPatternMatching();
            new TypePatternMatching();
            new VarPatternMatching();
            new SystemValueTuple();
            new DeconstructionOfTuples();
            new DeconstructionOfAnythingWithDeconstructMethod();
        }
    }
}