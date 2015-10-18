using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BloggingContext();
            List<Post> posts = new List<Post>();
            Post post = new Post
            {
                Title = "Title1"
            };
            posts.Add(post);

            var blog = new Blog
            {
                Url = "testurl",
                Posts = posts
            };
            ctx.Add(blog);
            ctx.SaveChanges();

            Console.ReadKey();
        }
    }
}
