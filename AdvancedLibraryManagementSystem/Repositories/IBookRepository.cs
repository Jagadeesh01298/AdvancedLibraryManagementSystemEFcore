using AdvancedLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithAuthorAndGenreAsync();

        Task<IEnumerable<Book>> SearchBooksAsync(string searchText, int page, int pageSize);
    }
}
