using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TBBoardTask.Entities;
using TBBoardTask.Infrastructure.Extensions;
using TBBoardTask.Models;
using TBBoardTask.Quries;

namespace TBBoardTask.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext _db;

        public CategoryRepository(DbContext db)
        {
            _db = db;
        }

        public IEnumerable<CategoryViewModel> GetQuoteList()
        {
            if (_db.Context.State == ConnectionState.Closed)
                _db.Context.Open();

            var categories = _db.Context.Query<Category>(QueryToCategories.GetCategoryList).ToList();

            return categories.MapEachTo<CategoryViewModel>();
        }
    }
}