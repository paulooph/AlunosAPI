using AlunosAPI.Models;
using AlunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                if (alunos == null)
                {
                    return NotFound("Não existem alunos cadastrados!");
                }
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request inválido!");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos.");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos == null)
                {
                    return NotFound($"Não existem alunos com o critério {nome}");
                }

                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request inválido!");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno por nome.");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                {
                    return NotFound($"Não existe aluno com o ID {id}");
                }
                return Ok(aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter aluno por ID.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create (Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar aluno.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    _alunoService.UpdateAluno(aluno);
                    //return NoContent();
                    return Ok($"Aluno com o id = {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes!");
                }
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar o aluno.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno de id = {id} foi excluído com sucesso!");

                }
                else
                {
                    return NotFound($"Aluno com o id = {id} não encontrado");
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir o aluno.");
            }
        }

    }
}
