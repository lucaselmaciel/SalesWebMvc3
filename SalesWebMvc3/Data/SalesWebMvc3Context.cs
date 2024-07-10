﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc3.Models;

namespace SalesWebMvc3.Data
{
    public class SalesWebMvc3Context : DbContext
    {
        public SalesWebMvc3Context (DbContextOptions<SalesWebMvc3Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
