using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryCotext { get; set; }
        
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryCotext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryCotext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryCotext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryCotext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryCotext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryCotext.Set<T>().Remove(entity);
        }
    }
}
