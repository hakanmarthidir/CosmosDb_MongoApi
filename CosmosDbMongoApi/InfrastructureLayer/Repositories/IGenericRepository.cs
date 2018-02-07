using CosmosDbMongoApi.SharedKernel.BaseClasses;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CosmosDbMongoApi.InfrastructureLayer.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {       
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(string id);
        TEntity GetById(string Id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }          
}
