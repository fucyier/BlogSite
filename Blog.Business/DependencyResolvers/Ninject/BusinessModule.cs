using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Activation;
using Ninject.Modules;
using Ninject;
using Blog.Business.Abstract;
using Blog.Business.Concrete.Managers;
using Blog.Domain.Concrete;
using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete.EntityFramework;

namespace Blog.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        

        public override void Load()
        {
            Bind<IPostService>().To<PostManager>();
            Bind<IPostDal>().To<EfPostDal>();
            Bind<ITagService>().To<TagManager>();
            Bind<ITagDal>().To<EfTagDal>();
            Bind<ICommentService>().To<CommentManager>();
            Bind<ICommentDal>().To<EfCommentDal>();
            Bind<IAuthorService>().To<AuthorManager>();
            Bind<IAuthorDal>().To<EfAuthorDal>();
        }
    }
}
