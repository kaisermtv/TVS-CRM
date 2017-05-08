using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class Contact
{
    #region method Contact
    public Contact()
	{
	}
    #endregion

    #region method setData
    public int setData(int Id, string Name,string Phone, string CompanyName, string Possition,string Department,string Email,int UserCreate, string UserCreateName, int UserManagerment, string UserManagermentName, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblContact WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblContact(Name,Phone,CompanyName,Possition,Department,Email,UserCreate,UserCreateName,UserManagerment,UserManagermentName) VALUES(@Name,@Phone,@CompanyName,@Possition,@Department,@Email,@UserCreate,@UserCreateName,@UserManagerment,@UserManagermentName) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblContact SET Name = @Name, Phone = @Phone, CompanyName = @CompanyName, Possition = @Possition, Department = @Department, Email = @Email, UserCreate = @UserCreate, UserCreateName = @UserCreateName, UserManagerment = @UserManagerment, UserManagermentName = @UserManagermentName, State = @State WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = CompanyName;
            Cmd.Parameters.Add("Possition", SqlDbType.NVarChar).Value = Possition;
            Cmd.Parameters.Add("Department", SqlDbType.NVarChar).Value = Department;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("UserCreate", SqlDbType.Int).Value = UserCreate;
            Cmd.Parameters.Add("UserCreateName", SqlDbType.NVarChar).Value = UserCreateName;
            Cmd.Parameters.Add("UserManagerment", SqlDbType.Int).Value = UserManagerment;
            Cmd.Parameters.Add("UserManagermentName", SqlDbType.NVarChar).Value = UserManagermentName;
            Cmd.Parameters.Add("State", SqlDbType.Bit).Value = State;
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

    #region method getData
    public DataTable getData(string searchKey)
    {
        string sqlQuery = "";
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND (UPPER(RTRIM(LTRIM(Name))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR UPPER(RTRIM(LTRIM(Phone))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR UPPER(RTRIM(LTRIM(Email))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%')";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT 0 AS TT, Id, Name, Phone, Email, REPLACE(REPLACE(CAST(State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName FROM tblContact WHERE 1 = 1 " + sqlQuery;
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
            Cmd.CommandText = "SELECT TOP 1 Id FROM tblContact ORDER BY Id DESC"; ;
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
            Cmd.CommandText = "SELECT * FROM tblContact WHERE Id = @Id";
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

    #region method checkForUserCreateContact
    public bool checkForUserCreateContact(int Id, string UserName)
    {
        bool tmpValue = false;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 tblContact.Id FROM tblContact,tblAccount WHERE tblContact.UserCreate = tblAccount.Id AND tblContact.Id = @Id AND tblAccount.UserName = @UserName";
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

    #region method delData
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblContact WHERE Id = @Id ";
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
}