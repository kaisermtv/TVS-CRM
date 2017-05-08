using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Activity objActivity = new Activity();
    private int currPage = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (Session["TYPEID"] == null)
        {
            Session["TYPEID"] = "4";//Mac dinh la tai khoan loai AM
        }
        Session["TITLE"] = "QUẢN TRỊ QUAN HỆ KHÁCH HÀNG";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        if (!Page.IsPostBack)
        {
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objActivity.getData(Session["ACCOUNT"].ToString(), int.Parse(Session["TYPEID"].ToString()));
        cpActivity.MaxPages = 1000;
        cpActivity.PageSize = 14;
        cpActivity.DataSource = this.objTable.DefaultView;
        cpActivity.BindToControl = dtlActivity;
        dtlActivity.DataSource = cpActivity.DataSourcePaged;
        dtlActivity.DataBind();
        if (this.objTable.Rows.Count < 14)
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