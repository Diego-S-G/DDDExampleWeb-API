using DDDExampleWeb.Domain.Entities;

namespace DDDExampleWeb.Domain.Interfaces
{
    public interface IExampleRepository
    {
        Task<IEnumerable<Example>> GetListAsync();
        Task<Example> GetCompleteAsync(int id);
        Task<Example> CreateAsync(Example example);
        Task<Example> UpdateAsync(int id, Example example);
        bool Delete(int id);
    }
}
