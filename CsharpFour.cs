namespace CsharpShowreel
{
    /// <summary>
    /// C# 4 new features:
    ///   - COM stuff: dynamic types, some optimisations and facilities (streamlining ref parameters in COM, embedding COM Primary Interop Assemblies)
    ///   - bonus: TPL library
    /// </summary>
    public class CsharpFour
    {
        public class NamedArguments
        {
            public void OrdinaryMethod(int firstOrdinaryArgument, int secondOrdinaryArgument)
            {
                System.Console.WriteLine("UsualMethod, firstOrdinaryArgument: " + firstOrdinaryArgument + ", secondOrdinaryArgument: " + secondOrdinaryArgument);
            }

            public NamedArguments()
            {
                OrdinaryMethod(secondOrdinaryArgument: 2, firstOrdinaryArgument: 1);
            }
        }

        public class OptionalParameters
        {
            public void MethodWithOptionalParameters(int firstParam, int secondParam = 2, int thirdParam =3)
            {
                System.Console.WriteLine("UsualMethod, firstParam: " + firstParam 
                    + ", secondParam: " + secondParam
                    + ", thirdParam: " + thirdParam);
            }

            public OptionalParameters()
            {
                MethodWithOptionalParameters(1, 1);
            }
        }

        public class DynamicType
        {
            public DynamicType()
            {
                dynamic youNeverKnow = "asdsad";
                System.Console.WriteLine(youNeverKnow.ToUpper());
                try
                {
                    youNeverKnow.NonExistingMethod();
                }
                catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
                {
                    System.Console.WriteLine("Compiler accpeted a NonExistingMethod method call on youNeverKnow object, because it is dynamic.");
                }
            }
        }

        public class GenericVarianceForInterfaces
        {
            private class Base {}

            private class Derived : Base {}

            private interface IFactory<in T, out U>
            {
                U Create(T input);
            }

            private class ObjectToDerivedFactory : IFactory<object, Derived>
            {
                public Derived Create(object input)
                {
                    return new Derived();
                }
            }

            public GenericVarianceForInterfaces()
            {
                IFactory<string, Base> variancedFactory = new ObjectToDerivedFactory();
                Base derivedActually =  variancedFactory.Create("some string, while actually bound method accepts object");
            }
        }

        public class GenericVarianceForDelegates
        {
            private class Base {}

            private class Derived : Base {}

            private delegate Base StringToBaseDelegate(string inout);

            public GenericVarianceForDelegates()
            {
                StringToBaseDelegate objectToDerivedByDelegate = ObjectToDerivedMethod;
                objectToDerivedByDelegate = new StringToBaseDelegate(ObjectToDerivedMethod);
                System.Func<string, Base> objectToDerivedByFunc = ObjectToDerivedMethod; // TODO not sure when Func was defined
            }

            private Derived ObjectToDerivedMethod(object inout)
            {
                return new Derived();
            }
        }

        public class ChangesInLocking
        {

        }

        public class ChangesInFieldLikeEvents
        {

        }

        public CsharpFour()
        {
            new NamedArguments();
            new OptionalParameters();
            new DynamicType();
            new GenericVarianceForInterfaces();
        }
    }
}