﻿using SQLite;

namespace Retrospective.Data
{
    public class SqLiteConnectionFactory : IConnectionFactory
    {
        private readonly string _dbFilePath;

        public SqLiteConnectionFactory(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public SQLiteConnection CreateSQLiteConnection()
        {
            return new SQLiteConnection(_dbFilePath);
        }
    }
}