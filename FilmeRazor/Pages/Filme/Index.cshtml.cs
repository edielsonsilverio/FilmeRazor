using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmeRazor.Pages.Filme
{
    public class IndexModel : PageModel
    {
        private readonly FilmeContext _db;

        public IndexModel(FilmeContext db)
        {
            _db = db;
        }

        public IEnumerable<FilmeRazor.Models.Filme> Filmes { get; set; }

        public async Task OnGet()
        {
            Filmes = await _db.Filmes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Filme = await _db.Filmes.FindAsync(id);
            if (Filme == null)
            {
                return NotFound();
            }
            _db.Filmes.Remove(Filme);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

     
 
    }
}
