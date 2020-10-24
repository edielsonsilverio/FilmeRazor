using FilmeRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeRazor.Controllers
{
    [Route("api/Filme")]
    [ApiController]
    public class FilmeController : Controller
    {
        private readonly FilmeContext _db;

        [BindProperty]
        public Filme Filme { get; set; }

        public FilmeController(FilmeContext db)
        {
            _db = db;
        }

        #region API Calls

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Filmes.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var filmeDb = await _db.Filmes.FirstOrDefaultAsync(u => u.Id == id);
            if (filmeDb == null)
            {
                return Json(new { success = false, message = "Erro ao tentar excluir o registro." });
            }
            _db.Filmes.Remove(filmeDb);

            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Registro excluído com sucesso." });
        }
        #endregion
    }
}

