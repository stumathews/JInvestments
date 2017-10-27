using System.Data.Entity;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.DAL.Interfaces
{
    /// <summary>
    /// A interface for a class that exposes entities by specified type
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