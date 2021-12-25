using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<ContactLocationManager>().As<IContactLocationService>().SingleInstance();
            builder.RegisterType<EfContactLocationDal>().As<IContactLocationDal>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<Message2Manager>().As<IMessage2Service>().SingleInstance();
            builder.RegisterType<EfMessage2Dal>().As<IMessage2Dal>().SingleInstance();

            builder.RegisterType<NewsLetterManager>().As<INewsLetterService>().SingleInstance();
            builder.RegisterType<EfNewsLetterDal>().As<INewsLetterDal>().SingleInstance();

            builder.RegisterType<NotificationManager>().As<INotificationService>().SingleInstance();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>().SingleInstance();

            builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>().SingleInstance();

            builder.RegisterType<LogoTitleManager>().As<ILogoTitleService>().SingleInstance();
            builder.RegisterType<EfLogoTitleDal>().As<ILogoTitleDal>().SingleInstance();




        }
    }
}
