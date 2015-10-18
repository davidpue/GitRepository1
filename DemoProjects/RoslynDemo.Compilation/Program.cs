using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDemo.Compilation
{
    class Program
    {

        static void Main(string[] args)
        {
            // Execute();
            //new Demo2().Execute();
            new Demo3().Execute();
        }

        static void Execute()
        {
            var someCode = @"

            using System;
            namespace DemoApp
            {
                public class Program 
                {
                    static void Main(){}

                    public int Calculate()
                    {
                        return 40 + 2;
                    }
                }
            }";

            var syntaxTree = CSharpSyntaxTree.ParseText(someCode);

            var compilationOptions = new CSharpCompilationOptions(OutputKind.ConsoleApplication);

            List<MetadataReference> references = new List<MetadataReference>()
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
            };

            var compilation = CSharpCompilation.Create("SampleApp", options: compilationOptions)
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);

            using (var outputStream = new MemoryStream())
            using (var pdbStream = new MemoryStream())
            {
                var result = compilation.Emit(peStream: outputStream, pdbStream: pdbStream);
                if (result.Success)
                {
                    var assembly = Assembly.Load(outputStream.ToArray(), pdbStream.ToArray());
                    var types = assembly.GetTypes();
                    dynamic instance = Activator.CreateInstance(assembly.GetTypes().First());
                    var opResult = instance.Calculate();
                    Console.WriteLine(opResult);
                }
                else
                {
                    foreach (var diganostic in result.Diagnostics)
                    {
                        Console.WriteLine(diganostic);
                    }
                }
            }
            Console.Read();

        }
    }
}
