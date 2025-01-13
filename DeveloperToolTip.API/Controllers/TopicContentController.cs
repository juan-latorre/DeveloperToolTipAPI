using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperToolTip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicContentController : ControllerBase
    {
        private readonly IGetAllTopicContentsUseCase _getAllTopicContentsUseCase;
        private readonly IGetAllTopicContentsWithRelationsUseCase _getAllTopicContentsWithRelationsUseCase;
        private readonly IGetTopicContentByIdUseCase _getTopicContentByIdUseCase;
        private readonly ICreateTopicContentUseCase _createTopicContentUseCase;
        private readonly IDeleteTopicContentUseCase _deleteTopicContentUseCase;
        private readonly IUpdateTopicContentUseCase  _updateTopicContentUseCase;

        public TopicContentController(
            IGetAllTopicContentsUseCase getAllTopicContentsUseCase,
            IGetAllTopicContentsWithRelationsUseCase getAllTopicContentsWithRelationsUseCase,
            IGetTopicContentByIdUseCase getTopicContentByIdUseCase,
            ICreateTopicContentUseCase createTopicContentUseCase, 
            IDeleteTopicContentUseCase deleteTopicContentUseCase, 
            IUpdateTopicContentUseCase updateTopicContentUseCase)
        {
            _getAllTopicContentsUseCase = getAllTopicContentsUseCase;
            _getAllTopicContentsWithRelationsUseCase = getAllTopicContentsWithRelationsUseCase;
            _getTopicContentByIdUseCase = getTopicContentByIdUseCase;
            _createTopicContentUseCase = createTopicContentUseCase;
            _deleteTopicContentUseCase = deleteTopicContentUseCase;
            _updateTopicContentUseCase = updateTopicContentUseCase;
        }


        // GET: api/TopicContent
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topicContent = await _getAllTopicContentsUseCase.ExecuteAsync();
            return Ok(topicContent); // Retorna HTTP 200 con los datos
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _getTopicContentByIdUseCase.ExecuteAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Devuelve HTTP 404 si no se encuentra
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}"); // Devuelve HTTP 500
            }

        }

        // POST: api/TopicContent
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTopicContentDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna HTTP 400 si el modelo no es válido

            var createdTopicId = await _createTopicContentUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdTopicId }, dto); // Retorna HTTP 201
        }

        // DELETE: api/TopicContent/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteTopicContentUseCase.ExecuteAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }


        // PUT: api/TopicContent
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTopicContentDto dto)
        {
            try
            {
                await _updateTopicContentUseCase.ExecuteAsync(dto);
                return NoContent(); // Retorna 204 si la actualización fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }
    }
}
