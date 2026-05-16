using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
