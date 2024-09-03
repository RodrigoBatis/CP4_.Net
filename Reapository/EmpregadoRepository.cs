using Empresa.Data;
using Empresa.Models;
using Empresa.Reapository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Reapository
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly dbContext dbContext;
        public EmpregadoRepository(dbContext dbContext) { 
            this.dbContext = dbContext;
        }
        public async Task<Empregado> AddEmpregado(Empregado empregado)
        {
            var result = await dbContext.Empregados.AddAsync(empregado);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmpregado(int empId)
        {
            var result = await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpId == empId);
            if (result != null)
            {
                dbContext.Empregados.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Empregado> GetEmpregado(int empId)
        {
            return await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpId == empId);
        }

        public async Task<IEnumerable<Empregado>> GetEmpregados()
        {
            return await dbContext.Empregados.ToListAsync();
        }

        public async Task<Empregado> UpdateEmpregado(Empregado empregado)
        {
            var result = await dbContext.Empregados.FirstOrDefaultAsync(e => e.EmpId == empregado.EmpId);
            if (result != null)
            {
                result.Nome = empregado.Nome;
                result.Sobrenome = empregado.Sobrenome;
                result.Genero = empregado.Genero;
                result.Email = empregado.Email;
                result.FotoUrl = empregado.FotoUrl;

                await dbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
