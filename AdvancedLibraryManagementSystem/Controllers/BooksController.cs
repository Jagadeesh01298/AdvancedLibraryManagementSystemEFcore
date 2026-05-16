using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;

        public BooksController(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            int pageSize = 5;

            var books = await _bookRepository.SearchBooksAsync(searchText, page, pageSize);

            ViewBag.SearchText = searchText;
            ViewBag.CurrentPage = page;

            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => x.Key + " : " + x.Value.Errors[0].ErrorMessage)
                    .ToList();

                ViewBag.Errors = errors;

                await LoadDropdowns();
                return View(book);
            }

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await LoadDropdowns();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => x.Key + " : " + x.Value.Errors[0].ErrorMessage)
                    .ToList();

                ViewBag.Errors = errors;

                await LoadDropdowns();
                return View(book);
            }

            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book != null)
            {
                _bookRepository.Delete(book);
                await _bookRepository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAjax(Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => x.Key + " : " + x.Value.Errors[0].ErrorMessage)
                        .ToList();

                    return Json(new
                    {
                        success = false,
                        message = "Invalid book details.",
                        errors = errors
                    });
                }

                await _bookRepository.AddAsync(book);
                await _bookRepository.SaveAsync();

                return Json(new
                {
                    success = true,
                    message = "Book added successfully."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while adding book: " + ex.Message
                });
            }
        }

        private async Task LoadDropdowns()
        {
            var authors = await _authorRepository.GetAllAsync();
            var genres = await _genreRepository.GetAllAsync();

            ViewBag.Authors = new SelectList(authors, "AuthorId", "Name");
            ViewBag.Genres = new SelectList(genres, "GenreId", "Name");
        }
    }
}