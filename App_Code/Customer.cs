using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Web;

public class Customer
{
    #region method Customer
    public Customer()
    {
    } 
    #endregion

    #region method setData
    public int setData(int Id, string Name, string TaxCode, string ContactName, string Phone, int ProvincerId, int DistrictId, int WardId, string Address, string Email, int BusinessId, string BusinessName, int NumDept, int NumLeader, int NumEmp, int UserCreate, string UserCreateName, int UserManagerment, string UserManagermentName, int TypeId, string CodeConnect, int NumViettel, int NumViNaPhone, int NumOther, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblCustomer WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblCustomer(Name,TaxCode,ContactName,Phone,ProvincerId,DistrictId,WardId,Address,Email,BusinessId,BusinessName,NumDept,NumLeader,NumEmp,UserCreate,UserCreateName,UserManagerment,UserManagermentName,DayCreate,TypeId,CodeConnect,NumViettel,NumViNaPhone,NumOther,State) VALUES(@Name,@TaxCode,@ContactName,@Phone,@ProvincerId,@DistrictId,@WardId,@Address,@Email,@BusinessId,@BusinessName,@NumDept,@NumLeader,@NumEmp,@UserCreate,@UserCreateName,@UserManagerment,@UserManagermentName,getdate(),@TypeId,@CodeConnect,@NumViettel,@NumViNaPhone,@NumOther,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblCustomer SET Name = @Name,TaxCode = @TaxCode,ContactName = @ContactName,Phone = @Phone,ProvincerId = @ProvincerId,DistrictId = @DistrictId,WardId = @WardId,Address = @Address,Email = @Email,BusinessId = @BusinessId, BusinessName = @BusinessName, NumDept = @NumDept,NumLeader = @NumLeader,NumEmp = @NumEmp,UserCreate = @UserCreate,UserCreateName = @UserCreateName,UserManagerment = @UserManagerment,UserManagermentName = @UserManagermentName, TypeId = @TypeId, CodeConnect = @CodeConnect, NumViettel = @NumViettel,NumViNaPhone = @NumViNaPhone,NumOther = @NumOther, State = @State WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = TaxCode;
            Cmd.Parameters.Add("ContactName", SqlDbType.NVarChar).Value = ContactName;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
            Cmd.Parameters.Add("WardId", SqlDbType.Int).Value = WardId;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("BusinessId", SqlDbType.Int).Value = BusinessId;
            Cmd.Parameters.Add("BusinessName", SqlDbType.NVarChar).Value = BusinessName;
            Cmd.Parameters.Add("NumDept", SqlDbType.Int).Value = NumDept;
            Cmd.Parameters.Add("NumLeader", SqlDbType.Int).Value = NumLeader;
            Cmd.Parameters.Add("NumEmp", SqlDbType.Int).Value = NumEmp;
            Cmd.Parameters.Add("UserCreate", SqlDbType.Int).Value = UserCreate;
            Cmd.Parameters.Add("UserCreateName", SqlDbType.NVarChar).Value = UserCreateName;
            Cmd.Parameters.Add("UserManagerment", SqlDbType.Int).Value = UserManagerment;
            Cmd.Parameters.Add("UserManagermentName", SqlDbType.NVarChar).Value = UserManagermentName;
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
            Cmd.Parameters.Add("CodeConnect", SqlDbType.NVarChar).Value = CodeConnect;

            Cmd.Parameters.Add("NumViettel", SqlDbType.Int).Value = NumViettel;
            Cmd.Parameters.Add("NumViNaPhone", SqlDbType.Int).Value = NumViNaPhone;
            Cmd.Parameters.Add("NumOther", SqlDbType.Int).Value = NumOther;

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

    #region method setData
    public int setData(int Id, string Name, string TaxCode, string ContactName, string Phone, int ProvincerId, int DistrictId, int WardId, string Address, string AddressBill, string Email, int BusinessId, string BusinessName, int NumDept, int NumLeader, int NumEmp, int UserCreate, string UserCreateName, int UserManagerment, string UserManagermentName, int TypeId, string BusinessLlicense, int NumViettel, int NumViNaPhone, int NumOther, bool State)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblCustomer WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblCustomer(Name,TaxCode,ContactName,Phone,ProvincerId,DistrictId,WardId,Address,AddressBill,Email,BusinessId,BusinessName,NumDept,NumLeader,NumEmp,UserCreate,UserCreateName,UserManagerment,UserManagermentName,DayCreate,TypeId,BusinessLlicense,NumViettel,NumViNaPhone,NumOther,State) VALUES(@Name,@TaxCode,@ContactName,@Phone,@ProvincerId,@DistrictId,@WardId,@Address,@AddressBill,@Email,@BusinessId,@BusinessName,@NumDept,@NumLeader,@NumEmp,@UserCreate,@UserCreateName,@UserManagerment,@UserManagermentName,getdate(),@TypeId,@BusinessLlicense,@NumViettel,@NumViNaPhone,@NumOther,@State) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblCustomer SET Name = @Name,TaxCode = @TaxCode,ContactName = @ContactName,Phone = @Phone,ProvincerId = @ProvincerId,DistrictId = @DistrictId,WardId = @WardId,Address = @Address, AddressBill = @AddressBill, Email = @Email,BusinessId = @BusinessId, BusinessName = @BusinessName, NumDept = @NumDept,NumLeader = @NumLeader,NumEmp = @NumEmp,UserCreate = @UserCreate,UserCreateName = @UserCreateName,UserManagerment = @UserManagerment,UserManagermentName = @UserManagermentName, TypeId = @TypeId, BusinessLlicense = @BusinessLlicense, NumViettel = @NumViettel,NumViNaPhone = @NumViNaPhone,NumOther = @NumOther, State = @State WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("TaxCode", SqlDbType.NVarChar).Value = TaxCode;
            Cmd.Parameters.Add("ContactName", SqlDbType.NVarChar).Value = ContactName;
            Cmd.Parameters.Add("Phone", SqlDbType.NVarChar).Value = Phone;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
            Cmd.Parameters.Add("WardId", SqlDbType.Int).Value = WardId;
            Cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = Address;
            Cmd.Parameters.Add("AddressBill", SqlDbType.NVarChar).Value = AddressBill;
            Cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            Cmd.Parameters.Add("BusinessId", SqlDbType.Int).Value = BusinessId;
            Cmd.Parameters.Add("BusinessName", SqlDbType.NVarChar).Value = BusinessName;
            Cmd.Parameters.Add("NumDept", SqlDbType.Int).Value = NumDept;
            Cmd.Parameters.Add("NumLeader", SqlDbType.Int).Value = NumLeader;
            Cmd.Parameters.Add("NumEmp", SqlDbType.Int).Value = NumEmp;
            Cmd.Parameters.Add("UserCreate", SqlDbType.Int).Value = UserCreate;
            Cmd.Parameters.Add("UserCreateName", SqlDbType.NVarChar).Value = UserCreateName;
            Cmd.Parameters.Add("UserManagerment", SqlDbType.Int).Value = UserManagerment;
            Cmd.Parameters.Add("UserManagermentName", SqlDbType.NVarChar).Value = UserManagermentName;
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
            Cmd.Parameters.Add("BusinessLlicense", SqlDbType.NVarChar).Value = BusinessLlicense;

            Cmd.Parameters.Add("NumViettel", SqlDbType.Int).Value = NumViettel;
            Cmd.Parameters.Add("NumViNaPhone", SqlDbType.Int).Value = NumViNaPhone;
            Cmd.Parameters.Add("NumOther", SqlDbType.Int).Value = NumOther;

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

    #region method setData
    public int setData(int Id, int TypeId)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery += "UPDATE tblCustomer SET TypeId = @TypeId WHERE Id = @Id";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
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

    #region method setData
    public int setData(int Id, int ProvincerId, int DistrictId)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "UPDATE tblCustomer SET ProvincerId = @ProvincerId, DistrictId = @DistrictId  WHERE Id = @Id";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
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
    public DataTable getData(int TypeId, string searchKey, int ProvincerId, int DistrictId, int WardId, int TypeAccountId, string Account, int NumEmp, int BusinessId)
    {
        string sqlQuery = "",  sqlQueryType = "", sqlQueryProvincerId = "", sqlQueryDistrictId = "", sqlQueryWardId = "", sqlQueryLimit = "", sqlQueryNumEmp = "", sqlQueryBusinessId = "";
        if (TypeId > 0)
        {
            sqlQueryType = " AND TypeId = @TypeId ";
        }
        if (searchKey.Trim() != "")
        {
            sqlQuery += " AND (UPPER(RTRIM(LTRIM(tblCustomer.Name))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR UPPER(RTRIM(LTRIM(TaxCode))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR UPPER(RTRIM(LTRIM(ContactName))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' OR UPPER(RTRIM(LTRIM(BusinessLlicense))) LIKE N'%'+UPPER(RTRIM(LTRIM(@SearchKey)))+'%' ) ";
        }
        if (ProvincerId > 0)
        {
            sqlQueryProvincerId = " AND ProvincerId = @ProvincerId ";
        }
        if (DistrictId > 0)
        {
            sqlQueryDistrictId = " AND DistrictId = @DistrictId ";
        }
        if (WardId > 0)
        {
            sqlQueryWardId = " AND WardId = @WardId ";
        }
        if (TypeAccountId == 4)
        {
            sqlQueryLimit = " AND (UserCreate = (SELECT TOP 1 Id FROM tblAccount WHERE UserName = @Account) OR UserManagerment = (SELECT TOP 1 Id FROM tblAccount WHERE UserName = @Account)) ";
        }
        else if (TypeAccountId == 3)
        {
            sqlQueryLimit = " AND (tblCustomer.DistrictId IN (SELECT LevelDistrictId FROM tblAccountLocation WHERE UserName = @Account)) ";
        }
        else if (TypeAccountId == 2)
        {
            sqlQueryLimit = " AND (tblCustomer.ProvincerId IN (SELECT LevelProvincerId FROM tblAccountLocation WHERE UserName = @Account)) ";
        }
        else if (TypeAccountId == 1)
        {
            sqlQueryLimit = "";
        }
        if (BusinessId > 0)
        {
            sqlQueryBusinessId = " AND tblCustomer.BusinessId = @BusinessId";
        }
        if (NumEmp > 0)
        {
            sqlQueryNumEmp = " AND tblCustomer.NumEmp = @NumEmp ";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("SearchKey", SqlDbType.NVarChar).Value = searchKey;
            Cmd.CommandText = "SELECT tblProvincer.Name AS ProvincerName, tblCustomer.ContactName, tblCustomer.BusinessLlicense, tblCustomer.Id, tblCustomer.TypeId, tblCustomer.Name, tblCustomer.Phone, tblCustomer.TaxCode,tblCustomer. Address, REPLACE(REPLACE(CAST(tblCustomer.State AS varchar),'1',N'Kích hoạt'),'0',N'Đóng') AS StateName, (ISNULL(TBTT,0)+ISNULL(TBTS,0)) AS SoThueBao, (SELECT FullName FROM tblAccount WHERE tblAccount.Id = tblCustomer.UserManagerment) AS FullName FROM tblCustomer, tblProvincer WHERE tblCustomer.ProvincerId = tblProvincer.Id " +sqlQueryType + sqlQuery + sqlQueryProvincerId + sqlQueryDistrictId + sqlQueryWardId + sqlQueryLimit + sqlQueryNumEmp +  sqlQueryBusinessId + " ORDER BY DayCreate DESC";
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("DistrictId", SqlDbType.Int).Value = DistrictId;
            Cmd.Parameters.Add("WardId", SqlDbType.Int).Value = WardId;
            Cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = Account;
            Cmd.Parameters.Add("@NumEmp", SqlDbType.Int).Value = NumEmp;
            Cmd.Parameters.Add("@BusinessId", SqlDbType.Int).Value = BusinessId;
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
            Cmd.CommandText = "SELECT TOP 1 Id FROM tblCustomer ORDER BY Id DESC"; ;
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
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
            Cmd.CommandText = "SELECT *, tblDistrict.Name AS DistrictName, tblProvincer.Name AS ProvincerName  FROM tblCustomer LEFT JOIN tblProvincer ON tblCustomer.ProvincerId = tblProvincer.Id LEFT JOIN tblDistrict ON tblDistrict.ProvincerId = tblProvincer.Id WHERE tblCustomer.Id = @Id";
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

    #region method getDataChiTietThueBao
    public DataTable getDataChiTietThueBao(string MA_DNDN, ref int TBTT, ref int TBTS, ref int C2C, ref int C1C, ref int SLMBU)
    {
        DataTable objTableRoot = new DataTable();

        DataTable objTable = new DataTable();

        DataColumn objC0 = new DataColumn("TT", typeof(string));
        DataColumn objC1 = new DataColumn("ISDN", typeof(string));
        DataColumn objC2 = new DataColumn("PROVINCE", typeof(string));
        DataColumn objC3 = new DataColumn("BUS_NO", typeof(string));
        DataColumn objC4 = new DataColumn("STATUS", typeof(string));//Tinh trang chan, cat (1 - Dang hoat dong, 0 - Da cat huy)
        DataColumn objC5 = new DataColumn("ACT_STATUS", typeof(string));//Tinh trang hoat dong - 01: Chặn chiều đi, 02: Chặn 2 chiều, 10: Chặn chiều đi Khách hang Yêu cầu, 11: Chặn chiều đi nợ cước KHYC, 12: Chặn 2 chiều + nợ cước KHYC, 20: Tạm cắt
        DataColumn objC6 = new DataColumn("Name", typeof(string));
        DataColumn objC7 = new DataColumn("SUB_ID", typeof(string));
        DataColumn objC8 = new DataColumn("IS_FONE", typeof(string));
        DataColumn objC9 = new DataColumn("NGAYDK_MB", typeof(string));

        objTable.Columns.Add(objC0);
        objTable.Columns.Add(objC1);
        objTable.Columns.Add(objC2);
        objTable.Columns.Add(objC3);
        objTable.Columns.Add(objC4);
        objTable.Columns.Add(objC5);
        objTable.Columns.Add(objC6);
        objTable.Columns.Add(objC7);
        objTable.Columns.Add(objC8);
        objTable.Columns.Add(objC9);

        try
        {
           
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("COR_ID", SqlDbType.NVarChar).Value = MA_DNDN;
            Cmd.CommandText = "SELECT * FROM CRM..OUT_DATA.TMP_KHDN_CRM_ISDN WHERE MA_DNDN = @COR_ID";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTableRoot = ds.Tables[0];

            if (objTableRoot.Rows.Count > 0)
            {
                int tmpIndex = 0;
                string tmp_STATUS = "", tmp_ACT_STATUS = "", tmp_IS_FONE = "", tmp_NGAYDK_MB = "";
                for (int i = 0; i < objTableRoot.Rows.Count; i++ )
                {
                    tmpIndex = tmpIndex + 1;
                    if (objTableRoot.Rows[i]["STATUS"].ToString() == "1")
                    {
                        tmp_STATUS = "Hoạt động";
                    }
                    else
                    {
                        tmp_STATUS = "Cắt hủy";
                    }

                    if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "01")
                    {
                        tmp_ACT_STATUS = "Chặn chiều đi";
                        C1C++;
                    }
                    else if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "02")
                    {
                        tmp_ACT_STATUS = "Chặn 2 chiều";
                        C2C++;
                    }
                    else if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "10")
                    {
                        tmp_ACT_STATUS = "Chặn chiều đi Khách hàng yêu cầu";
                    }
                    else if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "11")
                    {
                        tmp_ACT_STATUS = "Chặn chiều đi nợ cước KHYC";
                    }
                    else if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "12")
                    {
                        tmp_ACT_STATUS = "Chặn 2 chiều + nợ cước KHYC";
                    }
                    else if (objTableRoot.Rows[i]["ACT_STATUS"].ToString() == "20")
                    {
                        tmp_ACT_STATUS = "Tạm cắt";
                    }

                    if (objTableRoot.Rows[i]["IS_FONE"].ToString() == "1")
                    {
                        TBTS++;
                        tmp_IS_FONE = "Trả sau";
                    }
                    else if (objTableRoot.Rows[i]["IS_FONE"].ToString() == "0")
                    {
                        TBTT++;
                        tmp_IS_FONE = "Trả trước";
                    }

                    if (objTableRoot.Rows[i]["NGAYDK_MB"].ToString() != "")
                    {
                        tmp_NGAYDK_MB = DateTime.Parse(objTableRoot.Rows[i]["NGAYDK_MB"].ToString()).ToString("dd/MM/yyyy");
                        SLMBU++;
                    }

                    objTable.Rows.Add(tmpIndex.ToString(), objTableRoot.Rows[i]["ISDN"].ToString(), objTableRoot.Rows[i]["PROVINCE"].ToString(), objTableRoot.Rows[i]["BUS_NO"].ToString(), tmp_STATUS, tmp_ACT_STATUS,
                        objTableRoot.Rows[i]["Name"].ToString(), objTableRoot.Rows[i]["SUB_ID"].ToString(), tmp_IS_FONE, tmp_NGAYDK_MB);
                }
            }
        }
        catch (Exception Ex)
        {
            HttpContext.Current.Response.Write(Ex.Message);
        }
        return objTable;
    }
    #endregion

    #region method setCustomerInfor
    public string setCustomerInfor()
    {
        string tmpResult = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            //Cmd.CommandText = "UPDATE tblCustomer SET SLMBU = (SELECT TOP 1 SL_MBU FROM CRM..OUT_DATA.TMP_KHDN_GROUP_CRM WHERE COR_ID = tblCustomer.CodeConnect ORDER BY SL_MBU DESC) WHERE (ISNULL(tblCustomer.CodeConnect,'') <> '' AND ISNULL(tblCustomer.TypeId,0) = 3)";
            Cmd.CommandText = "SELECT CodeConnect FROM tblCustomer WHERE (ISNULL(tblCustomer.CodeConnect,'') <> '' AND ISNULL(tblCustomer.TypeId,0) = 3)";
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                this.getDataConect(Rd["CodeConnect"].ToString());
            }
            sqlCon.Close();
            sqlCon.Dispose();
            tmpResult = "Thực hiện thành công";
        }
        catch(Exception Ex)
        {
            tmpResult = Ex.Message;
        }
        return tmpResult;
    }
    #endregion

    #region getDataConect()
    private void getDataConect(string CodeConnect)
    {
        int TBTT = 0, TBTS = 0, C2C = 0, C1C = 0, SLMBU = 0;

        DataTable objTable = this.getDataChiTietThueBao(CodeConnect, ref TBTT, ref TBTS, ref C2C, ref C1C, ref SLMBU);

        this.setCustomerInfor1(CodeConnect, TBTT, TBTS, C2C, C1C, SLMBU);

    }
    #endregion

    #region method setCustomerInfor1
    public string setCustomerInfor1(string CodeConnect, int TBTT, int TBTS, int C2C, int C1C, int SLMBU)
    {
        string tmpResult = "";
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "UPDATE tblCustomer SET TBTT = @TBTT, TBTS = @TBTS, C2C = @C2C, C1C = @C1C, SLMBU = @SLMBU WHERE CodeConnect = @CodeConnect";
            Cmd.Parameters.Add("TBTT",SqlDbType.Float).Value = TBTT;
            Cmd.Parameters.Add("TBTS", SqlDbType.Float).Value = TBTS;
            Cmd.Parameters.Add("C2C", SqlDbType.Float).Value = C2C;
            Cmd.Parameters.Add("C1C", SqlDbType.Float).Value = C1C;
            Cmd.Parameters.Add("SLMBU", SqlDbType.Int).Value = SLMBU;
            Cmd.Parameters.Add("CodeConnect", SqlDbType.NVarChar).Value = CodeConnect;
            Cmd.ExecuteNonQuery();
            sqlCon.Close();
            sqlCon.Dispose();
            tmpResult = "Thực hiện thành công";
        }
        catch (Exception Ex)
        {
            tmpResult = Ex.Message;
        }
        return tmpResult;
    }
    #endregion

    #region method delData
    public void delData(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblCustomer WHERE Id = @Id ";
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

    #region CustomerTask

    #region method getDataTask
    public DataTable getDataTask(int CustomerId, string searchKey)
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
            Cmd.CommandText = "SELECT 0 AS TT, *, REPLACE(REPLACE(REPLACE(CAST(State AS varchar),'1',N'Chưa bắt đầu'),'2',N'Đang triển khai'),'3',N'Đã hoàn thành') AS StateName FROM tblCustomerTask WHERE CustomerId = @CustomerId " + sqlQuery;
            Cmd.Parameters.Add("CustomerId", SqlDbType.Int).Value = CustomerId;
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

    #region method setDataTask
    public int setDataTask(int Id, string Name, DateTime DayBegin, DateTime DayEnd, int Priority, int State, int CustomerId, int ContactId, string ContactName, string ContactPhone, int ManagerId, string ManagerName, string Note)
    {
        int tmpValue = 0;
        try
        {
            string sqlQuery = "";
            sqlQuery = "IF NOT EXISTS (SELECT * FROM tblCustomerTask WHERE Id = @Id) ";
            sqlQuery += "BEGIN INSERT INTO tblCustomerTask(Name,DayBegin,DayEnd,Priority,State,CustomerId,ContactId,ContactName,ContactPhone,ManagerId,ManagerName,Note) VALUES(@Name,@DayBegin,@DayEnd,@Priority,@State,@CustomerId,@ContactId,@ContactName,@ContactPhone,@ManagerId,@ManagerName,@Note) END ";
            sqlQuery += "ELSE BEGIN UPDATE tblCustomerTask SET Name = @Name,DayBegin = @DayBegin,DayEnd = @DayEnd,Priority = @Priority,State = @State,CustomerId = @CustomerId,ContactId = @ContactId, ContactName = @ContactName,ContactPhone = @ContactPhone, ManagerId = @ManagerId, ManagerName = @ManagerName, Note = @Note WHERE Id = @Id END";
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = Name;
            Cmd.Parameters.Add("DayBegin", SqlDbType.DateTime).Value = DayBegin;
            Cmd.Parameters.Add("DayEnd", SqlDbType.DateTime).Value = DayEnd;
            Cmd.Parameters.Add("Priority", SqlDbType.Int).Value = Priority;
            Cmd.Parameters.Add("State", SqlDbType.Int).Value = State;
            Cmd.Parameters.Add("CustomerId", SqlDbType.Int).Value = CustomerId;
            Cmd.Parameters.Add("ContactId", SqlDbType.Int).Value = ContactId;
            Cmd.Parameters.Add("ContactName", SqlDbType.NVarChar).Value = ContactName;
            Cmd.Parameters.Add("ContactPhone", SqlDbType.NVarChar).Value = ContactPhone;
            Cmd.Parameters.Add("ManagerId", SqlDbType.Int).Value = ManagerId;
            Cmd.Parameters.Add("ManagerName", SqlDbType.NVarChar).Value = ManagerName;
            Cmd.Parameters.Add("Note", SqlDbType.NVarChar).Value = Note;
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

    #region method getDataIdTask
    public int getDataIdTask()
    {
        int tmpValue = 0;
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT TOP 1 Id FROM tblCustomerTask ORDER BY Id DESC"; ;
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

    #region method getDataByIdTask
    public DataTable getDataByIdTask(int Id)
    {
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            Cmd.CommandText = "SELECT * FROM tblCustomerTask WHERE Id = @Id";
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

    #region method delDataTask
    public void delDataTask(int Id)
    {
        try
        {
            string sqlQuery = "";
            sqlQuery = "DELETE tblCustomerTask WHERE Id = @Id ";
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

    #region Bao cao

    #region method getRepDataTask
    public DataTable getRepDataTask(DateTime objDate1, DateTime objDate2, int ProvincerId, int AccountId, int TypeId)
    {
        string sqlQueryProvincerId = "", sqlQueryAccountId = "";
        if (ProvincerId > 0)
        {
            sqlQueryProvincerId = " AND tblCustomer.ProvincerId = @ProvincerId";
        }
        if (AccountId > 0)
        {
            sqlQueryAccountId = " AND tblCustomerTask.CustomerId = @AccountId";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT tblCustomer.Name, tblCustomer.Phone, tblCustomer.ContactName, tblCustomer.TaxCode, tblCustomerTask.DayBegin, tblCustomerTask.Name AS Title, tblCustomerTask.Note FROM tblCustomer,tblCustomerTask WHERE tblCustomer.Id  = tblCustomerTask.CustomerId AND DayBegin BETWEEN @objDate1 AND @objDate2 " + sqlQueryProvincerId + sqlQueryAccountId + " AND tblCustomer.TypeId = @TypeId ORDER BY DayBegin DESC";
            Cmd.Parameters.Add("objDate1", SqlDbType.DateTime).Value = new DateTime(objDate1.Year, objDate1.Month, objDate1.Day, 0, 0, 0);
            Cmd.Parameters.Add("objDate2", SqlDbType.DateTime).Value = new DateTime(objDate2.Year, objDate2.Month, objDate2.Day, 23, 59, 59);
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            Cmd.Parameters.Add("AccountId", SqlDbType.Int).Value = AccountId;
            Cmd.Parameters.Add("TypeId", SqlDbType.Int).Value = TypeId;
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

    #region method getRepDataTaskGeneral
    public DataTable getRepDataTaskGeneral(DateTime objDate1, DateTime objDate2, int ProvincerId)
    {
        string sqlQueryProvincerId = "";
        if (ProvincerId > 0)
        {
            sqlQueryProvincerId = " AND tblCustomer.ProvincerId = @ProvincerId";
        }
        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT 0 AS Total, FullName, (SELECT COUNT(*) FROM tblCustomerTask,tblCustomer WHERE tblCustomerTask.CustomerId = tblCustomer.Id AND ContactId = tblAccount.Id AND tblCustomer.TypeId = 2 AND DayBegin BETWEEN @objDate1 AND @objDate2 " + sqlQueryProvincerId + ") AS Total1, (SELECT COUNT(*) FROM tblCustomerTask,tblCustomer WHERE tblCustomerTask.CustomerId = tblCustomer.Id AND ContactId = tblAccount.Id AND tblCustomer.TypeId = 3 AND DayBegin BETWEEN @objDate1 AND @objDate2 " + sqlQueryProvincerId + ") AS Total2 FROM dbo.tblAccount WHERE Id IN (SELECT DISTINCT ContactId FROM tblCustomerTask)";
            Cmd.Parameters.Add("objDate1", SqlDbType.DateTime).Value = new DateTime(objDate1.Year, objDate1.Month, objDate1.Day, 0, 0, 0);
            Cmd.Parameters.Add("objDate2", SqlDbType.DateTime).Value = new DateTime(objDate2.Year, objDate2.Month, objDate2.Day, 23, 59, 59);
            Cmd.Parameters.Add("ProvincerId", SqlDbType.Int).Value = ProvincerId;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Close();
            sqlCon.Dispose();
            objTable = ds.Tables[0];
            for (int i = 0; i < objTable.Rows.Count; i++)
            {
                objTable.Rows[i]["Total"] = int.Parse(objTable.Rows[i]["Total1"].ToString()) + int.Parse(objTable.Rows[i]["Total2"].ToString());
            }
        }
        catch
        {

        }
        return objTable;
    }
    #endregion

    #region method getRepChiTietThueBao
    public DataTable getRepChiTietThueBao()
    {
        string sqlQuery = "";
        sqlQuery += "SELECT TOP 100 A.Id AS 'MAKHACHHANG', A.[Name] AS 'TENKHACHHANG', A.AddressBill AS 'DIACHITHANHTOAN', A.TaxCode AS GPKD, A.TaxCode AS MST, B.[Name] as 'TINHTHANHPHO', C.[Name] AS 'QUANHUYEN', D.[Name] AS 'PHUONGXA', 0 AS CPS FROM dbo.tblCustomer A ";
        sqlQuery += "LEFT JOIN tblProvincer B ON A.ProvincerId = B.Id LEFT JOIN tblDistrict C ON A.DistrictId = C.Id LEFT JOIN tblWard D ON A.WardId = D.Id WHERE A.TypeId = 3";

        DataTable objTable = new DataTable();
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = sqlQuery;
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

    #endregion

    #region Connect Data Oracle

    #region method OracleConnString
    public string OracleConnString(string host, string port, string servicename, string user, string pass)
    {
        return String.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
          "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
          host,
          port,
          servicename,
          user,
          pass);
    } 
    #endregion

    public string TestConnetOracle()
    {
        string tmpResult = "";
        string connectionstring = OracleConnString("10.3.3.227", "1521", "vms61414", "out_data", "123456");
        string sql = "select * from some_table";
        try
        {
            using (OracleConnection conn = new OracleConnection(connectionstring)) // connect to oracle
            {
                conn.Open(); // open the oracle connection
                tmpResult = "Kết nối thành công (Oracle)";
                //using (OracleCommand comm = new OracleCommand(sql, conn)) // create the oracle sql command
                //{
                //  using (OracleDataReader rdr = comm.ExecuteReader()) // execute the oracle sql and start reading it
                //  {
                //    while (rdr.Read()) // loop through each row from oracle
                //    {
                //      Console.WriteLine( rdr[0] );             // You can do this
                //      Console.WriteLine( rdr.GetString(0); );  // or this
                //      Console.WriteLine( rdr["column_name"] ); // or this
                //    }
                //    rdr.Close(); // close the oracle reader
                //  }
                //}
                conn.Close(); // close the oracle connection
            }
        }
        catch (Exception Ex)
        {
            tmpResult = Ex.Message;
        }
        return tmpResult;
    }

    #region method getData
    public DataTable getData(string MA_DNDN)
    {
        DataTable objTable = new DataTable();

        DataColumn objC0 = new DataColumn("TT", typeof(string));
        DataColumn objC1 = new DataColumn("ISDN",typeof(string));
        DataColumn objC2 = new DataColumn("PROVINCE",typeof(string));
        DataColumn objC3 = new DataColumn("BUS_NO",typeof(string));
        DataColumn objC4 = new DataColumn("STATUS", typeof(string));//Tinh trang chan, cat (1 - Dang hoat dong, 0 - Da cat huy)
        DataColumn objC5 = new DataColumn("ACT_STATUS", typeof(string));//Tinh trang hoat dong - 01: Chặn chiều đi, 02: Chặn 2 chiều, 10: Chặn chiều đi Khách hang Yêu cầu, 11: Chặn chiều đi nợ cước KHYC, 12: Chặn 2 chiều + nợ cước KHYC, 20: Tạm cắt

        objTable.Columns.Add(objC0);
        objTable.Columns.Add(objC1);
        objTable.Columns.Add(objC2);
        objTable.Columns.Add(objC3);
        objTable.Columns.Add(objC4);
        objTable.Columns.Add(objC5);

        //NAME, ISDN, SUB_ID, PROVINCE, DISTRICT, STA_DATETIME, ACT_STATUS, STATUS, MA_DNDN, BUS_NO, TAX_CODE, IS_FONE, NGAYDK_MB

        try
        {
            int tmpIndex = 0;
            string connectionstring = OracleConnString("10.3.3.227", "1521", "vms61414", "out_data", "123456");
            string SQLQUERY = "SELECT * FROM TMP_KHDN_CRM WHERE MA_DNDN = '" + MA_DNDN+"'";
            try
            {
                using (OracleConnection ORACLEConn = new OracleConnection(connectionstring)) 
                {
                    ORACLEConn.Open(); 
                    using (OracleCommand comm = new OracleCommand(SQLQUERY, ORACLEConn)) 
                    {
                      using (OracleDataReader Rd = comm.ExecuteReader()) 
                      {
                          string tmp_STATUS = "", tmp_ACT_STATUS = "";
                        while (Rd.Read()) 
                        {
                            tmpIndex = tmpIndex + 1;
                            if (Rd["STATUS"].ToString() == "1")
                            {
                                tmp_STATUS = "Hoạt động";
                            }
                            else
                            {
                                tmp_STATUS = "Cắt hủy";
                            }

                            if (Rd["ACT_STATUS"].ToString() == "01")
                            {
                                tmp_ACT_STATUS = "Chặn chiều đi";
                            }
                            else if (Rd["ACT_STATUS"].ToString() == "02")
                            {
                                tmp_ACT_STATUS = "Chặn 2 chiều";
                            }
                            else if (Rd["ACT_STATUS"].ToString() == "10")
                            {
                                tmp_ACT_STATUS = "Chặn chiều đi Khách hàng yêu cầu";
                            }
                            else if (Rd["ACT_STATUS"].ToString() == "11")
                            {
                                tmp_ACT_STATUS = "Chặn chiều đi nợ cước KHYC";
                            }
                            else if (Rd["ACT_STATUS"].ToString() == "12")
                            {
                                tmp_ACT_STATUS = "Chặn 2 chiều + nợ cước KHYC";
                            }
                            else if (Rd["ACT_STATUS"].ToString() == "20")
                            {
                                tmp_ACT_STATUS = "Tạm cắt";
                            }
                            objTable.Rows.Add(tmpIndex.ToString(),Rd["ISDN"].ToString(), Rd["PROVINCE"].ToString(), Rd["BUS_NO"].ToString(), tmp_STATUS, tmp_ACT_STATUS);
                        }
                        Rd.Close(); 
                      }
                    }
                    ORACLEConn.Close(); 
                }
            }
            catch 
            {
            }
        }
        catch (Exception Ex)
        {
            HttpContext.Current.Response.Write(Ex.Message);
        }
        return objTable;
    }
    #endregion
    #endregion
}