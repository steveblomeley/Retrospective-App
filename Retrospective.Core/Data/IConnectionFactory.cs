using SQLite;

namespace Retrospective.Core.Data
{
    public interface IConnectionFactory
    {
        SQLiteConnection CreateSQLiteConnection();
    }
}