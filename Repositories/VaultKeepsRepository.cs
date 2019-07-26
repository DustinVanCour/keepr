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

    public IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string query = @"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vaultId = @vaultId AND vk.userId = @userId);";
      IEnumerable<Keep> data = _db.Query<Keep>(query, new { vaultId, userId });
      if (data == null) throw new Exception("Invalid ID");
      return data;
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

    internal object Update(VaultKeep value)
    {
      string query = @"
      DELETE FROM vaultkeeps WHERE(vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId);";
      int changedRows = _db.Execute(query, value);
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted VaultKeep";
    }

    public string Delete(VaultKeep value)
    {
      string query = @"
      DELETE FROM vaultkeeps WHERE(vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId);";
      int changedRows = _db.Execute(query, value);
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully Deleted VaultKeep";
    }
  }
}