using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Target : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Target objTarget = new Target();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0, typeCustomer = 1;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CHỈ TIÊU, NHIỆM VỤ";
        if (!Page.IsPostBack)
        {
            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblTarget", "Name");
            this.getData();
        }
    } 
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objTarget.getData(this.txtSearch.Value, Session["ACCOUNT"].ToString());
        cpTarget.MaxPages = 1000;
        cpTarget.PageSize = 12;
        cpTarget.SliderSize = 30;
        cpTarget.DataSource = this.objTable.DefaultView;
        cpTarget.BindToControl = dtlTarget;
        dtlTarget.DataSource = cpTarget.DataSourcePaged;
        dtlTarget.DataBind();
        if (this.objTable.Rows.Count < 12)
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

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblTarget", "Name", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion
}