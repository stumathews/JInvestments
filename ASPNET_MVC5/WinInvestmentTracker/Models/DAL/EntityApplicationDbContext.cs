using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WinInvestmentTracker.Models.DAL.Interfaces;
using WinInvestmentTracker.Models.DEL.Interfaces;

namespace WinInvestmentTracker.Models.DAL
{
    /// <summary>
    /// Class implementation that will expose the underlying entity framework entities without having to name the entity collection memeber
    /// on the dbcontext.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityApplicationDbContext<T> : IEntityApplicationDbContext<T> where T : class, IDbInvestmentEntity
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();
        public DbSet<T> Entities => _db.Set<T>();

        public DbSet<T1> GetEntityByType<T1>() where T1 : class => _db.Set<T1>();

        public void SaveChanges() => _db.SaveChanges();
    }
}