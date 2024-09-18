using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServerBlazorDemo.Models;

public partial class BlazorDbContext : DbContext
{
    public BlazorDbContext()
    {
    }

    public BlazorDbContext(DbContextOptions<BlazorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Student> Students { get; set; }
}
