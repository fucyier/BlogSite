using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author Get(int id);

        Author Add(Author entity);

        void Delete(Author entity);

        Author Update(Author entity);
        void EditStatus(string id, bool statu);

    }
}
