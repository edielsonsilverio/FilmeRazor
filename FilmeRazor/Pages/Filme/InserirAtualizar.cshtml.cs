using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilmeRazor.Pages.Filme
{
    public class InserirAtualizarModel : PageModel
    {
        private readonly FilmeContext _db;
        public InserirAtualizarModel(FilmeContext db)
        {
            _db = db;
        }

        [BindProperty]
        public FilmeRazor.Models.Filme Filme { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Filme = new FilmeRazor.Models.Filme();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Filme = await _db.Filmes.FirstOrDefaultAsync(u => u.Id == id);
            if (Filme == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Filme.Id == 0)
                {
                    _db.Filmes.Add(Filme);
                }
                else
                {
                    _db.Filmes.Update(Filme);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}