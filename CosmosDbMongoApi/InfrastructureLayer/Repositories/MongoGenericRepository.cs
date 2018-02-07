using CosmosDbMongoApi.InfrastructureLayer.Context;
using CosmosDbMongoApi.SharedKernel.BaseClasses;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CosmosDbMongoApi.InfrastructureLayer.Repositories
{
    public class MongoGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoContext _dbContext;
        private IMongoCollection<TEntity> _collection;

        public MongoGenericRepository(IMongoContext dbContext)
        {
            this._dbContext = dbContext;
            this._collection = _dbContext.Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne<TEntity>(c => c._Id == id);
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            _collection.ReplaceOne<TEntity>(x => x._Id == entity._Id, entity, new UpdateOptions { IsUpsert = true });
        }

        public TEntity GetById(string id)
        {
            return _collection.Find<TEntity>(x => x._Id == id).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _collection.AsQueryable<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
    }
}
