using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;

namespace Smart_Mind.infrastructure.Repositories
{
    public class ExplicacaoAssuntoRepositorio : IExplicacaoAssuntoRepositorio
    {
        public readonly ApplicationDbContext _context;

        public ExplicacaoAssuntoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExplicacaoAssunto> Create(ExplicacaoAssunto explicacaoAssunto)
        {
            _context.ExplicacaoAssuntos.Add(explicacaoAssunto);

            await _context.SaveChangesAsync();

            return explicacaoAssunto;
        }

        public async Task<ExplicacaoAssunto> Delete(ExplicacaoAssunto explicacaoAssunto)
        {
            _context.ExplicacaoAssuntos.Remove(explicacaoAssunto);

            await _context.SaveChangesAsync();

            return explicacaoAssunto;
        }

        public async Task<ICollection<ExplicacaoAssunto>> GetAll()
        {
            var explicacoes = await _context.ExplicacaoAssuntos.AsNoTracking().ToListAsync();

            return explicacoes;
        }

        public async Task<ExplicacaoAssunto> GetById(int id)
        {
            return await _context.ExplicacaoAssuntos.FindAsync(id);
        }

        public async Task<ExplicacaoAssunto> Update(ExplicacaoAssunto explicacaoAssunto)
        {
            _context.ExplicacaoAssuntos.Update(explicacaoAssunto);

            await _context.SaveChangesAsync();

            return explicacaoAssunto;
        }
    }
}
