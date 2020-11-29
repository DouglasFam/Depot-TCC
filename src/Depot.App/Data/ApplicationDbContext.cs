using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Depot.App.ViewModels;

namespace Depot.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }     
        public DbSet<Depot.App.ViewModels.AcaoViewModel> AcaoViewModel { get; set; }
        public DbSet<Depot.App.ViewModels.HistoricoProdutoViewModel> HistoricoProdutoViewModel { get; set; }
       

    }
}
