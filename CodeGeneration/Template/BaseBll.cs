using IDAL;
using Model;
using System.Data;
using System.Collections.Generic;

namespace Template
{
    public class BaseBll<TModel, TEnum, TKeyType> where TModel : BaseModel
    {
        private readonly IBaseDal<TModel, TEnum, TKeyType> _dal;

        public BaseBll(IBaseDal<TModel, TEnum, TKeyType> dal)
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
        /// <param name="conn">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public TKeyType Add(TModel model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            return _dal.Add(model, conn, transaction);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="conn">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool Update(TModel model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            return _dal.Update(model, conn, transaction);
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="updates">需要更新字段的键值对</param>
        /// <param name="where">条件语句</param>
        /// <param name="conn">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool Update(Dictionary<TEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            return _dal.Update(updates, where, conn, transaction);
        }

        /// <summary>
        /// 删除一条数据 (表中没有主键时此方法不适用)
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="conn">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool Delete(TKeyType primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            return _dal.Delete(primaryKey, conn, transaction);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <param name="conn">连接池(当您传入此参数,那么请记得释放连接池)</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            return _dal.DeleteByWhere(where, conn, transaction);
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
        public List<TModel> GetModelPage(TEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            return _dal.GetModelPage(order, where, pageIndex, pageSize, out total);
        }
    }
}
