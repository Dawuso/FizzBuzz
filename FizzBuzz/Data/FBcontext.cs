using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Do_bazy;

namespace FizzBuzz.Data
{
    public class FBcontext : DbContext
    {
        public FBcontext(DbContextOptions<FBcontext> options) : base(options) { }
        public DbSet<DoBazy> DoBazy { get; set; }
    }
}
