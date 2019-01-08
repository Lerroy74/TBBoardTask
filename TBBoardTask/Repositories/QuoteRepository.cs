using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using TBBoardTask.Domain.Forms;
using TBBoardTask.Entities;
using TBBoardTask.Infrastructure.Extensions;
using TBBoardTask.Models;
using TBBoardTask.Quries;

namespace TBBoardTask.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly DbContext _db;

        public QuoteRepository(DbContext db)
        {
            _db = db;
        }

        public IEnumerable<QuoteViewModel> GetQuoteList()
        {
            var quotes = _db.Context.Query<Quote, Category, Quote>(QueryToQuote.GetQouteListJoinCategory, (quote, category) =>
            {
                if (category != null)
                    quote.Category = category;
                return quote;
            }).ToList();

            return quotes.MapEachTo<QuoteViewModel>();
        }

        public IEnumerable<QuoteViewModel> GetQuoteListByAuthor(string author)
        {
            var query = QueryToQuote.GetByAuthor.Replace("@author", author);
            var quotes = _db.Context.Query<Quote, Category, Quote>(query, (quote, category) =>
            {
                if (category != null)
                    quote.Category = category;
                return quote;
            }).ToList();

            return quotes.MapEachTo<QuoteViewModel>();
        }



        public void AddQoute(AddOrUpdateQuoteForm form)
        {
            var quote = new Quote(form.Author, form.Text);

            var query = QueryToQuote.InsertQoute;
            query = query.Replace("@author", quote.Author);
            query = query.Replace("@text", quote.Text);
            query = query.Replace("@createdat", quote.CreatedAt.ToString());
            if (form.CategoryId != Guid.Empty)
                query = query.Replace("@categoryid", form.CategoryId.ToString());
            _db.Context.Execute(query);
        }

        public void UpdateQuote(AddOrUpdateQuoteForm form)
        {
            var quote = new Quote(form.Author, form.Text);

            var query = QueryToQuote.UpdateQouteById;
            query = query.Replace("@author", quote.Author);
            query = query.Replace("@text", quote.Text);
            if (form.CategoryId != Guid.Empty)
                query = query.Replace("@categoryid", form.CategoryId.ToString());
            query = query.Replace("@quoteId", quote.Id.ToString());

            _db.Context.Execute(query);
        }

        public void DeleteQuote(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
                return;
            var query = QueryToQuote.DeleteQouteById.Replace("@Id", id);
            _db.Context.Execute(query);
        }
    }
}
