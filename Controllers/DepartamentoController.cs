using Empresa.Models;
using Empresa.Reapository;
using Empresa.Reapository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly IDepartamentoRepository departamentoRepository;

        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            this.departamentoRepository = departamentoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> getDepartamento()
        {
            try
            {
                return Ok(await departamentoRepository.GetDepartamentos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Departamento>> getDepartamento(int id)
        {
            try
            {
                var result = await departamentoRepository.GetDepartamentoById(id);
                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Departamento>> createDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                if (departamento == null) return BadRequest();

                var result = await departamentoRepository.AddDepartamento(departamento);

                return CreatedAtAction(nameof(getDepartamento), new { id = result.DepId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Departamento>> UpdateDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                var result = await departamentoRepository.GetDepartamentoById(departamento.DepId);
                if (result == null) return NotFound($"Departamento chamado = {departamento.DepNome} não encontrado");

                return await departamentoRepository.UpdateDepartamento(departamento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no banco de dados");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Departamento>> DeleteDepartamento(int id)
        {
            try
            {
                var result = await departamentoRepository.GetDepartamentoById(id);
                if (result == null) return NotFound($"Departamento com id = {id} não encontrado");

                departamentoRepository.DeleteDepartamento(id);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no banco de dados");
            }
        }


    }
}
