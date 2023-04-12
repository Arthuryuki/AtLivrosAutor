using AtLivrosAutor.Domain.Interfaces;
using AtLivrosAutor.Domain.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtLivrosAutor.API.Controllers
{
    [Route("/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        // GET api/livros
        [Authorize]
        [HttpGet]
        public IEnumerable<LivroViewModel> Get()
        {
            return _livroService.GetLivros();
        }

        // GET api/livros/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<LivroViewModel> Get(int id)
        {
            var livro = _livroService.GetLivro(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // POST api/livros
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                _livroService.AddLivro(livroViewModel);
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/livros/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid && livroViewModel.Id == id)
            {
                try
                {
                    _livroService.UpdateLivro(livroViewModel);
                    return Ok();
                }
                catch
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        // DELETE api/livros/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livroService.RemoveLivro(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}