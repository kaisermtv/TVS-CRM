using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Target
{
    #region method Target
    public Target()
    {
    } 
    #endregion

    #region method getData
    public DataTable getData(string searchKey, string UserName)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND UPPER(RTRIM(LTRIM(Name))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%'";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            Cmd.CommandText = "SELECT 0 AS TT, *, (CAST(ISNULL((SELECT COUNT(*) FROM tblTargetCustomer WHERE TargetId = tblTarget.Id),0) AS nvarchar)) AS CountItem FROM tblTarget WHERE (UserCreate = (SELECT TOP 1 Id FROM tblAccount WHERE UserName = @UserName) OR UserDeployment = (SELECT TOP 1 Id FROM tblAccount WHERE UserName = @UserName)) " + sqlQuery + " ORDER BY DayCreate DESC";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["TT"] = (i + 1);
            }
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method setData
    public int setData(int Id, string Name, string Note, int UserCreate, string UserCreateName, int UserDeployment, string UserDeploymentName, DateTime DayBegin, DateTime DayEnd)
    {
        int tmpValue = 0;
        //try
        //{
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblTarget WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblTarget(Name,Note,UserCreate,UserCreateName,UserDeployment,UserDeploymentName,DayBegin,DayEnd) VALUES(@Name,@Note,@UserCreate,@UserCreateName,@UserDeployment,@UserDeploymentName,@DayBegin,@DayEnd) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblTarget SET Name = @Name,Note = @Note,UserCreate = @UserCreate,UserCreateName = @UserCreateName,UserDeployment = @UserDeployment, UserDeploymentName = @UserDeploymentName, DayBegin = @DayBegin,DayEnd = @DayEnd WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DayBegin", SqlDbType.DateTime).Value = DayBegin;
            Cmd.Parameters.Add("DayEnd", SqlDbType.DateTime).Value = DayEnd;
            Cmd.Parameters.Add("UserCreate", SqlDbType.Int).Value = UserCreate;
            Cmd.Parameters.Add("UserCreateName", SqlDbType.NVarChar).Value = UserCreateName;
            Cmd.Parameters.Add("UserDeployment", SqlDbType.Int).Value = UserDeployment;
            Cmd.Parameters.Add("UserDeploymentName", SqlDbType.NVarChar).Value = UserDeploymentName;
            Cmd.Parameters.Add("Note", SqlDbType.NVarChar).Value = Note;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        //}
        //catch
        //{
        //    tmpValue = 0;
        //}
        return tmpValue;
    }
    #endregion

    #region method getDataId
    public int getDataId()
    {
        int tmpValue = 0;
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 Id FROM tblTarget ORDER BY Id DESC"; ;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = int.Parse(Rd["Id"].ToString());
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method checkForUserCreateTarget
    public bool checkForUserCreateTarget(int Id, string UserName)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 tblTarget.Id FROM tblTarget,tblAccount WHERE tblTarget.UserCreate = tblAccount.Id AND tblTarget.Id = @Id AND tblAccount.UserName = @UserName";
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = UserName;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while (Rd.Read())
            {
                tmpValue = true;
            }
            Rd.Close();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
        return tmpValue;
    }
    #endregion

    #region method getDataById
    public DataTable getDataById(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.CommandText = "SELECT * FROM tblTarget WHERE Id = @Id";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method delData
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblTarget WHERE Id = @Id ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
        }
        catch
        {

        }
    }
    #endregion

    #region TargetCustomer

    #region method setData
    public int setData(int TargetId, int CustomerId)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblTargetCustomer WHERE TargetId = @TargetId AND CustomerId = @CustomerId) ";
            sqlQuery += "BEGIN INSERT INTO tblTargetCustomer(TargetId,CustomerId) VALUES(@TargetId,@CustomerId) END ";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("TargetId", SqlDbType.Int).Value = TargetId;
            Cmd.Parameters.Add("CustomerId", SqlDbType.Int).Value = CustomerId;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpValue = 1;
        }
        catch
        {
            tmpValue = 0;
        }
        return tmpValue;
    }
    #endregion

    #region method getDataTargetCustomer
    public DataTable getDataTargetCustomer(string TargetId)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("TargetId", SqlDbType.NVarChar).Value = TargetId;
            Cmd.CommandText = "SELECT tblCustomer.Id, tblCustomer.TypeId, tblCustomer.Name, tblCustomer.Phone, tblCustomer.ContactName, tblCustomer.UserManagermentName, tblCustomer.TaxCode, (SELECT [Name] FROM tblProvincer WHERE Id = tblCustomer.ProvincerId) AS ProvincerName, tblTargetCustomer.DayCreate FROM tblTargetCustomer,tblCustomer WHERE tblTargetCustomer.CustomerId = tblCustomer.Id AND tblTargetCustomer.TargetId = @TargetId";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #endregion
}