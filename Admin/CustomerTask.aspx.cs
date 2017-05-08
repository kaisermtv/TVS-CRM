using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CustomerTask : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private Business objBusiness = new Business();
    private DataTable objTable = new DataTable();

    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();

    private int typeCustomer = 1;
    public string strHtmlName = "", strHtmlAddress = "", strHtmlPhone = "", strHtmlTaxCode = "", strHtmlDistrictName = "", strHtmlProvincerName = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "THÔNG TIN CÔNG VIỆC - KHÁCH HÀNG";
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
        try
        {
            this.typeCustomer = int.Parse(Request["type"].ToString());
        }
        catch
        {
            this.typeCustomer = 1;
        }

        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objCustomer.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.strHtmlName = this.objTable.Rows[0]["Name"].ToString();
                this.strHtmlAddress = this.objTable.Rows[0]["Address"].ToString();
                this.strHtmlPhone = this.objTable.Rows[0]["Phone"].ToString();
                this.strHtmlTaxCode = this.objTable.Rows[0]["TaxCode"].ToString();
                this.strHtmlDistrictName = this.objTable.Rows[0]["DistrictName"].ToString();
                this.strHtmlProvincerName = this.objTable.Rows[0]["ProvincerName"].ToString();
            }

            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objCustomer.getDataTask(this.itemId, "");
        cpCustomerTask.MaxPages = 1000;
        cpCustomerTask.PageSize = 15;
        cpCustomerTask.DataSource = this.objTable.DefaultView;
        cpCustomerTask.BindToControl = dtlCustomerTask;
        dtlCustomerTask.DataSource = cpCustomerTask.DataSourcePaged;
        dtlCustomerTask.DataBind();
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
        Response.Redirect("CustomerTaskEdit.aspx?cid="+this.itemId);
    }
     #endregion
}