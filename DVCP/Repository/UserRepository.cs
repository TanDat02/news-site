using DVCP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVCP.Repository
{
    public class UserRepository
    {
        private DVCPContext entity;// = new DVCPContext();
        public UserRepository(DVCPContext context)
        {
            this.entity = context;
        }
        public void Add(User1 user)
        {
            entity.Users.Add(user);
        }
        public User1 FindByUsername(string user)
        {
            User1 u = entity.Users.Where(x => x.EmailID == user).FirstOrDefault();
            return u;
        }
        public User1 FindByID(int id)
        {
            User1 u = entity.Users.Find(id);
            return u;
        }
        public IQueryable<User1> AllUsers()
        {
            IQueryable<User1> query = entity.Users;
            return query.AsQueryable();
        }
        public void Delete(User1 user)
        {
            entity.Users.Remove(user);
        }
        public void Update(User1 u)
        {
            entity.Entry(u).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            entity.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entity.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}