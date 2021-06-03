using Books365WebSite.Models;
using Books365WebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books365WebSite.Interfaces
{
    public interface IRepository
    {
        Task<Book> GetBookById(int id);
        Task<List<Book>> GetAllBooks();
        Task<List<ReadingStatusViewModel>> GetUserBooks(ClaimsPrincipal claims);
        Task UpdateBook(Book book);
        Task AddBook(Book book);
        Task DeleteBook(int id);
        Task AddReadingStatus(ReadingStatus status);
        Task<User> GetCurrentUserAsync(ClaimsPrincipal claims);
        Task<Statistic> GetStatistic(ClaimsPrincipal claims);
        Task<ReadingStatus> GetBookStatus(int id, ClaimsPrincipal claims);
        Task UpdateReadingStatus(ReadingStatus status);
        Task<ReadingStatus> GetBookReadingStatus(int id, ClaimsPrincipal claims);
        Task DeleteReadingStatus(int id, ClaimsPrincipal claims);
    }
}
