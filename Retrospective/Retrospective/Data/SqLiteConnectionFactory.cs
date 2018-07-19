using Retrospective.XPlatform;
using SQLite;

namespace Retrospective.Data
{
    public class SqLiteConnectionFactory : IConnectionFactory
    {
        private readonly string _dbFilePath;

        public SqLiteConnectionFactory(ILocalFilesystem localFileSystem, string dbFileName)
        {
            _dbFilePath = localFileSystem.GetLocalFilePath(dbFileName);
        }

        public SQLiteConnection CreateSQLiteConnection()
        {
            return new SQLiteConnection(_dbFilePath);
        }
    }
}