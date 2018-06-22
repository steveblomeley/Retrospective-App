using SQLite;

namespace Retrospective.Data
{
    public interface IConnectionFactory
    {
        SQLiteConnection CreateSQLiteConnection();
    }
}