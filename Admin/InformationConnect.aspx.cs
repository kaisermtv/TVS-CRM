using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_InformationConnect : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private SearchConfig objSearchConfig = new SearchConfig();
    private string CodeConnect = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        try
        {
            this.CodeConnect = Request.QueryString["id"].ToString();
        }
        catch
        {
            this.CodeConnect = "";
        }
        if (!Page.IsPostBack && this.CodeConnect.Trim() != "")
        {
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objCustomer.getData(this.CodeConnect);
         cpContact.MaxPages = 1000;
        cpContact.PageSize = 10;
        cpContact.DataSource = this.objTable.DefaultView;
        cpContact.BindToControl = dtlContact;
        dtlContact.DataSource = cpContact.DataSourcePaged;
        dtlContact.DataBind();
        if (this.objTable.Rows.Count < 10)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();

        //#region Luu gia tri tim kiem vao bang cau hinh
        //this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblAccount", "Name", this.txtSearch.Text.Trim());
        //#endregion
    }
    #endregion
}