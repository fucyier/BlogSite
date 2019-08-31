using Blog.Business.Abstract;
using Blog.DataAccess.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete.Managers
{
   public class AuthorManager:IAuthorService
   {
       private IAuthorDal _authorDal;
       public AuthorManager(IAuthorDal authorDal)
       {
           _authorDal = authorDal;
       }
        public List<Author> GetAll()
        {
           return _authorDal.GetAll();
        }

        public Author Get(int id)
        {
            return _authorDal.Get(id); 
        }

        public Author Add(Author entity)
        {
            return _authorDal.Add(entity) ;
        }

        public void Delete(Author entity)
        {
             _authorDal.Delete(entity);
        }

        public Author Update(Author entity)
        {
           return _authorDal.Update(entity);
        }

        public void EditStatus(string id,bool statu)
        {
            _authorDal.EditStatus(id, statu);
        }

    
    }
}
