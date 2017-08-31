using Model;
using System.Collections.Generic;

namespace IDAL
{
    public interface IBaseDal<TModel, TEnum, TKeyType> where TModel : BaseModel
    {
        bool Exists(TKeyType primaryKey);

        bool ExistsByWhere(string where);

        TKeyType Add(TModel model);

        bool Update(TModel model);

        bool Update(Dictionary<TEnum, object> updates, string where);

        bool Delete(TKeyType primaryKey);

        int DeleteByWhere(string where);

        TModel GetModel(TKeyType primaryKey);

        List<TModel> GetModelList(string where);

        List<TModel> GetModelPage(TEnum order, string where, int pageIndex, int pageSize, out int total);
    }
}
