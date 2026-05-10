using Aladin.Domain.Models;
using Aladin.Service.DTO;
using Aladin.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aladin.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController(ICarService carService, IDemandeService demandeService) : ControllerBase
    {
        [HttpGet("getAllCars")]
        public async Task<ActionResult> GetAll(
            int page = 1,
            int pageSize = 10
        )
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = carService.GetAll(); // IEnumerable<Car> or IQueryable<Car>

            var totalCount = query.Count();

            var cars = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CarDto
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    MonthlyPayment = c.MonthlyPayment,
                    DurationMonths = c.DurationMonths,
                    DownPayment = c.DownPayment,
                    FuelType = c.FuelType,
                    Gearbox = c.Gearbox,
                    ImageUrl = c.ImageUrl,
                    IsAvailable = c.IsAvailable
                })
                .ToList();

            return Ok(new
            {
                page,
                pageSize,
                totalCount,
                totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                data = cars
            });
        }
        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(CreateCarDto model)
        {
            try
            {
                var car = new Car
                {
                    Brand = model.Brand,
                    Model = model.Model,
                    Year = model.Year,
                    Price = model.Price,
                    MonthlyPayment = model.MonthlyPayment,
                    DurationMonths = model.DurationMonths,
                    DownPayment = model.DownPayment,
                    FuelType = model.FuelType,
                    Gearbox = model.Gearbox,
                    ImageUrl = model.ImageUrl,
                    IsAvailable = true
                };

                carService.Add(car);
                carService.Commit();

                return Ok(car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Demande")]
        public async Task<Object> AddDemande(CreateLeasingRequestDto model)
        {
            try
            {
                Demande demande = new Demande
                {
                    CarId = model.CarId,
                    Metier = model.Metier,
                    AutreRevenu = model.AutreRevenu,
                    AvanceDispo = model.AvanceDispo,
                    Nom = model.Nom,
                    Patente = model.Patente,
                    RetenuParMois = model.RetenuParMois,
                    Telephone = model.Telephone,
                    TerreAgricole = model.TerreAgricole,
                    Region = model.Region,
                    RevenuMoyen = model.RevenuMoyen,
                    Salaire = model.Salaire,
                };
                demandeService.Add(demande);
                demandeService.Commit();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
