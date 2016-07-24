using SpendingLists.Data;
using SpendingLists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpendingLists.Services
{
    public class Repo : IRepo, IDisposable 

    {
        private ApplicationDbContext _context;

        public Repo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SpendingList> GetSpendingLists()
        {
            return _context.SpendingLists.ToList();
        }

        public SpendingList GetSpendingListByID(int id)
        {
            return _context.SpendingLists.SingleOrDefault(m => m.Id == id);
        }

        public void InsertStudent(SpendingList spendingList)
        {
            _context.SpendingLists.Add(spendingList);
        }

        public void DeleteStudent(int id)
        {
            SpendingList spendingList = _context.SpendingLists.SingleOrDefault(m => m.Id == id);
            _context.SpendingLists.Remove(spendingList);
        }

        public void UpdateSpendingList(SpendingList spendingList)
        {
            _context.Entry(spendingList).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
