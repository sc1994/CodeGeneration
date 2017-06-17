using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ChangeCensorDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ChangeCensor WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ChangeCensor WHERE {where};") > 0;

        public int Add(ChangeCensor model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboChangeCensor(");
            strSql.Append("CustomerID,TaskID,ChangeProject,Profession,ChangeAttachment,MasterCensor,CensorOpinions,ChangeNum,ChangeTime,CensorTime");
            strSql.Append(") VALUES (");
            strSql.Append("@CustomerID,@TaskID,@ChangeProject,@Profession,@ChangeAttachment,@MasterCensor,@CensorOpinions,@ChangeNum,@ChangeTime,@CensorTime);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ChangeCensor model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboChangeCensor SET ");
            strSql.Append("CustomerID = @CustomerID,TaskID = @TaskID,ChangeProject = @ChangeProject,Profession = @Profession,ChangeAttachment = @ChangeAttachment,MasterCensor = @MasterCensor,CensorOpinions = @CensorOpinions,ChangeNum = @ChangeNum,ChangeTime = @ChangeTime,CensorTime = @CensorTime");
            strSql.Append(" WHERE ChangeCensorID = @ChangeCensorID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboChangeCensor SET ");
            strSql.Append("CustomerID = @CustomerID,TaskID = @TaskID,ChangeProject = @ChangeProject,Profession = @Profession,ChangeAttachment = @ChangeAttachment,MasterCensor = @MasterCensor,CensorOpinions = @CensorOpinions,ChangeNum = @ChangeNum,ChangeTime = @ChangeTime,CensorTime = @CensorTime");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ChangeCensor WHERE ChangeCensorID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ChangeCensor WHERE 1 = 1 {where}");

        public ChangeCensor GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ChangeCensor WHERE ChangeCensorID = @key";
            return DbClient.Query<ChangeCensor>(strSql, new { key }).FirstOrDefault();
        }

        public List<ChangeCensor> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ChangeCensor WHERE {where}";
            return DbClient.Query<ChangeCensor>(strSql).ToList();
        }

        public List<ChangeCensor> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ChangeCensor ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ChangeCensor WHERE {where};");
            return DbClient.Query<ChangeCensor>(strSql.ToString()).ToList();
        }

    }
}
