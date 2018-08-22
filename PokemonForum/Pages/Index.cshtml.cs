using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PokemonForum.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Publication> Publications { get; private set; }

        public async void OnGetAsync()
        {
            Publications = await _db.Publications.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var pokemon = await _db.Publications.FindAsync(Id);

            if (pokemon != null)
            {
                _db.Publications.Remove(pokemon);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
