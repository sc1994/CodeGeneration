using IDAL;
using Model;
using System.Collections.Generic;

namespace Template
{
    public class BaseBll<TModel, TEmun, TKeyType> where TModel : BaseModel
    {
        private readonly IBaseDal<TModel, TEmun, TKeyType> _dal;

        public BaseBll(IBaseDal<TModel, TEmun, TKeyType> dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// 数据是否存在 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public bool Exists(TKeyType primaryKey)
        {
            return _dal.Exists(primaryKey);
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        public bool ExistsByWhere(string where)
        {
            return _dal.ExistsByWhere(where);
        }

        /// <summary>
        /// 向表中添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TKeyType Add(TModel model)
        {
            return _dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(TModel model)
        {
            return _dal.Update(model);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="updates">需要更新字段的键值对</param>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        public bool Update(Dictionary<TEmun, object> updates, string where)
        {
            return _dal.Update(updates, where);
        }

        /// <summary>
        /// 删除一条数据 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public bool Delete(TKeyType primaryKey)
        {
            return _dal.Delete(primaryKey);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        public int DeleteByWhere(string where)
        {
            return _dal.DeleteByWhere(where);
        }

        /// <summary>
        /// 获取对象 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public TModel GetModel(TKeyType primaryKey)
        {
            return _dal.GetModel(primaryKey);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <returns></returns>
        public List<TModel> GetModelList(string where)
        {
            return _dal.GetModelList(where);
        }

        /// <summary>
        /// 获取分页对象列表
        /// </summary>
        /// <param name="order">分页排序的依据</param>
        /// <param name="where">条件语句</param>
        /// <param name="pageIndex">开始页数</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="total">out 总数</param>
        /// <returns></returns>
        public List<TModel> GetModelPage(TEmun order, string where, int pageIndex, int pageSize, out int total)
        {
            return _dal.GetModelPage(order, where, pageIndex, pageSize, out total);
        }
    }
}
