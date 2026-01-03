using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Aladin.Data.Infrastructures
{
    public interface IDatabaseFactory : IDisposable
    {
        IdentityDbContext DataContext { get; }
    }
}
