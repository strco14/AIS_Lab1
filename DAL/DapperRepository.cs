using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ModelLib;

namespace DAL
{
    public class DapperRepository : IRepository<Wine>
    {
        static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\GitHub\\AIS_Lab1\\DAL\\DatabaseWines.mdf;Integrated Security=True";
        IDbConnection db = new SqlConnection(ConnectionString);
        public void Add(Wine obj)
        {
            string SqlQuery = "INSERT INTO Wines (Name, Type, Sugar, Homeland, Rating) " +
                "VALUES (@Name, @Type, @Sugar, @Homeland, @Rating); SELECT CAST(SCOPE_IDENTITY() as int)";
            int id = db.Query<int>(SqlQuery, obj).FirstOrDefault();
            obj.Id = id;
        }

        public void Delete(Wine obj)
        {
            string SqlQuery = $"DELETE FROM Wines WHERE Id = @Id";
            db.Query<Wine>(SqlQuery, obj);
        }

        public IEnumerable<Wine> ReadAll()
        {
            return db.Query<Wine>("SELECT * FROM dbo.Wines").ToList();
        }

        public Wine ReadById(int id)
        {
            return db.Query<Wine>($"SELECT * FROM Wines WHERE Id = {id}").FirstOrDefault();
        }
        public void UpdateRating(int id, int rating)
        {
            string sql = "UPDATE Wines SET Rating = @rating WHERE Id = @id";
            db.Execute(sql, new { rating, id });
        }
        public void Update(Wine obj)
        {
            string sql = @"UPDATE Wines 
                  SET Name = @Name, Type = @Type, Sugar = @Sugar, 
                      Homeland = @Homeland, Rating = @Rating 
                  WHERE Id = @Id";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(sql, new
                {
                    Name = obj.Name,
                    Type = obj.Type,
                    Sugar = obj.Sugar,
                    Homeland = obj.Homeland,
                    Rating = obj.Rating,
                    Id = obj.Id
                });
            }
        }
    }
}
