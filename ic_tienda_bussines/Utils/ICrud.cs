using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ic_tienda_bussines.Utils
{
    public interface ICrud<T>
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public T Create(T entity);
        public void Update(int id, T entity);
        public void Delete(int id);
    }
}
