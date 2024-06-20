using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.context {
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) {    
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

    }


}

