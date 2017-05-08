using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TVSSystem
{
    #region method TVSSystem
    public TVSSystem()
    {
    } 
    #endregion

    #region method getCountOfObjects
    public int getCountOfObjects(string Table)
    {
        int tmpValue = 0;
        try
        {
            SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TVSConn"].ConnectionString);
            sqlCon.Open();
            SqlCommand Cmd = sqlCon.CreateCommand();
            Cmd.CommandText = "SELECT COUNT(*) AS CountItem FROM "+Table;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlDataReader Rd = Cmd.ExecuteReader();
            while(Rd.Read())
            {
                tmpValue = int.Parse(Rd["CountItem"].ToString());
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

    #region method convertDateTime
    public static DateTime convertDateTime(string objDate, ref bool correctFormat) //07/02/2017 08:54
    {
        correctFormat = false;

        DateTime objDate1 = new DateTime();
        try
        {
            objDate1 = new DateTime(int.Parse(objDate.Substring(6, 4)), int.Parse(objDate.Substring(3, 2)), int.Parse(objDate.Substring(0, 2)));
            correctFormat = true;
        }
        catch
        {
            correctFormat = false;
        }

        return objDate1;
    }
    #endregion

    #region method convertDateTimeFull
    public static DateTime convertDateTimeFull(string objDate, ref bool correctFormat) //07/02/2017 08:54
    {
        correctFormat = false;

        DateTime objDate1 = new DateTime();
        try
        {
            objDate1 = new DateTime(int.Parse(objDate.Substring(6, 4)), int.Parse(objDate.Substring(3, 2)), int.Parse(objDate.Substring(0, 2)), int.Parse(objDate.Substring(11, 2)), int.Parse(objDate.Substring(14, 2)),0);
            correctFormat = true;
        }
        catch
        {
            correctFormat = false;
        }

        return objDate1;
    }
    #endregion
}