using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsBooks.Models.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BookstoreContext context { get; set; }
        private DbSet<T> dbSet { get; set; }

        private int? count;
        public int Count => count ?? dbSet.Count();

        public Repository(BookstoreContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        public virtual T Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }

        public virtual T Get(int id) => dbSet.Find(id);

        public virtual T Get(string id) => dbSet.Find(id);

        public virtual void Insert(T entity) => dbSet.Add(entity);


        public virtual void Update(T entity) => dbSet.Update(entity);
      
        public virtual void Delete(T entity) => dbSet.Remove(entity);

        public virtual void Save() => context.SaveChanges();


        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach(string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query.Where(clause);
                }

                count = query.Count();
            }

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                    query = query.OrderBy(options.OrderBy);
                else
                    query = query.OrderByDescending(options.OrderBy);
            }

            if (options.HasPaging)
             query = query.PageBy(options.PageNumber, options.PageSize);

            return query;

         }

    }
}