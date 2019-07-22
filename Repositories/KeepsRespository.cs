using System;
using System.Data;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }

        internal object GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal object Create(Keep value)
        {
            throw new NotImplementedException();
        }

        internal object Update(Keep value)
        {
            throw new NotImplementedException();
        }

        internal object Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}