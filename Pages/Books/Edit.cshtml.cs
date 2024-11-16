using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ghirean_Daria_Lab2.Data;
using Ghirean_Daria_Lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ghirean_Daria_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context _context;

        public EditModel(Ghirean_Daria_Lab2.Data.Ghirean_Daria_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        //public List<AssignedCategoryData> AssignedCategoryDataList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);              

            if (Book == null)
            {
                return NotFound();
            }

            //apelam PopulateAssignedCategoryData  pentru o obtine informatiile necesare checkbox
            //urilor folosind clasa AssignedCategoryData
            
            PopulateAssignedCategoryData(_context, Book);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null) 
            { 
                return NotFound(); 
            }  
            var bookToUpdate = await _context.Book 
                .Include(b => b.Author)
                .Include(i => i.Publisher)                 
                .Include(i => i.BookCategories)                     
                    .ThenInclude(i => i.Category)                 
                .FirstOrDefaultAsync(s => s.ID == id);    
            
            if (bookToUpdate == null)             
            {                 
                return NotFound();             
            }  
            //se va modifica AuthorID  conform cu sarcina de la lab 2
            
            if (await TryUpdateModelAsync<Book>(                 
                bookToUpdate,                 
                "Book",                 
                i => i.Title, i => i.Author,                  
                i => i.Price, i => i.PublishingDate, i => i.PublisherID))             
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index");
            } //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care este editata
            
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);             
            PopulateAssignedCategoryData(_context, bookToUpdate);             
            return Page();         
        }     
    } 
}
