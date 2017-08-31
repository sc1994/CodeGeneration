using Model;
using System.Collections.Generic;

namespace Template
{
    public interface IBaseBll<TModel, TEmun, TKeyType> where TModel : BaseModel
    {

        /// <summary>
        /// 数据是否存在 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        bool Exists(TKeyType primaryKey);


        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        bool ExistsByWhere(string where);

        /// <summary>
        /// 向表中添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TKeyType Add(TModel model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(TModel model);

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="updates">需要更新字段的键值对</param>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        bool Update(Dictionary<TEmun, object> updates, string where);

        /// <summary>
        /// 删除一条数据 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        bool Delete(TKeyType primaryKey);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        int DeleteByWhere(string where);

        /// <summary>
        /// 获取对象 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        TModel GetModel(TKeyType primaryKey);

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        List<TModel> GetModelList(string where);

        /// <summary>
        /// 获取分页对象列表
        /// </summary>
        /// <param name="order">分页排序的依据</param>
        /// <param name="where">条件语句</param>
        /// <param name="pageIndex">开始页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="total">out 总数</param>
        /// <returns></returns>
        List<TModel> GetModelPage(TEmun order, string where, int pageIndex, int pageSize, out int total);
    }
}
