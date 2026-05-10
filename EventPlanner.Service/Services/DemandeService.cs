using Aladin.Data.Infrastructures;
using Aladin.Domain.Models;
using Aladin.Service.Interfaces;
using Service.Pattern;

namespace Aladin.Service.Services
{
    public class DemandeService : Service<Demande>, IDemandeService
    {
        public DemandeService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
