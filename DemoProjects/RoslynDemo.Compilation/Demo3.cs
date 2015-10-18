using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDemo.Compilation
{
    class Demo3
    {
        public void Execute()
        {
            var statement = @"
                            public void SomeMethod(int someValue)
                            {
                                try
                                {
                                    var result = someValue / 0;
                                }
                                catch (Exception ex)
                                {
                                }
                            }";

            var tree = CSharpSyntaxTree.ParseText(statement);
            Console.WriteLine(tree.ToString());
            new CatchSyntaxWalker().Visit(tree.GetRoot());

            Console.WriteLine(new CatchSyntaxRewriter().Visit(tree.GetRoot()));
            Console.Read();
        }
    }
}
