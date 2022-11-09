using fornecedorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace fornecedorApi.Data
{
    public class ApiDbContext:DbContext
    {
       public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options) 
        {
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }

    }
}
