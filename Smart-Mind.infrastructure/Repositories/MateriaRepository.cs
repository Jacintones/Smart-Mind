using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;

namespace Smart_Mind.infrastructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {

        private readonly ApplicationDbContext _context;

        public MateriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Materia> Create(Materia materia)
        {
            _context.Materias.Add(materia);

            await _context.SaveChangesAsync();

            return materia;
        }

        public async Task Delete(Materia materia)
        {
            _context.Materias.Remove(materia);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Materia>> GetAll()
        {
            var materias = await _context.Materias.ToListAsync();

            return materias;
        }

        public async Task<Materia> GetById(int id)
        {
            return await _context.Materias.Include(m => m.Assuntos).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ICollection<Materia>> GetMateriaWithAssunto()
        {
            throw new NotImplementedException();
        }

        public async Task<Materia> Update(Materia materia)
        {
            _context.Materias.Update(materia);

            await _context.SaveChangesAsync();

            return materia;
        }
    }
}
