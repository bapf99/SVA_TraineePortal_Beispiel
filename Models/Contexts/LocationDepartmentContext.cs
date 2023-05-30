using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using SVA_TraineePortal.Models.DTO;

namespace SVA_TraineePortal.Models.Contexts
{
    public class LocationDepartmentContext : DbContext
    {
        public LocationDepartmentContext(DbContextOptions<LocationDepartmentContext> options) : base(options) { }

        public DbSet<LocationDepartment> LocationDepartments { get; set; } = null!;

    }
}
