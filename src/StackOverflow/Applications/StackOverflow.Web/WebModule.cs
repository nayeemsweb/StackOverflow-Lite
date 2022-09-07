﻿using Autofac;
using StackOverflow.Web.Areas.MyProfile.Models;
using StackOverflow.Web.Models;
using StackOverflow.Web.Models.Account;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //Home Models 
        builder.RegisterType<AllPostModel>().AsSelf();

        //Account Models
        builder.RegisterType<RegisterModel>().AsSelf();
        builder.RegisterType<LoginModel>().AsSelf();

        //Post Models
        builder.RegisterType<CreatePostModel>().AsSelf();
        builder.RegisterType<UpdatePostModel>().AsSelf();
        builder.RegisterType<ListPostModel>().AsSelf();

        //Comment Models
        builder.RegisterType<CreateCommentModel>().AsSelf();
        builder.RegisterType<UpdateCommentModel>().AsSelf();
        builder.RegisterType<ListCommentModel>().AsSelf();

        base.Load(builder);
    }
}