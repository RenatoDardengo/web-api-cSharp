using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Servicos;

namespace mvc_api.Controllers
{
    [ApiController]
    //public class AlunosController : Controller =>foi alterada para a linha abaixo, pois afgora não preciso mais de view
    public class AlunosController : ControllerBase
    {
        private readonly DbContexto _context;

        public AlunosController(DbContexto context)
        {
            _context = context;
        }


        #region GET: /alunos

        [HttpGet]
        [Route("/alunos")]
        public async Task<IActionResult> Index()
        {
            return _context.Alunos != null ?
                        StatusCode(200, await _context.Alunos.ToListAsync()) :
                        Problem("Entity set 'DbContexto.Alunos'  is null.");
        }
        #endregion

        #region GET /alunos/5

        [HttpGet]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return StatusCode(200, aluno);
        }
        #endregion

        #region POST: /alunos
        [HttpPost]
        [Route("/alunos")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return StatusCode(201, aluno);
            }
        return StatusCode(201, aluno);
        }
        #endregion
        
        #region PUT: /alunos/5       
        [HttpPut]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    aluno.Id = id;
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, aluno);
            }
            return StatusCode(200, aluno);
        }
        #endregion

        #region DELETE: /alunos/5
        [HttpDelete]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alunos == null)
            {
                return Problem("Entity set 'DbContexto.Alunos'  is null.");
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
        #endregion

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
