using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class DapperRepository : IRepository
    {
        private readonly IDbContext dbContext;

        public DapperRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.GetAll<TEntity>());
        }

        public TEntity Get<TEntity>(int id) where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.Get<TEntity>(id));
        }

        public int Insert<TEntity>(TEntity entity) where TEntity : class
        {
            return (int)dbContext.PerformDbRequest(db => db.Insert(entity));
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            dbContext.PerformDbRequest(db => db.Update(entity));
        }

        public void Delete<TEntity>(int id) where TEntity : class
        {
            dbContext.PerformDbRequest(db =>
            {
                var entity = db.Get<TEntity>(id);
                db.Delete(entity);
            });
        }

        public void ExecuteQuery(string query, object paramModel = null)
        {
            dbContext.PerformDbRequest(db => db.Query(query, paramModel));
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string query, object paramModel = null) where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.Query<TEntity>(query, paramModel));
        }

        public TEntity ExecuteQuerySingle<TEntity>(string query, object paramModel = null) where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.QuerySingle<TEntity>(query, paramModel));
        }

        public void ExecuteSP(string spName, object paramModel = null)
        {
            dbContext.PerformDbRequest(db => db.Query(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<TEntity> ExecuteSP<TEntity>(string spName, object paramModel = null) where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.Query<TEntity>(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public TEntity ExecuteSPSingle<TEntity>(string spName, object paramModel = null) where TEntity : class
        {
            return dbContext.PerformDbRequest(db => db.QueryFirstOrDefault<TEntity>(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TReturn>(string spName, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class
        {
            return dbContext.PerformDbRequest(db => db.Query(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TReturn>(string spName, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class
        {
            return dbContext.PerformDbRequest(db => db.Query(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class
        {
            return dbContext.PerformDbRequest(db => db.Query(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class
        {
            return dbContext.PerformDbRequest(db => db.Query(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }
    }
}
