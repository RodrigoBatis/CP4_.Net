using Empresa.Models;

namespace Empresa.Reapository.Interface
{
    public interface IEmpregadoRepository
    {
        Task<IEnumerable<Empregado>> GetEmpregados();
        Task<Empregado> GetEmpregado(int empId);
        Task<Empregado> AddEmpregado(Empregado empregado);
        Task<Empregado> UpdateEmpregado(Empregado empregado);
        void DeleteEmpregado(int empId);
    }
}
