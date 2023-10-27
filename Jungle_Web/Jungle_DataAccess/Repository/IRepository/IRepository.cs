﻿using System.Linq.Expressions;

namespace Jungle_DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Les méthodes devant être implantées dans les repositories

        T Get(int id);

        IEnumerable<T> GetAll(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = null,
          bool isTracking = true
          );


        // Retourne le 1er seulement
        T FirstOrDefault(
          Expression<Func<T, bool>> filter = null,
          string includeProperties = null,
          bool isTracking = true
          );

        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void Save();

    }

}
