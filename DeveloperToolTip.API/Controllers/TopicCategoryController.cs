using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperToolTip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicCategoryController : ControllerBase
    {
        private readonly IGetAllTopicCategoryUseCase _getAllTopicCategoryUseCase;
        private readonly IGetTopicCategoryByIdUseCase _getTopicCategoryByIdUseCase;
        private readonly ICreateTopicCategoryUseCase _createTopicCategoryUseCase;
        private readonly IUpdateTopicCategoryUseCase _updateTopicCategoryUseCase;
        private readonly IDeleteTopicCategoryUseCase _deleteTopicCategoryUseCase;

        public TopicCategoryController(
            IGetAllTopicCategoryUseCase getAllTopicCategoryUseCase, 
            IGetTopicCategoryByIdUseCase getTopicCategoryByIdUseCase, 
            ICreateTopicCategoryUseCase createTopicCategoryUseCase,
            IUpdateTopicCategoryUseCase updateTopicCategoryUseCase,
            IDeleteTopicCategoryUseCase deleteTopicCategoryUseCase)
        {
            _getAllTopicCategoryUseCase = getAllTopicCategoryUseCase;
            _getTopicCategoryByIdUseCase = getTopicCategoryByIdUseCase;
            _createTopicCategoryUseCase = createTopicCategoryUseCase;
            _updateTopicCategoryUseCase = updateTopicCategoryUseCase;
            _deleteTopicCategoryUseCase = deleteTopicCategoryUseCase;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _getAllTopicCategoryUseCase.ExecuteAsync();
            return Ok(categories); // Retorna HTTP 200 con los datos
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _getTopicCategoryByIdUseCase.ExecuteAsync(id);
                return Ok(category);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTopicCategoryDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna HTTP 400 si el modelo no es válido

            var createdCategoryId = await _createTopicCategoryUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdCategoryId }, dto);
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteTopicCategoryUseCase.ExecuteAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }

        // PUT: api/Roles
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTopicCategoryDto dto)
        {
            try
            {
                await _updateTopicCategoryUseCase.ExecuteAsync(dto);
                return NoContent(); // Retorna 204 si la actualización fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }


    }

}
