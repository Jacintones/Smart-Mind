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

        /// <summary>
        /// Método assíncrono para criar um assunto e salva-lo no banco
        /// </summary>
        /// <param name="assunto">Corpo do assunto</param>
        /// <returns>retorna o próprio assunto passado</returns>
        public async Task<Assunto> Create(Assunto assunto)
        {
            //Chama o contexto e salva o assunto
            _context.Assuntos.Add(assunto);

            //Chama o contexto e salva
            await _context.SaveChangesAsync();

            //Retorna o próprio assunto
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
            return await _context.Assuntos
                        .Include(a => a.Questoes)
                            .ThenInclude(q => q.Alternativas)
                        .Include(q => q.Explicacoes)
                        .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Assunto> Update(Assunto assunto)
        {
            _context.Assuntos.Update(assunto);
            await _context.SaveChangesAsync();
            return assunto;
        }
    }
}
