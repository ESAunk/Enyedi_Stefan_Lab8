﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Enyedi_Stefan_Lab8.Data;
using Enyedi_Stefan_Lab8.Models;

namespace Enyedi_Stefan_Lab8.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Enyedi_Stefan_Lab8.Data.Enyedi_Stefan_Lab8Context _context;

        public CreateModel(Enyedi_Stefan_Lab8.Data.Enyedi_Stefan_Lab8Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            {
                var newBook = new Book();
                if (selectedCategories != null)
                {
                    newBook.BookCategories = new List<BookCategory>();
                    foreach (var cat in selectedCategories)
                    {
                        var catToAdd = new BookCategory
                        {
                            CategoryID = int.Parse(cat)
                        };
                        newBook.BookCategories.Add(catToAdd);
                    }
                }
                if (await TryUpdateModelAsync<Book>(
                newBook,
                "Book",
                i => i.Title, i => i.Author,
                i => i.Price, i => i.PublishingDate, i => i.PublisherID))
                {
                    _context.Book.Add(newBook);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                PopulateAssignedCategoryData(_context, newBook);
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
