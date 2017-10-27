using System;
using System.Data.Entity;

namespace WinInvestmentTracker.Models.DAL
{
    public interface IApplicationDbContext<T> where T : class
    {
        DbSet<T> Entities { get; }
        void SaveChanges();
        DbSet<T1> GetEntityByType<T1>() where T1 : class;
    }
}