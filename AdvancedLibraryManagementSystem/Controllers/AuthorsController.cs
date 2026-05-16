using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAllAsync();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepository.AddAsync(author);
                await _authorRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Update(author);
                await _authorRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author != null)
            {
                _authorRepository.Delete(author);
                await _authorRepository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
