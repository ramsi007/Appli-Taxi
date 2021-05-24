using Appli_Taxi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appli_Taxi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TypeCat> TypeCats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<ShooppingCart> ShooppingCarts { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalDetail> ProposalDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<CreeditNote> CreeditNotes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<HolidayType> HolidayTypes { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<ExpenseReport> ExpenseReports { get; set; }

    }
}
