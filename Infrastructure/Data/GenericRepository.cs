using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    
    public class GenericRepository: IGenericRepository<T> where T: BaseEntity
    {

        public async Task<T> GetByIdAsync(int id)
        {
            return await;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await;
        }
    }
}