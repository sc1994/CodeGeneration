using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CodeGeneration
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            #region 初始化
            START: Helper.Logo();
            Console.ReadLine();
            Console.WriteLine("配置文件加载成功");
            Helper.ShowInfo();
            if (Console.ReadLine()?.ToLower() != "y")
            {
                goto START;
            }
            Console.Write("初始化");
            Helper.Load();
            DirectoryInfo[] directoryInfos;
            try
            {
                directoryInfos = InfoModel.Info.SolutionPath.GetNextFile();
            }
            catch (Exception)
            {
                Console.WriteLine("错误的 SolutionPath 请检查配置文件");
                throw;
            }
            Console.WriteLine("加载解决方案 Success");
            #endregion

            // 检验必要的文件和路径
            var layersPaths = new Dictionary<string, string>();
            #region Model
            var pathDb = InfoModel.Info.Model.Split('/')[0];
            string path;
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在BaseModel.cs");
                if (File.Exists(path + "\\BaseModel.cs"))
                {
                    Helper.ShowGood("已存在BaseModel.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 BaseModel.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetBaseModelCode(), path + "\\BaseModel.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成BaseModel.cs Success");
                }
                layersPaths.Add("Model", Helper.ExamineFolder(InfoModel.Info.Model, path));
            }
            else
                Helper.ShowError($"验证: {InfoModel.Info.Model} Error");
            #endregion

            #region IDAL
            pathDb = InfoModel.Info.IDal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在IBaseDal.cs");
                if (File.Exists(path + "\\IBaseDal.cs"))
                {
                    Helper.ShowGood("已存在IBaseDal.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 IBaseDal.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetIBaseDalCode(), path + "\\IBaseDal.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成IBaseDal.cs Success");
                }
                layersPaths.Add("IDal", Helper.ExamineFolder(InfoModel.Info.IDal, path));
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion

            #region DAL
            pathDb = InfoModel.Info.Dal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
            layersPaths.Add("Dal", Helper.ExamineFolder(InfoModel.Info.Dal, path));
            #endregion

            #region BLL
            pathDb = InfoModel.Info.Bll.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                Console.WriteLine("验证是否存在BaseBll.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\BaseBll.cs"))
                {
                    Helper.ShowGood("已存在BaseBll.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 BaseBll.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetBaseBllCode(), path + "\\BaseBll.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成BaseBll.cs Success");
                }
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Bll", Helper.ExamineFolder(InfoModel.Info.Bll, path));
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion

            #region IBLL
            pathDb = InfoModel.Info.IBll.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                Console.WriteLine("验证是否存在IBaseBll.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\IBaseBll.cs"))
                {
                    Helper.ShowGood("已存在IBaseBll.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 IBaseBll.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetIBaseBllCode(), path + "\\IBaseBll.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成IBaseBll.cs Success");
                }
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("IBll", Helper.ExamineFolder(InfoModel.Info.IBll, path));
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion

            #region Common
            pathDb = InfoModel.Info.Common.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");

                #region ConvertHelper
                Console.WriteLine("验证是否存在ConvertHelper.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\ConvertHelper.cs"))
                {
                    Helper.ShowGood("已存在ConvertHelper.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 ConvertHelper.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetConvertCode(), path + "\\ConvertHelper.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成ConvertHelper Success");
                }
                #endregion

                #region SqlHelper
                Console.WriteLine("验证是否存在SqlHelper.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\SqlHelper.cs"))
                {
                    Helper.ShowGood("已存在SqlHelper.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 SqlHelper.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetSqlHelperCode(), path + "\\SqlHelper.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成SqlHelper Success");
                }
                #endregion

                #region DBClient
                Console.WriteLine("验证是否存在DBClient.cs");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                if (File.Exists(path + "\\DBClient.cs"))
                {
                    Helper.ShowGood("已存在DBClient.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 DBClient.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetDbClientCode(), path + "\\DBClient.cs", path + "\\" + pathDb + ".csproj");
                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成DBClient.cs Success");
                }
                #endregion
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion

            #region Infrastructure
            pathDb = InfoModel.Info.Infrastructure.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在NinjectDependencyResolver.cs");
                if (File.Exists(path + "/" + "NinjectDependencyResolver.cs"))
                {
                    Helper.ShowGood("已存在NinjectDependencyResolver.cs");
                }
                else
                {
                    Console.WriteLine("正在帮您生成 NinjectDependencyResolver.cs...");
                    try
                    {
                        Helper.WriteToFile(Code.GetDiBaseCode(),
                                           path + "/" + "NinjectDependencyResolver.cs",
                                           path + "/" + InfoModel.Info.Infrastructure.Split('/')[0] + ".csproj");

                    }
                    catch (Exception ex)
                    {
                        Helper.ShowError("出现异常-->" + ex.Message);
                    }
                    Helper.ShowGood("生成 NinjectDependencyResolver.cs Success");
                }
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");

            #endregion

            #region 和数据库握手
            Console.Write("尝试连接: " + InfoModel.Info.DBName);
            Helper.Load();
            try
            {
                DbClient.GetConnection();
            }
            catch (Exception)
            {
                Helper.ShowError($"连接: {InfoModel.Info.DBName} Error");
                return;
            }
            Console.WriteLine($"连接: {InfoModel.Info.DBName} Success");
            READERROR: Console.WriteLine("输入需要表名以\",\"隔开(整库生成请输入ALL)");
            var tables = Console.ReadLine();

            if (string.IsNullOrEmpty(tables))
            {
                goto READERROR;
            }
            var tableInfoList = Helper.GetTableInfos(tables);

            var group = from table in tableInfoList
                        group table by table.TableName
                        into g
                        select g;
            #endregion

            // 收集接口和实现信息 绑定到 Ninject 的DI 容器中
            var bindToList = new Dictionary<string, string>();
            foreach (var g in group)
            {
                foreach (var layersPath in layersPaths)
                {
                    Console.WriteLine($"表: {g.Key}正在生成数据到: {layersPath.Value} ....");
                    switch (layersPath.Key)
                    {
                        #region 生成Model

                        case "Model":

                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Info.Model.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetModelCode(g), layersPath.Value + "\\" + g.Key + ".cs", path + "\\" + InfoModel.Info.Model.Split('/')[0] + ".csproj");
                                }
                                else
                                {
                                    Helper.ShowError("路径错误-->跳过 Model ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.ShowError("出现异常-->" + ex.Message);
                            }
                            break;

                        #endregion

                        #region 生成BLL

                        case "Bll":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Info.Bll.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Bll.cs"))
                                    {
                                        Helper.ShowGood("已存在" + g.Key + "Bll.cs       跳过...");
                                    }
                                    else
                                    {
                                        Helper.WriteToFile(Code.GetBllCode(g), layersPath.Value + "\\" + g.Key + "Bll.cs", path + "\\" + InfoModel.Info.Bll.Split('/')[0] + ".csproj");
                                    }
                                }
                                else
                                {
                                    Helper.ShowError("路径错误-->跳过 Bll ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.ShowError("出现异常-->" + ex.Message);
                            }
                            bindToList.Add("I" + g.Key + "Bll", g.Key + "Bll");
                            break;

                        #endregion

                        #region 生成IBLL

                        case "IBll":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Info.IBll.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    if (!File.Exists(layersPath.Value + "\\" + g.Key + "IBll.cs"))
                                    {
                                        Helper.WriteToFile(Code.GetIBllCode(g), layersPath.Value + "\\" + g.Key + "IBll.cs", path + "\\" + InfoModel.Info.IBll.Split('/')[0] + ".csproj");
                                    }
                                    else
                                    {
                                        Helper.ShowGood("已存在" + g.Key + "IBll.cs       跳过...");
                                    }
                                }
                                else
                                {
                                    Helper.ShowError("路径错误-->跳过 IBll ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.ShowError("出现异常-->" + ex.Message);
                            }
                            break;

                        #endregion

                        #region 生成DAL

                        case "Dal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Info.Dal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetDalCode(g), layersPath.Value + "\\" + g.Key + "Dal.cs", path + "\\" + InfoModel.Info.Dal.Split('/')[0] + ".csproj");
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Dal.Extend.cs"))
                                    {
                                        Helper.ShowGood("已存在" + g.Key + "Dal.Extend.cs       跳过...");
                                    }
                                    else
                                    {
                                        Helper.WriteToFile(Code.GetDalExtendCode(g), layersPath.Value + "\\" + g.Key + "Dal.Extend.cs", path + "\\" + InfoModel.Info.Dal.Split('/')[0] + ".csproj");
                                    }
                                }
                                else
                                {
                                    Helper.ShowError("路径错误-->跳过 Dal ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.ShowError("出现异常-->" + ex.Message);
                            }
                            bindToList.Add("I" + g.Key + "Dal", g.Key + "Dal");
                            break;

                        #endregion

                        #region 生成IDal

                        case "IDal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Info.IDal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetIDalCode(g), layersPath.Value + "\\" + "I" + g.Key + "Dal.cs", path + "\\" + InfoModel.Info.IDal.Split('/')[0] + ".csproj");
                                }
                                else
                                {
                                    Helper.ShowError("路径错误-->跳过 IDal ");
                                }
                            }
                            catch (Exception ex)
                            {
                                Helper.ShowError("出现异常-->" + ex.Message);
                            }
                            break;

                        #endregion

                        default: continue;
                    }
                }
            }

            #region 生成DI容器绑定代码
            if (tables.ToLower() == "all")
            {
                Console.WriteLine("生成 DI 相关代码....");
                var diPath = InfoModel.Info.SolutionPath + "/" + InfoModel.Info.Infrastructure.Replace("/", ".");
                if (!Directory.Exists(diPath))
                    Directory.CreateDirectory(diPath);
                Helper.WriteToFile(Code.GetDiBindCode(bindToList),
                                   diPath + "/" + "BindToInfo.cs",
                                   diPath + "/" + InfoModel.Info.Infrastructure.Split('/')[0] + ".csproj");
            }
            #endregion

            #region 配置程序集之间的引用
            Console.WriteLine("正在配置程序集之间的引用关系...."); // todo
            #endregion

            #region 配置nuget包

            #endregion


            Console.ReadLine();
            Console.Clear();
            goto START;
        }
    }
}
