using System;
using System.Data;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
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

        internal object Create(Vault value)
        {
            throw new NotImplementedException();
        }

        internal object Update(Vault value)
        {
            throw new NotImplementedException();
        }

        internal object Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}