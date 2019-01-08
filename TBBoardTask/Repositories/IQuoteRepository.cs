using System;
using System.Collections.Generic;
using TBBoardTask.Domain.Forms;
using TBBoardTask.Entities;
using TBBoardTask.Models;

namespace TBBoardTask.Repositories
{
    public interface IQuoteRepository
    {
        /// <summary>
        /// Получение всех  цитат
        /// </summary>
        IEnumerable<QuoteViewModel> GetQuoteList();

        /// <summary>
        /// Получение всех цитат по аавтору <see cref="author"/>
        /// </summary>
        /// <param name="author"></param>
        IEnumerable<QuoteViewModel> GetQuoteListByAuthor(string author);

        /// <summary>
        /// Добавление цитаты
        /// </summary>
        void AddQoute(AddOrUpdateQuoteForm form);

        /// <summary>
        /// Обновление цитаты
        /// </summary>
        void UpdateQuote(AddOrUpdateQuoteForm form);

        /// <summary>
        /// Удаление цитаты
        /// </summary>
        void DeleteQuote(string id);
    }
}
