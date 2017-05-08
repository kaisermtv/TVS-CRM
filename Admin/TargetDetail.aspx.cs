using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TargetDetail : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private Target objTarget = new Target();
    private DataTable objTable = new DataTable();

    public string strHtmlName = "", strHtmlTime;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "THÔNG TIN CHỈ TIÊU, NHIỆM VỤ";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        this.targetId.Value = this.itemId.ToString();
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objTarget.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.strHtmlName = "<b>"+this.objTable.Rows[0]["Name"].ToString()+"</b>";
                this.strHtmlTime = "Ngày bắt đầu: <b>" + this.objTable.Rows[0]["DayBegin"].ToString()+"</b> - Ngày kết thúc: <b>"+ this.objTable.Rows[0]["DayEnd"].ToString()+"</b>";
            }

            #region Check For Create and permisstion update
            DataTable tmpTableAccount = new DataTable();
            tmpTableAccount = this.objAccount.getDataByUserName(Session["ACCOUNT"].ToString());
            if (tmpTableAccount.Rows.Count > 0)
            {
                if (tmpTableAccount.Rows[0]["Id"].ToString() == this.objTable.Rows[0]["UserCreate"].ToString())
                {
                    this.btnAdd.Disabled = false;
                }
                else
                {
                    this.btnAdd.Disabled = true;
                }
            }
            #endregion

            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objTarget.getDataTargetCustomer(this.itemId.ToString());
        cpCustomer.MaxPages = 1000;
        cpCustomer.PageSize = 15;
        cpCustomer.DataSource = this.objTable.DefaultView;
        cpCustomer.BindToControl = dtlCustomer;
        dtlCustomer.DataSource = cpCustomer.DataSourcePaged;
        dtlCustomer.DataBind();
        if (this.objTable.Rows.Count < 9)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }
    }
    #endregion

    #region mthod btnAdd_Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Response.Redirect("CustomerTaskEdit.aspx?cid=" + this.itemId);
    }
    #endregion
}