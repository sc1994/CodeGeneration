# CodeGeneration
代码生成器, 提供简单的框架代码生成, 详细用法见 Info.json

### 依赖
- Newtonsoft.Json (Common) // MVC需要和Common版本同步
- Ninject (Common,MVC)
- Ninject.Web.Common (Common,MVC)
- Ninject.Web.WebApi (Common,MVC)
- Ninject.MVC5 (MVC)
- Dapper (DAL,Common)
- ....可能有遗漏

### 功能
- 快速生成表对应的数据结构

### 示例
[点我查看](https://github.com/sc1994/CodeExample)

### 事项
- 使用之前请先配置Info.json
- 程序可以多表一起生成,也可以指定单表生成
- MVC 项目默认引用了`Newtonsoft.Json` 版本6.x.x 需要升级至同公共层(Common) 一致
- 程序纯属为了个人方便之用

### 2017年8月31日 更新
- 在原有的三层+数据访问接口层(IDAL)的前提下加上逻辑接口层(IBLL)
- 加入公共层(Common) 
- 加入 SqlHelper.cs 文件 [点我查看](https://github.com/sc1994/SqlHelper)
- 加入 ConvertHelper.cs 文件 [点我查看](https://github.com/sc1994/ConverHelper)
- 引入 Ninject (DI容器) 已基本配置 你需要的就是 在确保完全引入 Ninject 组件之后在App_Start/NinjectWebCommon.cs中写入
```
/// <summary>
/// Load your modules or register your services here!
/// </summary>
/// <param name="kernel">The kernel.</param>
private static void RegisterServices(IKernel kernel)
{
    var ninjectDependencyResolver = new NinjectDependencyResolver(kernel); 
    System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = ninjectDependencyResolver;
}
```

### TODO
- 目前项目之间的层级引用关系依然需要自己操作
- 目前没有在packages.config做一些事,所以nuget需要那些项目暂时罗列在`依赖`中 ,请手动配置
