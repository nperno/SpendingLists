using System.Collections.Generic;
using SpendingLists.Models;

namespace SpendingLists.Services
{
    public interface IRepo
    {
        void DeleteStudent(int id);
        SpendingList GetSpendingListByID(int id);
        IEnumerable<SpendingList> GetSpendingLists();
        void InsertStudent(SpendingList spendingList);
        void Save();
        void UpdateSpendingList(SpendingList spendingList);
    }
}