using System.Web.Mvc;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
{0}

namespace Web
{
    public class InjectionConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            // 注册Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly())
                   .PropertiesAutowired()
                   .InstancePerLifetimeScope();

            #region 注册类别
            {1}
            #endregion 注册类别END

            //通过容器配置生成容器.   
            var container = builder.Build();
            //提供给MVC  
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}