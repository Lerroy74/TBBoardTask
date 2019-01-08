using System.Collections.Generic;
using TBBoardTask.Models;

namespace TBBoardTask.Repositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Получение всех категорий
        /// </summary>
        IEnumerable<CategoryViewModel> GetQuoteList();
    }
}