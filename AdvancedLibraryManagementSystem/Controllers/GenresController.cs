using AdvancedLibraryManagementSystem.Models;
using AdvancedLibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdvancedLibraryManagementSystem.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository _genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IActionResult> Index()
        {
            var genres = await _genreRepository.GetAllAsync();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                await _genreRepository.AddAsync(genre);
                await _genreRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(genre);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreRepository.Update(genre);
                await _genreRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(genre);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);

            if (genre != null)
            {
                _genreRepository.Delete(genre);
                await _genreRepository.SaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
