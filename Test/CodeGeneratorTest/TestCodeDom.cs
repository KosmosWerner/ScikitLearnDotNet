using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CSharp;

namespace CodeGeneratorTest
{
    public class TestCodeDom
    {
        [Fact]
        public void DOM()
        {
            UsingDirectiveSyntax[] usings =
            [
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Numpy")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Python.Runtime")),
            ];

            var ScikitLearn = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName("ScikitLearn"));

            var sklearn = SyntaxFactory.ClassDeclaration("sklearn")
                .AddModifiers(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                    SyntaxFactory.Token(SyntaxKind.StaticKeyword));




            ScikitLearn = ScikitLearn.AddMembers(sklearn);
            var compilationUnit = SyntaxFactory.CompilationUnit()
                .AddUsings(usings)
                .AddMembers(ScikitLearn)
                .NormalizeWhitespace();

            var code = compilationUnit.ToFullString();

            Console.WriteLine(code);
        }
    }
}
