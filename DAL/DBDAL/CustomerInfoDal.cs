using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class CustomerInfoDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM DJES.dbo.CustomerInfo WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool Exists(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CustomerInfo WHERE {where};") > 0;

        public int Add(CustomerInfo model)
        {
             var strSql = new StringBuilder();
             strSql.Append("INSERT INTO DJES.dboCustomerInfo(");
             strSql.Append("CustomerID,CustomerName,DisplayCustomerName,CustomerType,Password,Bank,Account,Website,Jgzzjgdm,Jgrdzsh,Cspzjg,Pzwh,Pzrq,Jglx,Logo,ValidDay,Status,MinChargeAmount,PreferentialQuota,PreferentialDiscount,MaxChargeAmount,WeiXinPicture,Remind,AppId,AppSecret,AppToken,AppEncodingAesKey,ConstructHeading,SeismicHeading,Message_POST_URL,Message_ACCOUNT,Message_AUTHKEY,Message_CGID,WX_CorpId,WX_CorpSecret,WX_CorpToken,WX_EncodingAESKey,WX_Agentid,SignatureServer");
             strSql.Append(") VALUES (");
             strSql.Append("@CustomerID,@CustomerName,@DisplayCustomerName,@CustomerType,@Password,@Bank,@Account,@Website,@Jgzzjgdm,@Jgrdzsh,@Cspzjg,@Pzwh,@Pzrq,@Jglx,@Logo,@ValidDay,@Status,@MinChargeAmount,@PreferentialQuota,@PreferentialDiscount,@MaxChargeAmount,@WeiXinPicture,@Remind,@AppId,@AppSecret,@AppToken,@AppEncodingAesKey,@ConstructHeading,@SeismicHeading,@Message_POST_URL,@Message_ACCOUNT,@Message_AUTHKEY,@Message_CGID,@WX_CorpId,@WX_CorpSecret,@WX_CorpToken,@WX_EncodingAESKey,@WX_Agentid,@SignatureServer);");
             strSql.Append("SELECT @@IDENTITY");
             return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CustomerInfo model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCustomerInfo SET ");
            strSql.Append("CustomerName = @CustomerName,DisplayCustomerName = @DisplayCustomerName,CustomerType = @CustomerType,Password = @Password,Bank = @Bank,Account = @Account,Website = @Website,Jgzzjgdm = @Jgzzjgdm,Jgrdzsh = @Jgrdzsh,Cspzjg = @Cspzjg,Pzwh = @Pzwh,Pzrq = @Pzrq,Jglx = @Jglx,Logo = @Logo,ValidDay = @ValidDay,Status = @Status,MinChargeAmount = @MinChargeAmount,PreferentialQuota = @PreferentialQuota,PreferentialDiscount = @PreferentialDiscount,MaxChargeAmount = @MaxChargeAmount,WeiXinPicture = @WeiXinPicture,Remind = @Remind,AppId = @AppId,AppSecret = @AppSecret,AppToken = @AppToken,AppEncodingAesKey = @AppEncodingAesKey,ConstructHeading = @ConstructHeading,SeismicHeading = @SeismicHeading,Message_POST_URL = @Message_POST_URL,Message_ACCOUNT = @Message_ACCOUNT,Message_AUTHKEY = @Message_AUTHKEY,Message_CGID = @Message_CGID,WX_CorpId = @WX_CorpId,WX_CorpSecret = @WX_CorpSecret,WX_CorpToken = @WX_CorpToken,WX_EncodingAESKey = @WX_EncodingAESKey,WX_Agentid = @WX_Agentid,SignatureServer = @SignatureServer");
            strSql.Append(" WHERE CustomerID = @CustomerID");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE DJES.dboCustomerInfo SET ");
            strSql.Append("CustomerName = @CustomerName,DisplayCustomerName = @DisplayCustomerName,CustomerType = @CustomerType,Password = @Password,Bank = @Bank,Account = @Account,Website = @Website,Jgzzjgdm = @Jgzzjgdm,Jgrdzsh = @Jgrdzsh,Cspzjg = @Cspzjg,Pzwh = @Pzwh,Pzrq = @Pzrq,Jglx = @Jglx,Logo = @Logo,ValidDay = @ValidDay,Status = @Status,MinChargeAmount = @MinChargeAmount,PreferentialQuota = @PreferentialQuota,PreferentialDiscount = @PreferentialDiscount,MaxChargeAmount = @MaxChargeAmount,WeiXinPicture = @WeiXinPicture,Remind = @Remind,AppId = @AppId,AppSecret = @AppSecret,AppToken = @AppToken,AppEncodingAesKey = @AppEncodingAesKey,ConstructHeading = @ConstructHeading,SeismicHeading = @SeismicHeading,Message_POST_URL = @Message_POST_URL,Message_ACCOUNT = @Message_ACCOUNT,Message_AUTHKEY = @Message_AUTHKEY,Message_CGID = @Message_CGID,WX_CorpId = @WX_CorpId,WX_CorpSecret = @WX_CorpSecret,WX_CorpToken = @WX_CorpToken,WX_EncodingAESKey = @WX_EncodingAESKey,WX_Agentid = @WX_Agentid,SignatureServer = @SignatureServer");
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString()) > 0;
        }

        public bool Delete(int key)
        {
            var strSql = "DELETE FROM DJES.dbo.CustomerInfo WHERE CustomerID = @key";
            return DbClient.Excute(strSql, new { key }) > 0;
        }

        public int Delete(string where)
            => DbClient.Excute($"DELETE FROM DJES.dbo.CustomerInfo WHERE 1 = 1 {where}");

        public CustomerInfo GetModel(int key)
        {
            var strSql = "SELECT * FROM DJES.dbo.CustomerInfo WHERE CustomerID = @key";
            return DbClient.Query<CustomerInfo>(strSql, new { key }).FirstOrDefault();
        }

        public List<CustomerInfo> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM DJES.dbo.CustomerInfo WHERE {where}";
            return DbClient.Query<CustomerInfo>(strSql).ToList();
        }

        public List<CustomerInfo> GetModelPage(string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ( {pageSize} )");
            strSql.Append("ROW_NUMBER() OVER ( ORDER BY ct.TaskID DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  DJES.dbo.CustomerInfo ");
            strSql.Append($" WHERE {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE   ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM DJES.dbo.CustomerInfo WHERE {where};");
            return DbClient.Query<CustomerInfo>(strSql.ToString()).ToList();
        }

    }
}
