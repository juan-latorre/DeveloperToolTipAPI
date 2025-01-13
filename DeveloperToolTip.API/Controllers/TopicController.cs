using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Application.UseCases.TopicUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperToolTip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IGetAllTopicUseCase _getAllTopicUseCase;
        private readonly IGetTopicByIdUseCase _getTopicByIdUseCase;
        private readonly ICreateTopicUseCase _createTopicUseCase;
        private readonly IUpdateTopicUseCase _updateTopicUseCase;
        private readonly IDeleteTopicUseCase _deleteTopicUseCase;


        public TopicController(
            IGetAllTopicUseCase getAllTopicUseCase,
            IGetTopicByIdUseCase getTopicByIdUseCase, 
            ICreateTopicUseCase createTopicUseCase, 
            IUpdateTopicUseCase updateTopicUseCase, 
            IDeleteTopicUseCase deleteTopicUseCase)
        {
            _getAllTopicUseCase = getAllTopicUseCase;
            _getTopicByIdUseCase = getTopicByIdUseCase;
            _createTopicUseCase = createTopicUseCase;
            _updateTopicUseCase = updateTopicUseCase;
            _deleteTopicUseCase = deleteTopicUseCase;
        }

        // GET: api/Topic
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var topic = await _getAllTopicUseCase.ExecuteAsync();
            return Ok(topic); // Retorna HTTP 200 con los datos
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var topic = await _getTopicByIdUseCase.ExecuteAsync(id);
                return Ok(topic);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTopicDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna HTTP 400 si el modelo no es válido

            var createdTopicId = await _createTopicUseCase.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdTopicId }, dto); // Retorna HTTP 201
        }

        // DELETE: api/Topic/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _deleteTopicUseCase.ExecuteAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }

        // PUT: api/Topic
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTopicDto dto)
        {
            try
            {
                await _updateTopicUseCase.ExecuteAsync(dto);
                return NoContent(); // Retorna 204 si la actualización fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }
    }
}
