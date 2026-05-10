namespace Aladin.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }        // Kia, Peugeot…
        public string? Model { get; set; }        // Rio, 208…
        public int Year { get; set; }
        public decimal Price { get; set; }       // Car price
        public decimal MonthlyPayment { get; set; }   // Leasing monthly
        public int DurationMonths { get; set; }  // 36, 48, 60
        public decimal DownPayment { get; set; } // Apport
        public string? FuelType { get; set; }
        public string? Gearbox { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;   // DISPONIBLE / NON DISPO
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // 🔗 One Car → Many Demandes
        public virtual ICollection<Demande> Demandes { get; set; }
    }
}
