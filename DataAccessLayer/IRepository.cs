using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        void Add(T item);
        void Delete(int Id);
        ObservableCollection<T> GetAll();
        T GetById(int Id);
        void Save();
    }
}
