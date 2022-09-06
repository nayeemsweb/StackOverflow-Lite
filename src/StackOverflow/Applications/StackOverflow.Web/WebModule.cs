using Autofac;
using StackOverflow.Web.Areas.MyProfile.Models;
using StackOverflow.Web.Models.Account;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //Account Models
        builder.RegisterType<RegisterModel>().AsSelf();
        builder.RegisterType<LoginModel>().AsSelf();

        //Post Models
        builder.RegisterType<CreatePostModel>().AsSelf();
        builder.RegisterType<UpdatePostModel>().AsSelf();
        builder.RegisterType<ListPostModel>().AsSelf();

        base.Load(builder);
    }
}