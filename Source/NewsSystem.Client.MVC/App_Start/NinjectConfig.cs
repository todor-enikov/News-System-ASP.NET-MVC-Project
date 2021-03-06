[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NewsSystem.Client.MVC.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NewsSystem.Client.MVC.App_Start.NinjectConfig), "Stop")]

namespace NewsSystem.Client.MVC.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Newssystem.Data;
    using Newssystem.Data.Repository;
    using Ninject;
    using Ninject.Web.Common;
    using Services;
    using Services.Contracts;
    using System;
    using System.Web;

    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<INewsSystemDbContext>().To<NewsSystemDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfGenericRepository<>)).To(typeof(EfGenericRepository<>));

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<INewsService>().To<NewsService>();
            kernel.Bind<IRoleService>().To<RoleService>();
        }
    }
}
