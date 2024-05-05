using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;

namespace Smart_Mind.infrastructure.Repositories
{
    public class AssuntoRepository : IAssuntoRepository
    {
        private readonly ApplicationDbContext _context;

        public AssuntoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Assunto> Create(Assunto assunto)
        {
            _context.Assuntos.Add(assunto);

            await _context.SaveChangesAsync();

            return assunto;
        }

        public async Task Delete(Assunto assunto)
        {
            _context.Assuntos.Remove(assunto);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Assunto>> GetAll()
        {
            var assuntos = await _context.Assuntos.ToListAsync();

            return assuntos;
        }

        public async Task<Assunto> GetById(int id)
        {
            return await _context.Assuntos.FindAsync(id);
        }

        public async Task<Assunto> Update(Assunto assunto)
        {
            _context.Assuntos.Update(assunto);

            await _context.SaveChangesAsync();

            return assunto;
        }
    }
}
