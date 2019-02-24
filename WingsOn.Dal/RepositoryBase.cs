﻿using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class RepositoryBase<T> : IRepository<T> where T : DomainObject
    {
        protected RepositoryBase()
        {
            Repository = new List<T>();
        }

        protected List<T> Repository;

        public virtual IEnumerable<T> GetAll()
        {
            return Repository;
        }

        public virtual T Get(int id)
        {
            return GetAll().SingleOrDefault(a => a.Id == id);
        }

        public virtual void Save(T element)
        {
            if (element == null)
            {
                return;
            }

            T existing = Get(element.Id);
            if (existing != null)
            {
                Repository.Remove(existing);
            }

            Repository.Add(element);
        }
    }
}
