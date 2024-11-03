using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghirean_Daria_Lab2.Data;
using Ghirean_Daria_Lab2.Models;
using Ghirean_Daria_Lab2.ViewModels;

namespace Ghirean_Daria_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context _context;

        public IndexModel(Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int? CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CategoryData = new CategoryIndexData(); 
            CategoryData.Categories = await _context.Category
               .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(c => c.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync(); 
            
            if (id != null)
            {
                CategoryID = id.Value;
                //Category category = CategoryData.Categories
                //  .Where(i => i.ID == id.Value).Single();
                //CategoryData.Books = category.Books; 
                CategoryData.Books = CategoryData.Categories.Where(c => c.ID == CategoryID.Value).SelectMany(c => c.BookCategories.Select(bc => bc.Book));

            }
        }
    }
}
