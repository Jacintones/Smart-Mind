using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;

namespace Smart_Mind.infrastructure.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        private readonly ApplicationDbContext _context;

        public TesteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teste> Create(Teste teste)
        {
            _context.Testes.Add(teste);

            await _context.SaveChangesAsync();

            return teste;
        }

        public async Task<Teste> Delete(Teste teste)
        {
            _context.Testes.Remove(teste);

            await _context.SaveChangesAsync();

            return teste;
        }

        public async Task<ICollection<Teste>> GetAll()
        {
            var testes = await _context.Testes.AsNoTracking().Include(q => q.Questoes).Include(r => r.RespostaUsuarios).ToListAsync();

            return testes;
        }

        public async Task<Teste> GetById(int id)
        {
            return await _context.Testes
                .Include(t => t.Questoes) // Inclui as questões
                    .ThenInclude(q => q.Alternativas) // Inclui as alternativas das questões
                .Include(t => t.RespostaUsuarios) // Inclui as respostas dos usuários
                .FirstOrDefaultAsync(t => t.Id == id);

        }

        public async Task<ICollection<Teste>> GetTesteWithQuestoes()
        {
            throw new NotImplementedException();
        }

        public async Task<Teste> Update(Teste teste)
        {
            _context.Testes.Update(teste);

            await _context.SaveChangesAsync();

            return teste;
        }
    }
}
