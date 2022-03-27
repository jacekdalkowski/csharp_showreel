namespace CsharpShowreel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsharpSevenOne
    {
        public class TypePatternMatchingWithGenerics
        {
            public class Shape { }

            public class Circle : Shape { }

            public static void DisplayShapes<T>(System.Collections.Generic.List<T> shapes) where T : Shape
            {
                foreach(T shape in shapes)
                {
                    switch (shape)
                    {
                        case Circle c:
                            System.Console.WriteLine(c);
                            break;
                    }
                }
            }
        }

        public class TupleElementNamesInferrence
        {
            public string SomeString { get; }

            public TupleElementNamesInferrence()
            {
                SomeString = "abc";
                var tuple = (1, SomeString.Length, SomeString[0], SomeString);

                var tupleFirstElement = tuple.Item1;

                var tupleSecondElement = tuple.Item2;
                tupleSecondElement = tuple.Length;

                var tupleThirdElement = tuple.Item3;

                var tupleFourthElement = tuple.Item4;
                tupleFourthElement = tuple.SomeString;
            }
        }

        public CsharpSevenOne()
        {
            new TypePatternMatchingWithGenerics();
            new TupleElementNamesInferrence();
        }
    }
}