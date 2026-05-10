using Aladin.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aladin.Service.DTO
{
    public class CreateLeasingRequestDto
    {
        public int CarId { get; set; }   // Selected car
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
        public string? AvanceDispo { get; set; }
    }
}
