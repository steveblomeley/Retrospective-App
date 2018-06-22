using System.Collections.Generic;
using Retrospective.Models;

namespace Retrospective.Data
{
    public interface IRepository
    {
        void InitialiseDatabase();
        bool AddItem(Item item, out string errorMsg);
        IEnumerable<Item> AllItems(out string errorMsg);
    }
}