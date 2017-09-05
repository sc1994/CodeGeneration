# CodeGeneration
代码生成器, 提供简单的框架代码生成, 详细用法见 Info.json

### 主要依赖
- Newtonsoft.Json (Common) // MVC需要和Common版本同步
- Ninject (Common,MVC)
- Ninject.Web.Common (Common,MVC)
- Ninject.Web.WebApi (Common,MVC)
- Ninject.MVC5 (MVC)
- Dapper (DAL,Common)
- ....有遗漏 ,其实依赖项比较多,加之 Infrastructure 被单独拆分 需要格外注意nuget上引用的项目的版本一致

### 功能
- 快速生成表对应的数据结构

### 示例
[点我查看](https://github.com/sc1994/CodeExample)

### 事项
- 使用之前请先配置Info.json
- 在使用代码生成器之前需要注意,引用的各种库版本是否有更新,
- 代码生成完成之后需要在nuget上还原库,且更新(这边不建议使用F5生成代码然后他去还原库,而是在nuget页面去还原和更新库)
- 程序可以多表一起生成,也可以指定单表生成
- 本人不才,此软件可能比较脆弱, 使用出现问题可能需要各位自己解决, (多半是引用不全,引用版本之间的问题, 需要各位耐心的解决, 仔细观察问题出现的地方,
    对照[这里](https://github.com/sc1994/CodeExample)解决自己的问题)
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

### 2017年9月5日 更新
- 迁移数据访问基类到common中, 除common/model外,其他层都可以依赖common
- 使用代码添加package.config 的配置
- 使用代码添加 .csproj 文件内容
- 

### TODO
- 为dal中的数据基本操作添加事务
