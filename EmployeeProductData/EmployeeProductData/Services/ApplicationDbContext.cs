using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProductData.Models;

namespace EmployeeProductData.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<ProductModel> tbl_products { get; set; }
    }
}
