using Aladin.Domain.Models;
using Aladin.Service.DTO;
using Aladin.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aladin.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandeController(IDemandeService demandeService, ICarService carService) : ControllerBase
    {
        // GET: api/Demande/GetAll?page=1&pageSize=10&status=0
        [HttpGet("GetAll")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult GetAll(
            int page = 1,
            int pageSize = 10,
            RequestStatus? status = null)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;

            var query = demandeService.GetAll().AsQueryable();

            if (status.HasValue)
                query = query.Where(d => d.Status == status.Value);

            var totalCount = query.Count();

            var demandes = query
                .OrderByDescending(d => d.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new LeasingRequestDto
                {
                    Id = d.Id,
                    CarId = d.CarId,
                    CarName = d.Car != null ? $"{d.Car.Brand} {d.Car.Model}" : "",
                    Nom = d.Nom,
                    Region = d.Region,
                    Telephone = d.Telephone,
                    Metier = d.Metier,
                    RevenuMoyen = d.RevenuMoyen,
                    Salaire = d.Salaire,
                    Patente = d.Patente,
                    TerreAgricole = d.TerreAgricole,
                    RetenuParMois = d.RetenuParMois,
                    AutreRevenu = d.AutreRevenu,
                    AvanceDispo = d.AvanceDispo,
                    Status = d.Status,
                    CreatedAt = d.CreatedAt
                })
                .ToList();

            return Ok(new
            {
                page,
                pageSize,
                totalCount,
                totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                data = demandes
            });
        }

        // GET: api/Demande/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult GetById(int id)
        {
            var d = demandeService.GetAll().FirstOrDefault(x => x.Id == id);
            if (d == null) return NotFound();

            return Ok(new LeasingRequestDto
            {
                Id = d.Id,
                CarId = d.CarId,
                CarName = d.Car != null ? $"{d.Car.Brand} {d.Car.Model}" : "",
                Nom = d.Nom,
                Region = d.Region,
                Telephone = d.Telephone,
                Metier = d.Metier,
                RevenuMoyen = d.RevenuMoyen,
                Salaire = d.Salaire,
                Patente = d.Patente,
                TerreAgricole = d.TerreAgricole,
                RetenuParMois = d.RetenuParMois,
                AutreRevenu = d.AutreRevenu,
                AvanceDispo = d.AvanceDispo,
                Status = d.Status,
                CreatedAt = d.CreatedAt
            });
        }

        // PUT: api/Demande/UpdateStatus/5
        [HttpPut("UpdateStatus/{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult UpdateStatus(int id, [FromBody] UpdateDemandeStatusDto model)
        {
            var demande = demandeService.GetAll().FirstOrDefault(x => x.Id == id);
            if (demande == null) return NotFound();

            demande.Status = model.Status;
            demandeService.Update(demande);
            demandeService.Commit();

            return Ok(new { message = "Status updated successfully", status = demande.Status });
        }

        // DELETE: api/Demande/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int id)
        {
            var demande = demandeService.GetAll().FirstOrDefault(x => x.Id == id);
            if (demande == null) return NotFound();

            demandeService.Delete(demande);
            demandeService.Commit();

            return Ok(new { message = "Demande deleted successfully" });
        }

        // GET: api/Demande/Stats
        [HttpGet("Stats")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult GetStats()
        {
            var all = demandeService.GetAll();
            return Ok(new
            {
                total = all.Count(),
                pending = all.Count(d => d.Status == RequestStatus.Pending),
                contacted = all.Count(d => d.Status == RequestStatus.Contacted),
                approved = all.Count(d => d.Status == RequestStatus.Approved),
                rejected = all.Count(d => d.Status == RequestStatus.Rejected)
            });
        }
    }

    public class UpdateDemandeStatusDto
    {
        public RequestStatus Status { get; set; }
    }
}
