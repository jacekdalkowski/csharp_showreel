[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Acme.Sth")]

namespace CsharpShowreel
{
    using GenCols = System.Collections.Generic;

    /// <summary>
    /// C# 2 new features:
    ///  - Generics, 
    ///  - nullables (reason - DB stuff), 
    ///  - delegates, 
    ///  - anonymous methods
    /// </summary>
    public class CsharpTwo
    {
        public class Generics
        {
            public class Container<T>
            {
                public T Holder;
            }

            static T Create<T>() where T : new()
            {
                T newInstance = new T();
                return newInstance;
            }

            public Generics()
            {
                Container<int> container = new Container<int>();
                int storedValue = container.Holder;

                System.Collections.ArrayList newInstance = Generics.Create<System.Collections.ArrayList>();
            }
        }

        public class PrivateTypedSetters
        {
            private string _name;
            public string Name 
            { 
                get 
                { 
                    return _name; 
                } 
                private set
                {
                    _name = value;
                }
            }

            public PrivateTypedSetters()
            {
                Name = "Property";
            }
        }

        public class StronglyTypedCollections
        {
            private System.Collections.Generic.IDictionary<string, decimal> dictionary;
            private System.Collections.Generic.IEnumerable<int> enumerableOfInts;
            private System.Collections.Generic.ICollection<int> collectionOfInts;
            private System.Collections.Generic.IList<int> listOfInts;

            public StronglyTypedCollections()
            {
                dictionary = new System.Collections.Generic.Dictionary<string, decimal>();
                dictionary["BTC"] = 200000.00m;

                enumerableOfInts = new int[2] { 1, 2 };
                System.Collections.Generic.IEnumerator<int> enumeratorOfInts = enumerableOfInts.GetEnumerator();

                // LinkedList doest not implement IList.
                // IList defines indexer, LinkedList does not.
                collectionOfInts = new System.Collections.Generic.LinkedList<int>();
                collectionOfInts.Add(1);
                collectionOfInts.Remove(1);
                collectionOfInts.Clear();

                listOfInts = new System.Collections.Generic.List<int>();
                listOfInts[0] = 1;
                listOfInts[1] = 2;
                listOfInts.RemoveAt(0);
            }
        }

        public class DelegateInstanceCreationExpressions
        {
            private System.Action<System.Collections.Generic.IList<double>> _printFirstElement;

            public DelegateInstanceCreationExpressions()
            {
                // works only for Actions, not for Func
                _printFirstElement = delegate (System.Collections.Generic.IList<double> numbers) 
                {
                    System.Console.WriteLine(numbers[0]);
                };
            }
        }

        public class DelegateCovarianceAndContravariance
        {
            private delegate object CreateObjectDelegate();
            private delegate void AcceptComparableDelgate(System.IComparable d);

            public DelegateCovarianceAndContravariance()
            {
                CreateObjectDelegate createObject = CreateArray;
                AcceptComparableDelgate acceptComperable = AcceptObject;
            }

            private System.Array CreateArray()
            {
                int[] array = new int[2];
                array[0] = 1;
                array[1] = 2;
                return array;
            }

            private void AcceptObject(object o)
            {
                System.Console.WriteLine(o.ToString());
            }
        }

        public class AnonymousMethods
        {
            private delegate int AddDelegate(int a, int b);

            public AnonymousMethods()
            {
                AddDelegate Add = delegate(int a, int b)
                {
                    return a + b;
                };
            }
        }

        public class NullableTypes
        {
            public NullableTypes()
            {
                System.Nullable<int> maybeNumber = null;
                if (!maybeNumber.HasValue) 
                {
                    maybeNumber = 1;
                }

                int result = 1 + maybeNumber.Value;
            }
        }

        public class ImplementingIterators
        {

            public ImplementingIterators()
            {
                System.Collections.Generic.IEnumerable<int> sequence = GetSequence(false);
            }

            private System.Collections.Generic.IEnumerable<int> GetSequence(bool evenNumbersOnly)
            {
                for (int i = 0; i < 128; ++i)
                {
                    bool isEven = i % 2 == 0;
                    if (isEven)
                    {
                        yield return i;
                    }

                    bool canReturnOdd = !evenNumbersOnly;
                    if (canReturnOdd)
                    {
                        yield return i;
                    }
                }
            }
        }

        public class PartialTypes
        {
            private partial class PartialClass
            {
                public void MethodA() { }
            }

            private partial class PartialClass
            {
                public void MethodB() { }
            }

            private partial interface PartialInterface
            {
                void Method1() { }
            }

            private partial interface PartialInterface
            {
                void Method2() { }
            }

            private partial struct PartialStruct
            {
                public int FieldA;
            }

            private partial struct PartialStruct
            {
                public string FieldB;
            }

            public PartialTypes()
            {
                PartialClass pc = new PartialClass();
                pc.MethodA();
                pc.MethodB();

                PartialStruct ps = new PartialStruct();
                int a = ps.FieldA;
                string b = ps.FieldB;
            }
        }

        public class StaticClasses
        {
            public static class Utils 
            {
                public static int Multiply(int a, int b)
                {
                    return a * b;
                }
            }

            public StaticClasses()
            {
                int r = Utils.Multiply(2, 10);
            }
        }
        public class SeparateGetterSetterPropertyAccess
        {
            private string _property;
            public string Property 
            { 
                get
                {
                    return _property;
                } 
                protected set
                {
                    _property = value;
                }
            }

            public SeparateGetterSetterPropertyAccess()
            {
                Property = "abc";
            }
        }

        public class NamespaceAliases
        {
            private GenCols.List<int> _listOfInts;
        }

        public class PragmaDirectives
        {
            #pragma warning disable CS0169
            int i;
            #pragma warning restore CS0169
        }

        public class FixedSizeBuffers
        {
            // public unsafe fixed byte bs[7];
        }

        public class FriendAssemblies
        {
            // [assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Friend1, PublicKey=002400000480000094...")]
        }

        public CsharpTwo()
        {
            new Generics();
            new PrivateTypedSetters();
            new StronglyTypedCollections();
            new DelegateInstanceCreationExpressions();
            new DelegateCovarianceAndContravariance();
            new AnonymousMethods();
            new NullableTypes();
            new ImplementingIterators();
            new PartialTypes();
            new StaticClasses();
            new SeparateGetterSetterPropertyAccess();
            new NamespaceAliases();
            new PragmaDirectives();
            new FixedSizeBuffers();
            new FriendAssemblies();
        }
    }
}