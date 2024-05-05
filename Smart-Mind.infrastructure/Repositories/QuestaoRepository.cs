using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;

namespace Smart_Mind.infrastructure.Repositories
{
    public class QuestaoRepository : IQuestaoRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Questao> Create(Questao questao)
        {
            _context.Questoes.Add(questao);

            await _context.SaveChangesAsync();

            return questao;
        }

        public async Task Delete(Questao questao)
        {
            _context.Questoes.Remove(questao);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Questao>> GetAll()
        {
            var questoes = await _context.Questoes.ToListAsync();

            return questoes;
        }

        public async Task<Questao> GetById(int id)
        {
            return await _context.Questoes.FindAsync(id);
        }

        public async Task<Questao> Update(Questao questao)
        {
            _context.Questoes.Update(questao);

            await _context.SaveChangesAsync();

            return questao;
        }
    }
}
