using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<VaultKeep> GetAll()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    public VaultKeep Create(VaultKeep value)
    {
      string query = @"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
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