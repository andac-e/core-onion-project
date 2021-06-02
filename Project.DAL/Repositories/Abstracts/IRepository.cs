using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T:IEntity
    {


        //List Commands
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();

        //Modify Commands
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        void Destroy(T item);

        //Linq Expressions
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);

        object SelectViaClass<X>(Expression<Func<T, X>> exp);

        //Find
        T Find(int id);


    }
}
