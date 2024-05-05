using Smart_Mind.Domain.Entities;


namespace Smart_Mind.Domain.Interfaces
{
    public interface IMateriaRepository
    {
        Task<ICollection<Materia>> GetAll();

        Task<ICollection<Materia>> GetMateriaWithAssunto();

        Task<Materia> GetById(int id);

        Task<Materia> Create(Materia materia);

        Task<Materia> Update(Materia materia);

        Task Delete(Materia materia);
    }
}
