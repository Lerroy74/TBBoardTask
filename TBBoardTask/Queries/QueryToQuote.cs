namespace TBBoardTask.Quries
{
    public class QueryToQuote
    {
        public const string GetQouteListJoinCategory = "select * from quotes q left join categories c on q.categoryId = c.id";
        public const string GetByAuthor = "select * from quotes q left join categories c on q.categoryId = c.id where q.author like N'@author%'";

        public const string InsertQoute =
            "insert quotes(author, text, createdat,categoryid) values('@author','@text', '@createdat','@categoryid')";
        public const string UpdateQouteById =
            "update quotes set author = '@author', text = '@text', categoryid = @'categoryid' where id = '@quoteId'";

        public const string DeleteQouteById = "DELETE FROM Quotes WHERE Id = '@Id'";
    }
}
