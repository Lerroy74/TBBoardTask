using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TBBoardTask.Entities;

namespace TBBoardTask.Models
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public  Category Category { get; set; }
    }
}
