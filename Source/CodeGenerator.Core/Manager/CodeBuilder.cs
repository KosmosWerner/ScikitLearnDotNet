using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Xml.Linq;

namespace CodeGenerator.Core.Manager
{
    public static class CodeBuilder
    {
        public static ClassDeclarationSyntax PublicStaticClass(string name)
        {
            return SyntaxFactory.ClassDeclaration(name).AddModifiers(
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.StaticKeyword));
        }

        public static NamespaceDeclarationSyntax Namespace(string name)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("ScikitLearn"));
        }

        public static void Build(string outputDirectory, string fileName, IOrderedEnumerable<DummyContainer> sortedDummyContainers)
        {
            string filePath = Path.Combine(outputDirectory, $"{fileName}.cs");

            var uniqueStaticClasses = sortedDummyContainers
                .Select(dummy =>
                {
                    var (_, fullName, _) = RegexAnalyzer.FromDeclaration(dummy.Declaration);
                    var namespaceParts = fullName.Split('.');
                    return string.Join(".", namespaceParts[..^1]);
                })
                .Distinct();

            UsingDirectiveSyntax[] usings =
            [
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Numpy")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Python.Runtime")),
            ];

            var ScikitLearn = Namespace("ScikitLearn");
            var sklearn = PublicStaticClass("sklearn");

            foreach (DummyContainer dummyContainer in sortedDummyContainers)
            {
                switch (dummyContainer.EntityType)
                {
                    case EntityType.Class:
                        BuildClass(ref sklearn, dummyContainer);
                        break;
                    case EntityType.Method:
                        BuildMethod(ref sklearn, dummyContainer);
                        break;
                    case EntityType.Exception:
                        BuildException(ref sklearn, dummyContainer);
                        break;
                    case EntityType.None:
                    default: break;
                }
            }


            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddUsings(usings)
                .AddMembers(ScikitLearn)
                .NormalizeWhitespace();

            var code = compilationUnit.ToFullString();

            Directory.CreateDirectory(outputDirectory);
            File.WriteAllText(filePath, code);
        }

        public static MethodDeclarationSyntax AddMethod(ref ClassDeclarationSyntax @class, string name)
        {
            var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithBody(SyntaxFactory.Block());

            @class = @class.AddMembers(method);
            return method;
        }

        //public static ClassDeclarationSyntax AddClass(ref ClassDeclarationSyntax @class, string name)
        //{
        //    var @class = SyntaxFactory.MethodDeclaration(SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.VoidKeyword)), name)
        //        .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
        //        .WithBody(SyntaxFactory.Block());

        //    @class = @class.AddMembers(@class);
        //    return @class;
        //}

        private static void BuildClass(ref ClassDeclarationSyntax currentStaticClass, DummyContainer dummy)
        {
            var (_, fullName, fullParameters) = RegexAnalyzer.FromDeclaration(dummy.Declaration);




            foreach (var method in dummy.Methods)
            {

            }
        }

        private static void BuildMethod(ref ClassDeclarationSyntax currentStaticClass, DummyContainer dummy)
        {

        }

        private static void BuildException(ref ClassDeclarationSyntax currentStaticClass, DummyContainer dummy)
        {

        }
    }
}
