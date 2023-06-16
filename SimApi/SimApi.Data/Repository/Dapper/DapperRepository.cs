using Dapper;
using SimApi.Base;
using SimApi.Data.Context;
using System.Reflection;
using static Dapper.SqlMapper;

namespace SimApi.Data.Repository;

public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void DeleteById(int id)
    {
        var query = $"delete from {typeof(Entity).Name} where Id ={id}";

        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(query);
        }
    }

    public List<Entity> GetAll()
    {
        var query = $"select * from {typeof(Entity).Name}";


        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            return (List<Entity>)connection.Query<Entity>(query);
        }
    }

    public Entity GetById(int id)
    {
        var query = $"select * from {typeof(Entity).Name} where Id ={id}";

        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
           return connection.QueryFirst<Entity>(query);
        }
    }

    public void Insert(Entity entity)
    {
        var columns = GetColumns();
        var stringOfColumns = string.Join(", ", columns.Select(e=> $"[{e}]"));
        var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
        var query = $"INSERT INTO [dbo].[{typeof(Entity).Name}] ({stringOfColumns}) VALUES ({stringOfParameters})";

        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(query,entity);
            connection.Close();
        }
    }

    public void Update(Entity entity)
    {
        var columns = GetColumns();
        var stringOfColumns = string.Join(", ", columns.Select(e => $"[{e}]=@{e}"));
        var query = $"update [dbo].[{typeof(Entity).Name}] set {stringOfColumns} where Id ={entity.Id}";

        using (var connection = dbContext.CreateConnection())
        {
            connection.Open();
            connection.Execute(query, entity);
            connection.Close();
        }
    }
    private IEnumerable<string> GetColumns()
    {
        return typeof(Entity)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
    }
}
