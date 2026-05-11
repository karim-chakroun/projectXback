using Aladin.Domain.Models;

namespace Aladin.Service.DTO
{
    public class LeasingRequestDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string? CarName { get; set; }
        public string? Nom { get; set; }
        public string? Region { get; set; }
        public string? Telephone { get; set; }
        public string? Metier { get; set; }
        public string? RevenuMoyen { get; set; }
        public string? Salaire { get; set; }
        public bool Patente { get; set; }
        public bool TerreAgricole { get; set; }
        public string? RetenuParMois { get; set; }
        public string? AutreRevenu { get; set; }
        public string? AvanceDispo { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
