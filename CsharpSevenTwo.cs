

public class CsharpSevenTwo 
{

    public class ReadonlyStructs
    {
        public readonly struct Person
        {
            public string LastName { get; }

            public Person(string lastName)
            {
                this.LastName = lastName;
            }
        }

        public ReadonlyStructs()
        {
            var person = new Person("Doe");
        }
    }

    public class ExtensionMethodsWithRefOrInParameters 
    {
        public ExtensionMethodsWithRefOrInParameters()
        {
            string s1 = "s1";
            string s2 = "s2";
            string s3 = "s3";

            s1.ExtensionMethod(in s2, out s3);
            s1.ExtensionMethod(s2, out s3);
        }
    }

    /// <summary>
    /// Instances of a ref struct type are allocated on the stack and can't escape to the managed heap.
    /// To ensure that, the compiler limits the usage of ref struct types.
    /// </summary>
    public class RefLikeStructs
    {
        public ref struct CustomRef
        {
            public bool IsValid;
            public System.Span<int> Inputs;
            public System.Span<int> Outputs;
        }
    }

    public CsharpSevenTwo()
    {
        new ReadonlyStructs();
        new ExtensionMethodsWithRefOrInParameters();
        new RefLikeStructs();
    }
}

public static class Extensions
{
    public static void ExtensionMethod(this string s, in string param1, out string param2)
    {
        param2 = $"{s}-{param1}";
    }
}