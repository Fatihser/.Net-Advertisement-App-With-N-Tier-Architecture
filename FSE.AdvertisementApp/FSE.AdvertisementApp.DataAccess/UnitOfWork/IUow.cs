using FSE.AdvertisementApp.DataAccess.Interfaces;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUow
    {
       IRepository<T> GetRepository<T>() where T : BaseEntity;

       Task SaveChangesAsync();
    }
}
