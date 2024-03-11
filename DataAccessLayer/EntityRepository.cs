using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private Context context = new Context();

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(int Id)
        {
            var i = context.Set<T>().Find(Id);
            context.Set<T>().Remove(i);
        }

        public ObservableCollection<T> GetAll()
        {
            return new ObservableCollection<T>(context.Set<T>().ToList());
        }

        public T GetById(int Id)
        {
            var s = context.Set<T>().FirstOrDefault(x => x.Id == Id);
            return s;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
