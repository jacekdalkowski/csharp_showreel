namespace CsharpShowreel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsharpSevenThree
    {

        public class StackallocWithInitializers
        {
            public StackallocWithInitializers()
            {
                System.Span<int> span = stackalloc int[] { 1, 2, 3 };
                unsafe
                {
                    var pointer = stackalloc int[] { 1, 2, 3 };
                }
            }
        }

        public class PatternBasedFixedStatements
        {
            public PatternBasedFixedStatements()
            {
                unsafe
                {
                    // if obj has GetPinnableReference method
                    var someString = "foo";
                    fixed (char* ptr = someString)
                    {

                    }
                }
            }
        }

        public CsharpSevenThree()
        {
            new StackallocWithInitializers();
            new PatternBasedFixedStatements();
        }
    }
}