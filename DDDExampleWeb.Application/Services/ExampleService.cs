using DDDExampleWeb.Application.Interfaces;
using DDDExampleWeb.Domain.Entities;
using DDDExampleWeb.Domain.Interfaces;

namespace DDDExampleWeb.Application.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;
        public ExampleService(IExampleRepository repository)
        {
            _exampleRepository = repository;
        }

        public Task<Example> CreateAsync(Example example)
        {
            return _exampleRepository.CreateAsync(example);
        }

        public bool Delete(int id)
        {
            return _exampleRepository.Delete(id);
        }

        public Task<Example> GetCompleteAsync(int id)
        {
            return _exampleRepository.GetCompleteAsync(id);
        }

        public Task<IEnumerable<Example>> GetListAsync()
        {
            return _exampleRepository.GetListAsync();
        }

        public Task<Example> UpdateAsync(int id, Example example)
        {
            return _exampleRepository.UpdateAsync(id, example);
        }
    }
}