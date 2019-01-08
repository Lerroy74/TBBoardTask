using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TBBoardTask
{
    public class DbContext
    {
        public IDbConnection Context { get; }

        public DbContext()
        {
            Context = new SqlConnection(ConfigurationManager.ConnectionStrings["quoteDb"].ConnectionString);
        }
    }
}
