using Microsoft.EntityFrameworkCore;

namespace CalifornianHealth.Infrastructure.Database.Entities
{
    public partial class ConsultantCalendar
    {
        public int Id { get; set; }
        public int? ConsultantId { get; set; }
        public DateTime? Date { get; set; }
        public bool? Available { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultantCalendar>(c =>
            {
                c.HasKey(x => x.Id);
                c.ToTable(nameof(ConsultantCalendar));
            });
        }
    }
}
