using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PokemonForum.Pages
{
    public class EditPublicationModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditPublicationModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Publication Publication { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Publication = await _db.Publications.FindAsync(id);
            if (Publication == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Publication).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new Exception($"The pokemon {Publication.Id} wasnt found!", e);
            }

            return RedirectToPage("./Index");
        }
    }
}