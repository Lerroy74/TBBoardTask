using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBBoardTask.Domain.Forms
{
    public class AddOrUpdateQuoteForm : IForm
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public Guid CategoryId { get; set; }
    }
}
