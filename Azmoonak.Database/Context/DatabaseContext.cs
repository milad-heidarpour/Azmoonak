using Azmoonak.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azmoonak.Database.Context;

public class DatabaseContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(@"Data source=.;
                            Initial Catalog=AzmoonakDATABASE;
                            Integrated Security=SSPI");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
}
