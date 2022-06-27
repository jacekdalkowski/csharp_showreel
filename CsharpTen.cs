namespace CsharpShowreel;


/// <summary>
/// C# 10 new features:
/// </summary>
public class CsharpTen
{

    // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
    public class RecordStructs
    {
        // Positional properties are immutable in a record class and a readonly record struct. They're mutable in a record struct.
        public readonly record struct Point_1(double X, double Y, double Z);

        public record struct Point_2
        {
            public double X {  get; init; }
            public double Y {  get; init; }
            public double Z {  get; init; }
        }
    }

    public class ImprovementsOfStructureTypes
    {
        // init improvments
        public readonly struct Measurement
        {
            public double Value { get; init; }
            public string Description { get; init; }

            public Measurement()
            {
                Value = double.NaN;
                Description = "Undefined";
            }

            public Measurement(double value, string description)
            {
                Value = value;
                Description = description;
            }
        }

        // TODO: "A left-hand operand of the with expression can be of any structure type or an anonymous (reference) type."

        public ImprovementsOfStructureTypes()
        {
            Measurement m = new Measurement() with { Value = 2d };
        }
    }

    public class InterpolatedStringHandlers
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/interpolated-string-handler
    }

    public class GlobalUsingDirectives
    {
        // global using is applied to all files in the compilation (typically a project)
        // global using static System.Math;
    }

    public class FileScopedNamespaceDeclaration
    {
        // namespace X.Y.Z;
        // instead of 
        // namespace X.Y.Z { }
        // see this file
    }

    public class ExtendedPropertyPatterns
    {
        public class ProvinceOrStateTax
        {
            public string ProvinceOrState { get; set; }
        }

        public class CountryTax
        {
            public string CountryName { get; set; }
            public ProvinceOrStateTax ProvinceTaxProperty { get; set; }
        }

        private static decimal ComputePrice(CountryTax calculate, decimal price) =>

        calculate switch
        {
            { ProvinceTaxProperty.ProvinceOrState: "Québec" } => 1.14975M * price,
            { ProvinceTaxProperty.ProvinceOrState: "Alberta" } => 1.05M * price,
            { ProvinceTaxProperty.ProvinceOrState: "Ontario" } => 1.13M * price,
            _ => 0
        };

    }

    public class ImprovementsOnLambdaExpressions
    {
        public ImprovementsOnLambdaExpressions()
        {
            var getUserInput = System.Console.ReadLine;
            var tellUser = (string s) => System.Console.WriteLine(s);
        }
    }

    public class AllowConstInterpolatedStrings
    {
        private const string scheme = "https";
        private const string LoginUri = "login";
        private const string HomeUri = "home";

        private const string dev = $"{scheme}://localhost:5001";

        private const string LoginUriDev = $"{dev}/{LoginUri}";
        private const string HomeUriDev = $"{dev}/myaccount/{HomeUri}";

        public AllowConstInterpolatedStrings()
        {

        }
    }

    public class RecordTypesCanSealToString
    {
        public record class GetGroupTicketPriceDiscount
        {
            public string Id { get; init; }

            public GetGroupTicketPriceDiscount(string id)
            {
                Id = id;
            }

            public override sealed string ToString()
            {
                return $"Id: {Id}";
            }
        }
    }

    public class ImprovedDefiniteAssignment
    {
        public bool ToString(out string s)
        {
            s = "a";
            return true;
        }

        public ImprovedDefiniteAssignment(ImprovedDefiniteAssignment? c)
        {
            string representation = "N/A";
            if (c != null && c.ToString(out string stringified))
            {
                representation = stringified.ToString(); // undesired error
            }

            // Or, using ?.
            if (c?.ToString(out string stringified2) == true)
            {
                representation = stringified2.ToString(); // undesired error
            }

            // Or, using ??
            if (c?.ToString(out string stringified3) ?? false)
            {
                representation = stringified3.ToString(); // undesired error
            }
        }
    }

    public class AllowBothAssignmentAndDeclarationInTheSameDeconstruction
    {
        public readonly struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        public AllowBothAssignmentAndDeclarationInTheSameDeconstruction()
        {
            var point = new Point(1, 2);
            // This change removes a restriction from earlier versions of C#. 
            // Previously, a deconstruction could assign all values to existing variables, or initialize newly declared variables:
            int x = 0;
            (x, int y) = point;
        }
    }

    public class AllowAsyncMethodBuilderAttributeOnMethods
    {
        // This is a bit hardcore:
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/general#asyncmethodbuilder-attribute
    }

    public class CallerArgumentExpressionAttribute
    {
        public static void ValidateArgument(string parameterName, bool condition, [System.Runtime.CompilerServices.CallerArgumentExpression("condition")] string? message=null)
        {
            if (!condition)
            {
                throw new System.ArgumentException($"Argument failed validation: <{message}>", parameterName);
            }
        }

        public CallerArgumentExpressionAttribute()
        {
            var func = () => {};
            ValidateArgument(nameof(func), func is not null);
        }
    }

    public CsharpTen()
    {
        new RecordStructs();
        new ImprovementsOfStructureTypes();
        new InterpolatedStringHandlers();
        new GlobalUsingDirectives();
        new FileScopedNamespaceDeclaration();
        new ExtendedPropertyPatterns();
        new ImprovementsOnLambdaExpressions();
        new AllowConstInterpolatedStrings();
        new RecordTypesCanSealToString();
        new ImprovedDefiniteAssignment(null);
        new AllowBothAssignmentAndDeclarationInTheSameDeconstruction();
        new CallerArgumentExpressionAttribute();
    }
}