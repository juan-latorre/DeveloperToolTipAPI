using Microsoft.AspNetCore.Mvc;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;

namespace DeveloperToolTip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IGetAllDevelopersUseCase _getAllDevelopersUseCase;
        private readonly ICreateDeveloperUseCase _createDeveloperUseCase;
        private readonly IDeleteDeveloperUseCase _deleteDeveloperUseCase;
        private readonly IGetDeveloperByIdUseCase _getDeveloperByIdUseCase;
        private readonly IUpdateDeveloperUseCase _updateDeveloperUseCase;

        public DevelopersController(
            IGetAllDevelopersUseCase getAllDevelopersUseCase,
            ICreateDeveloperUseCase createDeveloperUseCase,
            IDeleteDeveloperUseCase deleteDeveloperUseCase,
            IGetDeveloperByIdUseCase getDeveloperByIdUseCase,
            IUpdateDeveloperUseCase updateDeveloperUseCase)
        {
            _getAllDevelopersUseCase = getAllDevelopersUseCase;
            _createDeveloperUseCase = createDeveloperUseCase;
            _deleteDeveloperUseCase = deleteDeveloperUseCase;
            _getDeveloperByIdUseCase = getDeveloperByIdUseCase;
            _updateDeveloperUseCase = updateDeveloperUseCase;
        }

        // GET: api/developers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var developers = await _getAllDevelopersUseCase.ExecuteAsync();
            return Ok(developers); // Retorna HTTP 200 con los datos
        }

        // POST: api/developers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeveloperDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna HTTP 400 si el modelo no es válido

            var createdDeveloperId = await _createDeveloperUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdDeveloperId }, dto);

        }


        // DELETE: api/Developers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteDeveloperUseCase.ExecuteAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var developer = await _getDeveloperByIdUseCase.ExecuteAsync(id);
                return Ok(developer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Developers
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeveloperDto dto)
        {
            try
            {
                await _updateDeveloperUseCase.ExecuteAsync(dto);
                return NoContent(); // Retorna 204 si la actualización fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }
        }

    }
}
