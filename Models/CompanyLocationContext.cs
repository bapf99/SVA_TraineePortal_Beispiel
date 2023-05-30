using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using SVA_TraineePortal.Models.DTO;

namespace SVA_TraineePortal.Models
{
    public class CompanyLocationContext : DbContext
    {

        public CompanyLocationContext(DbContextOptions<CompanyLocationContext> options) : base(options) { }

        public DbSet<CompanyLocation> CompanyLocations { get; set; } = null!;

        //public DbSet<SVA_TraineePortal.Models.DTO.CompanyLocationDTO>? CompanyLocationDTO { get; set; }
    }
}
