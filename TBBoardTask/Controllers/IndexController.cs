using System.Web.Mvc;
using Newtonsoft.Json;
using TBBoardTask.Domain.Forms;
using TBBoardTask.Repositories;

namespace TBBoardTask.Controllers
{
    public class IndexController : Controller
    {
        private static readonly DbContext Db = new DbContext();
        private readonly IQuoteRepository _quoteRepo = new QuoteRepository(Db);
        private readonly ICategoryRepository _categoryRepo = new CategoryRepository(Db);
        // GET: Index
        public ActionResult Index(string searchStr)
        {
            return View(_quoteRepo.GetQuoteList());
        }

        [HttpGet]
        public string GetQuoteList(string author) => JsonConvert.SerializeObject(_quoteRepo.GetQuoteList());

        [HttpGet]
        public string GetQuoteListByAuthor(string author) => JsonConvert.SerializeObject(_quoteRepo.GetQuoteListByAuthor(author));

        [HttpPost]
        public void AddQuote(AddOrUpdateQuoteForm form) => _quoteRepo.AddQoute(form);

        [HttpPost]
        public void UpdateQuote(AddOrUpdateQuoteForm form) => _quoteRepo.UpdateQuote(form);

        [HttpPost]
        public void DeleteQuote(string quoteId) => _quoteRepo.DeleteQuote(quoteId); 

        [HttpGet]
        public string GetCategories() => JsonConvert.SerializeObject(_categoryRepo.GetQuoteList());
    }
}
