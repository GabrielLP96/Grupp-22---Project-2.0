using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataLayer.Repositories;


namespace DataLayer.Repositories
{
    public class Repository<Design> : IRepository<Design> where Design : class
    {
        protected readonly DbContext dbContext;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //retrieve
        public Design Get(int ID)
        {
            return dbContext.Set<Design>().Find(ID);
        }

        //retrieve more then one
        public List<Design> GetAll()
        {
            return dbContext.Set<Design>().ToList();
        }

        // Add
        public void Add(Design design)
        {
            dbContext.Set<Design>().Add(design);
        }

        //Add or uppdate
        public void AddUppdate(Design design)
        {
            dbContext.Set<Design>().AddOrUpdate(design);
        }

        //Add more
        public void AddMore(IEnumerable<Design> design)
        {
            dbContext.Set<Design>().AddRange(design);
        }

        //Remove
        public void Remover(Design design)
        {
            dbContext.Set<Design>().Remove(design);
        }

        //Remove more then one
        public void RemoveMore(IEnumerable<Design> Designs)
        {
            dbContext.Set<Design>().AddRange(Designs);
        }
    }
}
