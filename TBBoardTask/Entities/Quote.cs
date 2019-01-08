using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TBBoardTask.Entities
{
    public class Quote : Entity
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public Category Category { get; set; }

        public Quote() { }

        public Quote(string author, string text)
        {
            Text = text;
            Author = author;
        }
    }
}
