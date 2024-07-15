using Microsoft.EntityFrameworkCore;
using SimpleMVCApplicationWithCRUD.Models;

namespace SimpleMVCApplicationWithCRUD.Data
{
    public class MyDbContext: DbContext
    {
        // here, we create a constructor to establish the connection with entity framework
        // this is a general syntax
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
                
        }
        //dbset must be created in this file for all the models in the application
        public DbSet<Category> Categories { get; set; }
    }
}
