using System.Collections.Generic;
using Retrospective.Core.Models;

namespace Retrospective.Core.Data
{
    public interface IRepository
    {
        void InitialiseDatabase();
        bool AddItem(Item item, out string errorMsg);
        IEnumerable<Item> AllItems(out string errorMsg);
    }
}