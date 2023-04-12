using AtLivrosAutor.Domain.Interfaces;
using AtLivrosAutor.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtLivrosAutor.API.Controllers
{
    [Route("/Autor")]
    [ApiController]
    [Authorize]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var autores = _autorService.GetAutores();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var autor = _autorService.GetAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AutorViewModel autorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _autorService.AddAutor(autorViewModel);

            return CreatedAtAction(nameof(Get), new { id = autorViewModel.Id }, autorViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AutorViewModel autorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autorViewModel.Id)
            {
                return BadRequest();
            }

            try
            {
                _autorService.UpdateAutor(autorViewModel);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _autorService.RemoveAutor(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}