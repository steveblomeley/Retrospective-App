using System;
using System.Collections.Generic;
using System.Linq;
using Retrospective.Core.Models;

namespace Retrospective.Core.Data
{
    public class Repository : IRepository
    {
        private readonly IConnectionFactory _connFactory;

        public Repository(IConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public void InitialiseDatabase()
        {
            using (var connection = _connFactory.CreateSQLiteConnection())
            {
                connection.CreateTable<Item>();
            }
        }

        public bool AddItem(Item item, out string errorMsg)
        {
            errorMsg = string.Empty;

            using (var connection = _connFactory.CreateSQLiteConnection())
            {
                try
                {
                    connection.Insert(item);
                    return true;
                }
                catch (Exception ex)
                {
                    errorMsg = $"Failed to save new item: {ex.Message}";
                    return false;
                }
            }
        }

        public IEnumerable<Item> AllItems(out string errorMsg)
        {
            errorMsg = string.Empty;

            using (var connection = _connFactory.CreateSQLiteConnection())
            {
                try
                {
                    return connection.Table<Item>().ToList();
                }
                catch (Exception ex)
                {
                    errorMsg = $"Failed to retrieve items: {ex.Message}";
                    return Enumerable.Empty<Item>();
                }
            }
        }
    }
}