using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CodeGeneration
{
    class Program
    {
        public static Info InfoModel = "../../Info.json".GetFileText().ToObjectByJson<Info>();
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
                directoryInfos = InfoModel.SolutionPath.GetNextFile();
            }
            catch (Exception)
            {
                Console.WriteLine("错误的 SolutionPath 请检查配置文件");
                throw;
            }
            Console.WriteLine("加载解决方案 Success");
            #endregion

            #region 检验必要的文件和路径
            var layersPaths = new Dictionary<string, string>();
            #region Model
            var pathDb = InfoModel.Model.Split('/')[0];
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
                layersPaths.Add("Model", Helper.ExamineFolder(InfoModel.Model, path));

            }
            else
                Helper.ShowError($"验证: {InfoModel.Model} Error");
            #endregion

            #region IDAL
            pathDb = InfoModel.IDal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                Console.WriteLine("验证是否存在BaseModel.cs");
                if (File.Exists(path + "\\BaseModel.cs"))
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
                layersPaths.Add("IDal", Helper.ExamineFolder(InfoModel.IDal, path));
            }
            #endregion

            #region DAL
            pathDb = InfoModel.Dal.Split('/')[0];
            if (directoryInfos.Any(x => x.FullName.Contains(pathDb)))
            {
                Console.WriteLine($"验证: {pathDb} Success");
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
                    Helper.ShowGood("生成BaseModel.cs Success");
                }
                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(pathDb))?.FullName ?? "";
                layersPaths.Add("Dal", Helper.ExamineFolder(InfoModel.Dal, path));
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion

            #region BLL
            pathDb = InfoModel.Bll.Split('/')[0];
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
                layersPaths.Add("Bll", Helper.ExamineFolder(InfoModel.Bll, path));
            }
            else
                Helper.ShowError($"验证: {pathDb} Error");
            #endregion
            #endregion

            #region 和数据库握手
            Console.Write("尝试连接: " + InfoModel.DBName);
            Helper.Load();
            try
            {
                DbClient.GetConnection();
            }
            catch (Exception)
            {
                Helper.ShowError($"连接: {InfoModel.DBName} Error");
                return;
            }
            Console.WriteLine($"连接: {InfoModel.DBName} Success");
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
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Model.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetModelCode(g), layersPath.Value + "\\" + g.Key + ".cs", path + "\\" + InfoModel.Model.Split('/')[0] + ".csproj");
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
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Bll.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Bll.cs"))
                                    {
                                        Helper.ShowGood("已存在" + g.Key + "Bll.cs       跳过...");
                                    }
                                    else
                                    {
                                        Helper.WriteToFile(Code.GetBllCode(g), layersPath.Value + "\\" + g.Key + "Bll.cs", path + "\\" + InfoModel.Bll.Split('/')[0] + ".csproj");
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
                            break;
                        #endregion

                        #region 生成DAL
                        case "Dal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.Dal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetDalCode(g), layersPath.Value + "\\" + g.Key + "Dal.cs", path + "\\" + InfoModel.Dal.Split('/')[0] + ".csproj");
                                    if (File.Exists(layersPath.Value + "\\" + g.Key + "Dal.Extend.cs"))
                                    {
                                        Helper.ShowGood("已存在" + g.Key + "Dal.Extend.cs       跳过...");
                                    }
                                    else
                                    {
                                        Helper.WriteToFile(Code.GetDalExtendCode(g), layersPath.Value + "\\" + g.Key + "Dal.Extend.cs", path + "\\" + InfoModel.Dal.Split('/')[0] + ".csproj");
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
                            break;
                        #endregion

                        #region 生成IDal
                        case "IDal":
                            try
                            {
                                path = directoryInfos.FirstOrDefault(x => x.FullName.Contains(InfoModel.IDal.Split('/')[0]))?.FullName ?? "";
                                if (!string.IsNullOrEmpty(path))
                                {
                                    Helper.WriteToFile(Code.GetIDalCode(g), layersPath.Value + "\\" + "I" + g.Key + "Dal.cs", path + "\\" + InfoModel.IDal.Split('/')[0] + ".csproj");
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
            Console.WriteLine("正在检查程序集之间的引用关系...."); // todo
            Console.ReadLine();
            Console.Clear();
            goto START;
        }
    }
}
