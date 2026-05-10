using System.ComponentModel.DataAnnotations.Schema;

namespace Aladin.Domain.Models
{
    public class Demande
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Region { get; set; }
        public string? Telephone { get; set; }
        public string? Metier { get; set; }
        public string? RevenuMoyen { get; set; }
        public string? Salaire { get; set; }
        public bool Patente { get; set; }
        public bool TerreAgricole { get; set; }
        public string? RetenuParMois { get; set; }
        public string? AutreRevenu { get; set; } = "no";
        // 🔗 Foreign Key
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
        public string? AvanceDispo { get; set; }
    }
}
