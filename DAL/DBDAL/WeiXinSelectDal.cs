using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class WeiXinSelectDal
    {
        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinSelect WHERE {where};") > 0;

        public void Add(WeiXinSelect model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboWeiXinSelect(");
            strSql.Append("Subject,OptionA,OptionB,OptionC,OptionD,Answer");
            strSql.Append(") VALUES (");
            strSql.Append("@Subject,@OptionA,@OptionB,@OptionC,@OptionD,@Answer);");
            DbClient.Excute(strSql.ToString(), model);
        }

        public bool Update(WeiXinSelect model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinSelect SET ");
            strSql.Append("Subject = @Subject,OptionA = @OptionA,OptionB = @OptionB,OptionC = @OptionC,OptionD = @OptionD,Answer = @Answer");
            strSql.Append(" WHERE ID = @ID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboWeiXinSelect SET ");
            strSql.Append("Subject = @Subject,OptionA = @OptionA,OptionB = @OptionB,OptionC = @OptionC,OptionD = @OptionD,Answer = @Answer");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.WeiXinSelect WHERE 1 = 1 {where}");

        public List<WeiXinSelect> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.WeiXinSelect WHERE {where}";
            return DbClient.Query<WeiXinSelect>(strSql).ToList();
        }

        public List<WeiXinSelect> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.WeiXinSelect ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.WeiXinSelect WHERE {where};");
            return DbClient.Query<WeiXinSelect>(strSql.ToString()).ToList();
        }

    }
}
