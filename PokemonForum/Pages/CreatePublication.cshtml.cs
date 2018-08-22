using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokemonForum.Pages
{
    public class CreatePublicationModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Publication Publication { get; set; }

        public CreatePublicationModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Publications.Add(Publication);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}