# CodeGeneration
代码生成器, 提供简单的框架代码生成, 详细用法见 Info.json

### 依赖

### 功能
- 快速生成表对应的数据结构

### 事项
- 使用之前请先配置Info.json
- 程序可以多表一起生成,也可以指定单表生成
- 程序纯属为了个人方便之用

### 2017年8月31日 更新
- 在原有的三层+数据访问接口层(IDAL)的前提下加上逻辑接口层(IBLL)
- 加入公共层(Common) 
- 加入 SqlHelper.cs 文件 [link](https://github.com/sc1994/SqlHelper)
- 加入 ConvertHelper.cs 文件 [link](https://github.com/sc1994/ConverHelper)
- 引入 Ninject (DI容器) 已基本配置 你需要的就是 在确保完全引入 Ninject 组件之后在App_Start/NinjectWebCommon.cs中写入
/// <summary>
/// Load your modules or register your services here!
/// </summary>
/// <param name="kernel">The kernel.</param>
private static void RegisterServices(IKernel kernel)
{
    var ninjectDependencyResolver = new NinjectDependencyResolver(kernel); 
    System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = ninjectDependencyResolver;
}
- 
