using AdvancedLibraryManagementSystem.Data;
using AdvancedLibraryManagementSystem.Models;

namespace AdvancedLibraryManagementSystem.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}