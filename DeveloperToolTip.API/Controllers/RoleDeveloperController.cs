using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Application.UseCases.RoleUseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperToolTip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleDeveloperController : ControllerBase
    {
        private readonly IGetAllRolesDeveloperUseCase _getAllRolesDeveloperUseCase;
        private readonly IGetRoleDeveloperByIdUseCase _getRoleDeveloperByIdUseCase;
        private readonly ICreateRoleDeveloperUseCase _createRoleDeveloperUseCase;
        private readonly IUpdateRoleDeveloperUseCase _updateRoleDeveloperUseCase;
        private readonly IDeleteRoleDevelperUseCase _deleteRoleDevelperUseCase;

        public RoleDeveloperController(
            IGetAllRolesDeveloperUseCase getAllRolesDeveloperUseCase, 
            IGetRoleDeveloperByIdUseCase getRoleDeveloperByIdUseCase,
            ICreateRoleDeveloperUseCase createRoleDeveloperUseCase,
            IUpdateRoleDeveloperUseCase updateRoleDeveloperUseCase, 
            IDeleteRoleDevelperUseCase deleteRoleDevelperUseCase)
        {
            _getAllRolesDeveloperUseCase = getAllRolesDeveloperUseCase;
            _getRoleDeveloperByIdUseCase = getRoleDeveloperByIdUseCase;
            _createRoleDeveloperUseCase = createRoleDeveloperUseCase;
            _updateRoleDeveloperUseCase = updateRoleDeveloperUseCase;
            _deleteRoleDevelperUseCase = deleteRoleDevelperUseCase;
        }


        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _getAllRolesDeveloperUseCase.ExecuteAsync();
            return Ok(roles); // Retorna HTTP 200 con los datos
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                var role = await _getRoleDeveloperByIdUseCase.ExecuteAsync(id);
                return Ok(role);

            }
            catch (KeyNotFoundException ex) 
            {
             return NotFound(ex.Message);         
            }
        
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDeveloperDto dto) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Retorna HTTP 400 si el modelo no es válido

            var createdDeveloperRoleId = await _createRoleDeveloperUseCase.ExecuteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDeveloperRoleId }, dto); // Retorna HTTP 201
        }


        // DELETE: api/Role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _deleteRoleDevelperUseCase.ExecuteAsync(id);
                return NoContent(); // Retorna 204 si la eliminación fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }

        // PUT: api/Roles
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDeveloperDto dto) 
        {
            try
            {
                await _updateRoleDeveloperUseCase.ExecuteAsync(dto);
                return NoContent(); // Retorna 204 si la actualización fue exitosa
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no se encuentra el developer
            }

        }
    }
}
