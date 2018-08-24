using System;
using System.Collections.Generic;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(int id) where TEntity : class;

        int Insert<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(int id) where TEntity : class;

        void ExecuteQuery(string query, object paramModel = null);
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string query, object paramModel = null) where TEntity : class;
        TEntity ExecuteQuerySingle<TEntity>(string query, object paramModel = null) where TEntity : class;

        void ExecuteSP(string spName, object paramModel = null);
        IEnumerable<TEntity> ExecuteSP<TEntity>(string spName, object paramModel = null) where TEntity : class;
        TEntity ExecuteSPSingle<TEntity>(string spName, object paramModel = null) where TEntity : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TReturn>(string spName, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TReturn>(string spName, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        IEnumerable<TReturn> ExecuteSP<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;
    }
}
