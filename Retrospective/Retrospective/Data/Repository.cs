﻿using System;
using System.Collections.Generic;
using System.Linq;
using Retrospective.Models;

namespace Retrospective.Data
{
    public class Repository : IRepository
    {
        private readonly IConnectionFactory _connFactory;
        private static bool _initialised = false;

        public Repository(IConnectionFactory connFactory)
        {
            _connFactory = connFactory;
        }

        public void InitialiseDatabase()
        {
            if (_initialised) return;

            using (var connection = _connFactory.CreateSQLiteConnection())
            {
                connection.CreateTable<Item>();
            }

            _initialised = true;
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