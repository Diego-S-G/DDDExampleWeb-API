using DDDExampleWeb.Domain.Entities;
using DDDExampleWeb.Domain.Interfaces;
using DDDExampleWeb.Infrastructure.Datas;
using Microsoft.EntityFrameworkCore;

namespace DDDExampleWeb.Infrastructure.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly ExampleDbContext _context;
        public ExampleRepository(ExampleDbContext context)
        {
            _context = context;
        }

        private Example GetExampleById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var entity = _context.Examples.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }
        public async Task<Example> CreateAsync(Example example)
        {
            await _context.Examples.AddAsync(example);

            _context.SaveChanges();
            return example;
        }
        public bool Delete(int id)
        {
            var entity = GetExampleById(id);

            if (entity == null)
            {
                return false;
            }

            _context.Examples.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<Example> GetCompleteAsync(int id)
        {
            var entity = GetExampleById(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<IEnumerable<Example>> GetListAsync()
        {
            var entity = await _context.Examples.ToListAsync();

            return entity;
        }

        public async Task<Example> UpdateAsync(int id, Example example)
        {
            var entity = GetExampleById(id);

            if (entity == null)
            {
                return null;
            }

            entity.PropertyName1 = example.PropertyName1;
            entity.PropertyName2 = example.PropertyName2;
            entity.PropertyName3 = example.PropertyName3;

            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}