using System.Data.Entity;
using System.Threading.Tasks;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.DAL.Interfaces
{
    /// <summary>
    /// Provides specific entity type services
    /// </summary>
    /// <typeparam name="T">The type of the underlying entity that this class will manage</typeparam>
    public interface IEntityApplicationDbContext<T> where T : class, IDbInvestmentEntity
    {
        /// <summary>
        /// The underlying entities that this class will expose
        /// </summary>
        DbSet<T> Entities { get; }

        /// <summary>
        /// The ability to save <see cref="Entities"/> 
        /// </summary>
        void SaveChanges();

        DbSet<T1> GetEntityByType<T1>() where T1 : class;
    }
}