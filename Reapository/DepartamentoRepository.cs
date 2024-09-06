using Empresa.Data;
using Empresa.Models;
using Empresa.Reapository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Reapository
{
    public class DepartamentoRepository : IDepartamentoRepository
    {

        private readonly dbContext dbContext;
        public DepartamentoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Departamento> AddDepartamento(Departamento departamento)
        {
            var result = await dbContext.Departamentos.AddAsync(departamento);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteDepartamento(int depId)
        {
            var result = await dbContext.Departamentos.FirstOrDefaultAsync(e => e.DepId == depId);
            if (result != null)
            {
                dbContext.Departamentos.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Departamento> GetDepartamentoById(int depId)
        {
            return await dbContext.Departamentos.FirstOrDefaultAsync(e => e.DepId == depId);
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            return await dbContext.Departamentos.ToListAsync();
        }

        public async Task<Departamento> UpdateDepartamento(Departamento departamento)
        {
            var result = await dbContext.Departamentos.FirstOrDefaultAsync(e => e.DepId == departamento.DepId);
            if (result != null)
            {
                return null;
            }

            result.DepNome = departamento.DepNome;

            await dbContext.SaveChangesAsync();

            return result;

        }

        public async Task<IEnumerable<Empregado>> GetEmpregadosByDep( int DepId)
        {
            var dep = await dbContext.Departamentos.FindAsync(DepId);

            if (dep == null) { 
                return Enumerable.Empty<Empregado>();
            }

            return await dbContext.Empregados
                .Where(e => e.DepId == DepId)
                .ToListAsync();
        }
    }
}
