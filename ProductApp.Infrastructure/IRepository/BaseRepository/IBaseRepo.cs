using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.IRepository.BaseRepository
{
    public interface IBaseRepo
    {
        Task<bool> SaveChangesAsync();
    }
}
