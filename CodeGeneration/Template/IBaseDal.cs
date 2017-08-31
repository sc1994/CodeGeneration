using Model;
using System.Collections.Generic;

namespace IDAL
{
    public interface IBaseDal<TModel, TEnum, TKeyType> where TModel : BaseModel
    {
        /// <summary>
        /// 数据是否存在 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Exists(TKeyType primaryKey);

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool ExistsByWhere(string where);

        /// <summary>
        /// 添加对象
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
        /// <param name="updates"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Update(Dictionary<TEnum, object> updates, string where);

        /// <summary>
        /// 删除一条数据 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Delete(TKeyType primaryKey);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int DeleteByWhere(string where);

        /// <summary>
        /// 获取对象 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        TModel GetModel(TKeyType primaryKey);

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TModel> GetModelList(string where);

        /// <summary>
        /// 获取分页对象列表
        /// </summary>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<TModel> GetModelPage(TEnum order, string where, int pageIndex, int pageSize, out int total);
    }
}
