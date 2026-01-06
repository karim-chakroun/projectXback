using Aladin.Data.Infrastructures;
using Aladin.Domain;
using Aladin.Service.Interfaces;
using Service.Pattern;

namespace Aladin.Service.Services
{
    public class ExempleService : Service<Exemple>, IExempleService
    {
        public ExempleService(IUnitOfWork utk) : base(utk)
        {
        }
    }
}
