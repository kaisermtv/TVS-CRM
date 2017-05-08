using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Customer : System.Web.UI.Page
{
    #region declare objects

    public int index = 1;

    public DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();

    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();

    private Business objBusiness = new Business();

    private SearchConfig objSearchConfig = new SearchConfig();
    public int currPage = 0, typeCustomer = 1, totalItem = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;

    public string strCheckBoxTitle = "Khách hàng hiện hữu";

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
        Session["TITLE"] = "DANH SÁCH KHÁCH HÀNG";
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.typeCustomer = int.Parse(Request["type"].ToString());
            if (this.typeCustomer == 3)
            {
                this.btnForward.Enabled = false;
                this.btnForward.Visible = false;

                this.rdbType3.Visible = false;

                this.strCheckBoxTitle = "";
            }
        }
        catch
        {
            this.typeCustomer = 1;
        }
        if (!Page.IsPostBack)
        {
            this.ddlBusiness.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlBusiness.DataTextField = "Name";
            this.ddlBusiness.DataValueField = "Id";
            this.ddlBusiness.DataBind();

            this.ddlBusiness.SelectedValue = "0";

            this.ddlProvincer.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlProvincer.DataTextField = "Name";
            this.ddlProvincer.DataValueField = "Id";
            this.ddlProvincer.DataBind();

            this.ddlProvincer.SelectedValue = "0";

            if (this.ddlProvincer.Items.Count > 0)
            {
                this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
                this.ddlDistrict.DataTextField = "Name";
                this.ddlDistrict.DataValueField = "Id";
                this.ddlDistrict.DataBind();

                this.ddlDistrict.SelectedValue = "0";
            }

            if (this.ddlDistrict.Items.Count > 0)
            {
                this.ddlWard.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString(), this.ddlDistrict.SelectedValue.ToString());
                this.ddlWard.DataTextField = "Name";
                this.ddlWard.DataValueField = "Id";
                this.ddlWard.DataBind();

                this.ddlWard.SelectedValue = "0";
            }
        }

        this.getData();
        this.cpCustomer.Visible = true;
    }
    #endregion

    #region getData()
    private void getData()
    {
        int ProvincerId = 0, DistrictId = 0, WardId = 0;
        if (this.ddlProvincer.Items.Count > 0)
        {
            ProvincerId = int.Parse(this.ddlProvincer.SelectedValue.ToString());
        }
        if (this.ddlDistrict.Items.Count > 0)
        {
            DistrictId = int.Parse(this.ddlDistrict.SelectedValue.ToString());
        }
        if (this.ddlWard.Items.Count > 0)
        {
            WardId = int.Parse(this.ddlWard.SelectedValue.ToString());
        }
        this.objTable = new DataTable();
        this.objTable = this.objCustomer.getData(this.typeCustomer, this.txtSearch.Value, ProvincerId, DistrictId, WardId, int.Parse(Session["TYPEID"].ToString()), Session["ACCOUNT"].ToString(), int.Parse(this.ddlNumEmp.SelectedValue.ToString()), int.Parse(this.ddlBusiness.SelectedValue.ToString()));
        cpCustomer.MaxPages = 1000;
        cpCustomer.PageSize = 10;
        cpCustomer.SliderSize = 20;
        cpCustomer.ShowPageNumbers = true;
        cpCustomer.DataSource = this.objTable.DefaultView;
        cpCustomer.BindToControl = dtlCustomer;
        dtlCustomer.DataSource = cpCustomer.DataSourcePaged;
        dtlCustomer.DataBind();
        //if (this.objTable.Rows.Count < 10)
        //{
        //    this.tblABC.Visible = false;
        //}
        //else
        //{
        //    this.tblABC.Visible = true;
        //}
        this.totalItem = this.objTable.Rows.Count;
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        //this.getData();

        //#region Luu gia tri tim kiem vao bang cau hinh
        //this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name", this.txtSearch.Value.Trim());
        //#endregion
    }
    #endregion

    #region method btnForward_Click
    protected void btnForward_Click(object sender, EventArgs e)
    {
        try
        {
            NameValueCollection nvc = Request.Form;
            int CustomerId = 0;
            int TypeId = 1;
            bool saved = false;
            if (this.rdbType3.Checked)
            {
               TypeId = 3;
            }
            if (nvc.Count > 0)
            {
                foreach (string s in nvc)
                    if (s.Contains("ckb"))
                    {
                        foreach (string v in nvc.GetValues(s))
                        {
                            try
                            {
                                CustomerId = int.Parse(s.Replace("ckb", "").Trim());
                            }
                            catch
                            {

                            }
                            if (CustomerId > 0)
                            {
                                this.objCustomer.setData(CustomerId, TypeId);
                                saved = true;
                            }
                        }
                    }
            }
            //if (saved)
            //{
            //    this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name");
            //    this.getData();
            //}
        }
        catch
        {
        }
    } 
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlProvincer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
        this.ddlDistrict.DataTextField = "Name";
        this.ddlDistrict.DataValueField = "Id";
        this.ddlDistrict.DataBind();

        this.ddlDistrict.SelectedValue = "0";

        //this.getData();

        //#region Luu gia tri tim kiem vao bang cau hinh
        //this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name", this.txtSearch.Value.Trim());
        //#endregion
    }
    #endregion

    #region method ddlDistrict_SelectedIndexChanged
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlDistrict.Items.Count > 0)
        {
            this.ddlWard.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString(), this.ddlDistrict.SelectedValue.ToString());
            this.ddlWard.DataTextField = "Name";
            this.ddlWard.DataValueField = "Id";
            this.ddlWard.DataBind();

            this.ddlWard.SelectedValue = "0";
        }

        //this.getData();

        //#region Luu gia tri tim kiem vao bang cau hinh
        //this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name", this.txtSearch.Value.Trim());
        //#endregion
    }
    #endregion
    
    #region method btnExportToExcel_Click
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        int ProvincerId = 0, DistrictId = 0, WardId = 0;
        if (this.ddlProvincer.Items.Count > 0)
        {
            ProvincerId = int.Parse(this.ddlProvincer.SelectedValue.ToString());
        }
        if (this.ddlDistrict.Items.Count > 0)
        {
            DistrictId = int.Parse(this.ddlDistrict.SelectedValue.ToString());
        }
        if (this.ddlWard.Items.Count > 0)
        {
            WardId = int.Parse(this.ddlWard.SelectedValue.ToString());
        }
        this.objTable = this.objCustomer.getData(this.typeCustomer, this.txtSearch.Value, ProvincerId, DistrictId, WardId, int.Parse(Session["TYPEID"].ToString()), Session["ACCOUNT"].ToString(), int.Parse(this.ddlNumEmp.SelectedValue.ToString()), int.Parse(this.ddlBusiness.SelectedValue.ToString()));
        this.ExportToExcel(this.objTable);
    } 
    #endregion

    #region method ExportToExcel
    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string filename = "Customer.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();

            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();          

            dgGrid.RenderControl(hw);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    } 
    #endregion

    #region method VerifyRenderingInServerForm
    public override void VerifyRenderingInServerForm(Control control)
    {

    }  
    #endregion

    #region method ddlBusiness_SelectedIndexChanged
    protected void ddlBusiness_SelectedIndexChanged(object sender, EventArgs e)
    {
        //this.getData();
    } 
    #endregion
}