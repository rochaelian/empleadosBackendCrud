using Microsoft.EntityFrameworkCore;
using backendApi.Models;
using backendApi.Services.Contrato;

namespace backendApi.Services.Implementacion
{
    public class DepartamentoService : IIDepartamentoService
    {
        private DbEmpleadoContext _dbContext;

        public DepartamentoService(DbEmpleadoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Departamento>> GetList() 
        {
            try
            {
                List<Departamento> lista = new List<Departamento>();
                lista = await _dbContext.Departamentos.ToListAsync();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
