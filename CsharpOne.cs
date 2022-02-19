namespace CsharpShowreel
{
    /// <summary>
    /// C# 1 features:
    ///  - Java + properties
    /// </summary>
    public class CsharpOne
    {
        public class ReadonlyProperties
        {
            private string _name;
            public string Name { get { return _name; } }

            public ReadonlyProperties()
            {
                _name = "Property";
            }
        }

        public class WeaklyTypedCollections 
        {
            private System.Collections.ArrayList _arrayList;
            private System.Collections.Hashtable _hashTable;
            private System.Collections.Stack _stack;
            private System.Collections.Queue _queue;

            public WeaklyTypedCollections()
            {
                _arrayList = new System.Collections.ArrayList();
                _arrayList.Add(1);
                _arrayList.Add(new System.Object());

                _hashTable = new System.Collections.Hashtable();
                _hashTable.Add(1, "value for 1");
                _hashTable.Add("2", new System.Object());

                _stack = new System.Collections.Stack();
                _stack.Push(1);
                _stack.Push("2");

                _queue = new System.Collections.Queue();
                _queue.Enqueue(1);
                _queue.Enqueue("2");
            }
        }
    }
}
