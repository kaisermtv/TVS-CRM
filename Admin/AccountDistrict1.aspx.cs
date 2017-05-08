using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AccountDistrict1 : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0, id = 0;
    public string curr_UserName = "", providerId = "0";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        try
        {
            this.curr_UserName = Request.QueryString["acc"].ToString();
        }
        catch
        {
            this.curr_UserName = "";
        }
        try
        {
            this.providerId = Request.QueryString["pro"].ToString();
        }
        catch
        {
            this.providerId = "0";
        }
        try
        {
            this.id = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.id = 0;
        }
        if (this.id > 0)
        {
            this.objAccount.delLevelDistrictId(this.curr_UserName, this.id);
        }
        this.getData();
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objDistrict.getDataManagement(int.Parse(this.providerId), "", this.curr_UserName);
        cpDistrict.MaxPages = 1000;
        cpDistrict.PageSize = 15;
        cpDistrict.DataSource = this.objTable.DefaultView;
        cpDistrict.BindToControl = dtlDistrict;
        dtlDistrict.DataSource = cpDistrict.DataSourcePaged;
        dtlDistrict.DataBind();
        if (this.objTable.Rows.Count < 15)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion
}