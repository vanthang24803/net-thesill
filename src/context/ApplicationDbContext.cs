using Api.TheSill.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace Api.TheSill.src.context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        DbSet<UserEntity> Users { get; set; }
    }
}