using Microsoft.EntityFrameworkCore;

namespace Inspection.Data
{
    public class DataContext: DbContext
    {
        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { } 

        public DbSet<Inspection> Inspections { get; set; }

        public DbSet<InspectionTypes> InspectionTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }
}
