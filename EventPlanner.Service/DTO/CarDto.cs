namespace Aladin.Service.DTO
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public decimal Price { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int DurationMonths { get; set; }
        public decimal DownPayment { get; set; }

        public string FuelType { get; set; }
        public string Gearbox { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
    }
}
