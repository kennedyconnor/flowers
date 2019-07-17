using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using flowers.Models;

namespace flowers.Repositories
{
  public class FlowerRepository
  {
    private readonly IDbConnection _db;
    public FlowerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Flower> GetAll()
    {
      return _db.Query<Flower>("SELECT * FROM flowers");
    }

    public Flower GetById(int id)
    {
      string query = "SELECT * FROM flowers WHERE id = @id";
      Flower flower = _db.QueryFirstOrDefault<Flower>(query, new { id });
      if (flower == null) throw new Exception("Invalid Id");
      return flower;
    }

    public Flower Create(Flower data)
    {
      string query = @"INSERT INTO flowers (name, color) VALUES (@Name, @Color);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, data);
      data.Id = id;
      return data;
    }

    public Flower Update(Flower data)
    {
      string query = @"UPDATE flowers
                SET
                    name = @Name,
                    color = @Color
                WHERE id = @Id;
      SELECT * FROM flowers WHERE id = @Id
            ";
      return _db.QueryFirstOrDefault<Flower>(query, data);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM flowers WHERE id = @id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted.";
    }
  }
}