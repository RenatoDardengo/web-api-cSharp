using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Servicos;

namespace mvc_api.Controllers
{
    [ApiController]
    //public class fornecedorsController : Controller =>foi alterada para a linha abaixo, pois afgora não preciso mais de view
    public class FornecedoresController : ControllerBase
    {
        private readonly DbContexto _context;

        public FornecedoresController(DbContexto context)
        {
            _context = context;
        }


        #region GET: /Fornecedores

        [HttpGet]
        [Route("/Fornecedores")]
        public async Task<IActionResult> Index()
        {
            return _context.Fornecedores != null ?
                        StatusCode(200, await _context.Fornecedores.ToListAsync()) :
                        Problem("Entity set 'DbContexto.Fornecedores'  is null.");
        }
        #endregion

        #region GET /Fornecedores/5

        [HttpGet]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return StatusCode(200, fornecedor);
        }
        #endregion

        #region POST: /Fornecedores
        [HttpPost]
        [Route("/Fornecedores")]
        public async Task<IActionResult> Create([Bind("Id,NomeFantasia,RazaoSocial,Cpf_Cnpj,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return StatusCode(201, fornecedor);
            }
        return StatusCode(201, fornecedor);
        }
        #endregion
        
        #region PUT: /Fornecedores/5       
        [HttpPut]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFantasia,RazaoSocial,Cpf_Cnpj,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fornecedor.Id = id;
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!fornecedorExists(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, fornecedor);
            }
            return StatusCode(200, fornecedor);
        }
        #endregion

        #region DELETE: /Fornecedores/5
        [HttpDelete]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fornecedores == null)
            {
                return Problem("Entity set 'DbContexto.Fornecedores'  is null.");
            }
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
        #endregion

        private bool fornecedorExists(int id)
        {
            return (_context.Fornecedores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
