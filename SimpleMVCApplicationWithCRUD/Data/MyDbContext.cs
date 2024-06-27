using Microsoft.EntityFrameworkCore;
using SimpleMVCApplicationWithCRUD.Models;

namespace SimpleMVCApplicationWithCRUD.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
                
        }
        //dbset must be created in this file for all the models in the application
        public DbSet<Category> Categories { get; set; }
    }
}
