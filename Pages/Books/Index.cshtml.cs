using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghirean_Daria_Lab2.Data;
using Ghirean_Daria_Lab2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ghirean_Daria_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context _context;

        public IndexModel(Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }
    }
}
