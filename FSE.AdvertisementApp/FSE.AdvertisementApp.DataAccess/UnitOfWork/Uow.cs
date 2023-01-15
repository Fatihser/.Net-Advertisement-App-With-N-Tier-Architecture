using FSE.AdvertisementApp.DataAccess.Context;
using FSE.AdvertisementApp.DataAccess.Interfaces;
using FSE.AdvertisementApp.DataAccess.Repositories;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow:IUow
    {
        private readonly AdvertisementContext _context;

        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
