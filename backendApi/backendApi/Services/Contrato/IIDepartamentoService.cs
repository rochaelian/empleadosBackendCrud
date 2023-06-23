using backendApi.Models;

namespace backendApi.Services.Contrato
{
    public interface IIDepartamentoService
    {
        Task<List<Departamento>> GetList();
    }
}
