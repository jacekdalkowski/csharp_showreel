namespace CsharpShowreel
{
    /// <summary>
    /// C# 7.0 new features:
    ///  - pattern matching: constant, type, var
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
            
        }

        public class DeconstructionOfTuples
        {

        }

        public class DeconstructionOfAnythingWithDeconstructMethod
        {

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