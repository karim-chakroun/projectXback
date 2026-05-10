using Aladin.Data.Infrastructures;
using Aladin.Domain.Models;
using Aladin.Service.Interfaces;
using Service.Pattern;

namespace Aladin.Service.Services
{
    public class CarService : Service<Car>, ICarService
    {
        public CarService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}