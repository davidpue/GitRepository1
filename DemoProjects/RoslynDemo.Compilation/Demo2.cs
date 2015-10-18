using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDemo.Compilation
{
    class Demo2
    {
        public void Execute()
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
               @"
                using System;
                using System.Collection.Generic;
                using System.Text;

                namespace HelloWorld
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            var x = ""Teststring"";
                            Console.WriteLine(""HelloHello"");
                        }
                    }
                }");

            var root = (CompilationUnitSyntax)tree.GetRoot(); //Syntax Model
            var compilation = CSharpCompilation.Create("HelloWorld")
                                               .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                                               .AddSyntaxTrees(tree);

            var model = compilation.GetSemanticModel(tree);
            var nameInfo = model.GetSymbolInfo(root.Usings.First().Name);
            var systemSymbol = (INamespaceSymbol)nameInfo.Symbol;

            foreach (var ns in systemSymbol.GetNamespaceMembers())
            {
                Console.WriteLine(ns.Name);
            }
            
            var helloWorldString = root.DescendantNodes()
                                        .OfType<LiteralExpressionSyntax>()
                                        .First();

            var rootMainMethod = root.DescendantNodes().OfType<MethodDeclarationSyntax>().First();

            var literalInfo = model.GetTypeInfo(helloWorldString);
            var stringTypeSymbol = (INamedTypeSymbol)literalInfo.Type;

            Console.Clear();

            var names = stringTypeSymbol.GetMembers()
                                        .OfType<IMethodSymbol>()
                                        .Where(x => x.ReturnType.Equals(stringTypeSymbol)
                                                && x.DeclaredAccessibility == Accessibility.Public)
                                        .Select(k => k.Name).Distinct();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }

    }
}
