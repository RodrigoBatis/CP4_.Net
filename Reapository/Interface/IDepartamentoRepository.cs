using Empresa.Models;

namespace Empresa.Reapository.Interface
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetDepartamentos();
        Task<Departamento> GetDepartamentoById(int depId);
        Task<Departamento> AddDepartamento(Departamento departamento);
        Task<Departamento> UpdateDepartamento(Departamento departamento);
        void DeleteDepartamento(int depId);
    }
}
