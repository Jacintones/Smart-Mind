using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _categoryContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _categoryContext.Add(categoria);

            await _categoryContext.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(Categoria categoria)
        {
            _categoryContext.Categorias.Remove(categoria);

            await _categoryContext.SaveChangesAsync();
        }

        public async Task<ICollection<Categoria>> GetAll()
        {
            var categorias = await _categoryContext.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<Categoria> GetById(int id)
        {
            var categoria =  await _categoryContext.Categorias.Include(c => c.Materias).FirstOrDefaultAsync(c => c.Id == id);

            return categoria ?? throw new ArgumentNullException($"categoria com id {id} não existe");
        }

        public async Task<ICollection<Categoria>> GetCategoriaWithMateria()
        {
            return await _categoryContext.Categorias.AsNoTracking().Include(c => c.Materias).ToListAsync();
        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _categoryContext.Categorias.Update(categoria);

            await _categoryContext.SaveChangesAsync();

            return categoria;
        }
    }
}
