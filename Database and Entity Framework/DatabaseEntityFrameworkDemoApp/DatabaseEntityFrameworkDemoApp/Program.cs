using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;   /*Wrap the resources in a using statement which auto disposes when the statement loses scope, like finally*/
using System.Data.Entity;      /*Need after adding EF to project.  This is the namespace of the DLL supporting our project*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseEntityFrameworkDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdoNetSample();
            EntityFrameworkSample();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void EntityFrameworkSample()
        {
            using (var ctx = new AppContext())
            {
                var newPost = new BlogPost
                {
                    Title = "Entity Framework",
                    Body = "This is going to be sooo much easier than ADO.NET!"
                };

                ctx.BlogPosts.Add(newPost);
                ctx.SaveChanges();
                Console.WriteLine(string.Format("Blog post #{0} created successfully.", newPost.Id));
            }
        }





        private static void AdoNetSample()
        {
            /*This establishes SQL connection but does not open it yet*/
            using (var conn = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=BlogDemo;Integrated Security=True"))
            {  
                //This is creating a cmd to send to SQL server using the conn we established
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text; // cmd type is typically going to be text

                    var newPost = new BlogPost
                    {
                        Title = "Another Post!",
                        Body = "I'm on a roll now!"
                    };
                    
                    // 1:03 If you're using raw ADO.NET always sanitize inputs like this (you don't want to use ADO.net)
                    // Always parameterize your inputs http://bobby-tables.com avoid SQLInjection 
                    cmd.Parameters.Add("@title", System.Data.SqlDbType.VarChar).Value = newPost.Title;
                    cmd.Parameters.Add("@body", System.Data.SqlDbType.NVarChar).Value = newPost.Body;

                    //  1:04  When you do a form post you create the object you need to get the id back because 
                    //  you want to go to the detail page
                    // Don't use @@IDENTITY!!! 
                    cmd.CommandText = "INSERT INTO BlogPosts (Title, Body) VALUES (@title, @body); SELECT SCOPE_IDENTITY();";

                    try   // Always in try catch
                    {
                        conn.Open();
                        //1:05:40 executescalar will return the first column of the first row of the result set (which is why you want to use id in the 1st column)
                        // it actually returns an object.  So have to caste to decimal then int
                        newPost.Id = (int)(decimal)(cmd.ExecuteScalar()); //
                        Console.WriteLine(string.Format("Blog Post #{0} created successfully.", newPost.Id));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


    }

    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string Body { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        // NOTE: We recommend to NOT use navigation properties, but you can if you want.
        public ICollection<BlogPostComment> Comments { get; set; }
    }

    public class BlogPostComment
    {
        [Key]
        public int Id { get; set; }

        public int BlogPostId { get; set; }

        [MaxLength(4000)]
        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        // NOTE: We recommend to NOT use navigation properties, but you can if you want.
        public BlogPost BlogPost { get; set; }
    }

    public class AppContext : DbContext
    {
        public AppContext()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=BlogDemo;Integrated Security=True")
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogPostComment> BlogPostComments { get; set; }
    }
}
