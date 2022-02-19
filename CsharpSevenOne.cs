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

        }

        public CsharpSevenOne()
        {
            
        }
    }
}