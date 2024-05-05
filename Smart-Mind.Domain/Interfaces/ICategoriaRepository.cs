using Smart_Mind.Domain.Entities;


namespace Smart_Mind.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<ICollection<Categoria>> GetAll();

        Task<Categoria> GetById(int id);

        Task<ICollection<Categoria>> GetCategoriaWithMateria();

        Task<Categoria> Create(Categoria categoria);

        Task<Categoria> Update(Categoria categoria);

        Task Delete(Categoria categoria);
    }
}
