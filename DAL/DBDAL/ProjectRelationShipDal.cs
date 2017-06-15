using System.Collections.Generic;
using System.Linq;
using Model;
using System.Text;

namespace DAL
{
    public partial class ProjectRelationShipDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.ProjectRelationShip WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectRelationShip WHERE {where};") > 0;

        public int Add(ProjectRelationShip model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO DJES.dboProjectRelationShip(");
            strSql.Append("ProjectRelationShipID,ProjectID,jnbz,txxs,wmbwcl,wmbwhd,pwmbwcl,pwmbwhd,wqtqtcl,wqtbwfs,wqtdxnbwcl,wqtbbwcl,wqtdxnbwhd,wqtbbwhd,lqbwbwcl,lqbwbwhd,wcckcl,wcblcl,wczkchd,wczycs,tcckcl,tcblcl,tczkchd,tczycs,hm,ffbytmxb,jkbwcl,jkbwhd,tcdbbwcl,tcdbbwhd,nfbwcl,nfbwhd,dmbwcl,dmbwhd,dxswqbwcl,dxswqbwhd,ztxjtf,mqtf,fhq,jnsfdb,kzszyly,sfazfxjlzz");
            strSql.Append(") VALUES (");
            strSql.Append("@ProjectRelationShipID,@ProjectID,@jnbz,@txxs,@wmbwcl,@wmbwhd,@pwmbwcl,@pwmbwhd,@wqtqtcl,@wqtbwfs,@wqtdxnbwcl,@wqtbbwcl,@wqtdxnbwhd,@wqtbbwhd,@lqbwbwcl,@lqbwbwhd,@wcckcl,@wcblcl,@wczkchd,@wczycs,@tcckcl,@tcblcl,@tczkchd,@tczycs,@hm,@ffbytmxb,@jkbwcl,@jkbwhd,@tcdbbwcl,@tcdbbwhd,@nfbwcl,@nfbwhd,@dmbwcl,@dmbwhd,@dxswqbwcl,@dxswqbwhd,@ztxjtf,@mqtf,@fhq,@jnsfdb,@kzszyly,@sfazfxjlzz);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(ProjectRelationShip model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectRelationShip SET ");
            strSql.Append("ProjectID = @ProjectID,jnbz = @jnbz,txxs = @txxs,wmbwcl = @wmbwcl,wmbwhd = @wmbwhd,pwmbwcl = @pwmbwcl,pwmbwhd = @pwmbwhd,wqtqtcl = @wqtqtcl,wqtbwfs = @wqtbwfs,wqtdxnbwcl = @wqtdxnbwcl,wqtbbwcl = @wqtbbwcl,wqtdxnbwhd = @wqtdxnbwhd,wqtbbwhd = @wqtbbwhd,lqbwbwcl = @lqbwbwcl,lqbwbwhd = @lqbwbwhd,wcckcl = @wcckcl,wcblcl = @wcblcl,wczkchd = @wczkchd,wczycs = @wczycs,tcckcl = @tcckcl,tcblcl = @tcblcl,tczkchd = @tczkchd,tczycs = @tczycs,hm = @hm,ffbytmxb = @ffbytmxb,jkbwcl = @jkbwcl,jkbwhd = @jkbwhd,tcdbbwcl = @tcdbbwcl,tcdbbwhd = @tcdbbwhd,nfbwcl = @nfbwcl,nfbwhd = @nfbwhd,dmbwcl = @dmbwcl,dmbwhd = @dmbwhd,dxswqbwcl = @dxswqbwcl,dxswqbwhd = @dxswqbwhd,ztxjtf = @ztxjtf,mqtf = @mqtf,fhq = @fhq,jnsfdb = @jnsfdb,kzszyly = @kzszyly,sfazfxjlzz = @sfazfxjlzz");
            strSql.Append(" WHERE ProjectRelationShipID = @ProjectRelationShipID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboProjectRelationShip SET ");
            strSql.Append("ProjectID = @ProjectID,jnbz = @jnbz,txxs = @txxs,wmbwcl = @wmbwcl,wmbwhd = @wmbwhd,pwmbwcl = @pwmbwcl,pwmbwhd = @pwmbwhd,wqtqtcl = @wqtqtcl,wqtbwfs = @wqtbwfs,wqtdxnbwcl = @wqtdxnbwcl,wqtbbwcl = @wqtbbwcl,wqtdxnbwhd = @wqtdxnbwhd,wqtbbwhd = @wqtbbwhd,lqbwbwcl = @lqbwbwcl,lqbwbwhd = @lqbwbwhd,wcckcl = @wcckcl,wcblcl = @wcblcl,wczkchd = @wczkchd,wczycs = @wczycs,tcckcl = @tcckcl,tcblcl = @tcblcl,tczkchd = @tczkchd,tczycs = @tczycs,hm = @hm,ffbytmxb = @ffbytmxb,jkbwcl = @jkbwcl,jkbwhd = @jkbwhd,tcdbbwcl = @tcdbbwcl,tcdbbwhd = @tcdbbwhd,nfbwcl = @nfbwcl,nfbwhd = @nfbwhd,dmbwcl = @dmbwcl,dmbwhd = @dmbwhd,dxswqbwcl = @dxswqbwcl,dxswqbwhd = @dxswqbwhd,ztxjtf = @ztxjtf,mqtf = @mqtf,fhq = @fhq,jnsfdb = @jnsfdb,kzszyly = @kzszyly,sfazfxjlzz = @sfazfxjlzz");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.ProjectRelationShip WHERE ProjectRelationShipID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.ProjectRelationShip WHERE 1 = 1 {where}");

        public ProjectRelationShip GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.ProjectRelationShip WHERE ProjectRelationShipID = @key";
            return DbClient.Query<ProjectRelationShip>(strSql, new { key }).FirstOrDefault();
        }

        public List<ProjectRelationShip> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.ProjectRelationShip WHERE {where}";
            return DbClient.Query<ProjectRelationShip>(strSql).ToList();
        }

        public List<ProjectRelationShip> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.ProjectRelationShip ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.ProjectRelationShip WHERE {where};");
            return DbClient.Query<ProjectRelationShip>(strSql.ToString()).ToList();
        }

    }
}
