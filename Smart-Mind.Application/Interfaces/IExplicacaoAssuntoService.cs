using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.DTOs.Response;

namespace Smart_Mind.Application.Interfaces
{
    public interface IExplicacaoAssuntoService
    {
        Task<IEnumerable<ExplicacaoAssuntoResponse>> GetAll();

        Task<ExplicacaoAssuntoResponse> GetById(int id);

        Task Add(ExplicacaoAssuntoRequest request);

        Task Update(ExplicacaoAssuntoRequest request);

        Task Remove(int id);
    }
}
