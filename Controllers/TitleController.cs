using cms_webapi.DTOs;
using cms_webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cms_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _titleService.GetAllTitlesAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _titleService.GetTitleByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTitleDto createTitleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _titleService.CreateTitleAsync(createTitleDto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateTitleDto updateTitleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _titleService.UpdateTitleAsync(id, updateTitleDto);            
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _titleService.DeleteTitleAsync(id); 
            return StatusCode(result.StatusCode, result);
        }
    }
}
