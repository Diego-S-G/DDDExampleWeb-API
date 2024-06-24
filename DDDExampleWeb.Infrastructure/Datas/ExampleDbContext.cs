using DDDExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDExampleWeb.Infrastructure.Datas
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
        public virtual DbSet<Example> Examples { get; set; }
    }
}
