using AspNetCoreHero.ToastNotification;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogApp.Business.Abstract;
using BlogApp.Business.Concrete;
using BlogApp.DataAccess.Abstract;
using BlogApp.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
    builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
    builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();    
    builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
    builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
    builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
    builder.RegisterType<Message2Manager>().As<IMessage2Service>().SingleInstance();
    builder.RegisterType<NotificationManager>().As<INotificationService>().SingleInstance();
    builder.RegisterType<SubscribeManager>().As<ISubscribeService>().SingleInstance();
    builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();

    builder.RegisterType<EfAboutDal>().As<IAboutDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfArticleDal>().As<IArticleDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfCommentDal>().As<ICommentDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfContactDal>().As<IContactDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfMessageDal>().As<IMessageDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfMessage2Dal>().As<IMessage2Dal>().InstancePerLifetimeScope();
    builder.RegisterType<EfNotificationDal>().As<INotificationDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfSubscribeDal>().As<ISubscribeDal>().InstancePerLifetimeScope();
    builder.RegisterType<EfWriterDal>().As<IWriterDal>().InstancePerLifetimeScope();
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(cfg =>
{
    cfg.DurationInSeconds = 3;
    cfg.IsDismissable = true;
    cfg.Position = NotyfPosition.BottomRight;
});
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Account/Login";
    });
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.Run();