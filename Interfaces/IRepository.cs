using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Interfaces
{
    public interface IRepository<T>
    {
        Task AddAsync(T t);
        Task DeleteAsync(int id);
        Task UpdateAsync(T t, int id);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> FindAsync(T t);
    }
}
