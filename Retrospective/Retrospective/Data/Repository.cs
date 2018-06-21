using System;
using Retrospective.Models;
using SQLite;

namespace Retrospective.Data
{
    public interface IRepository
    {
        bool AddItem(Item item, out string errorMsg);
    }

    public class Repository : IRepository
    {
        private readonly SQLiteConnection _connection;

        public Repository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Item>();
        }

        public bool AddItem(Item item, out string errorMsg)
        {
            errorMsg = string.Empty;

            try
            {
                _connection.Insert(item);
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = $"Failed to save new item: {ex.Message}";
                return false;
            }
        }
    }
}