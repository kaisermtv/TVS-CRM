using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChooseCustomer : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private Target objTarget = new Target();

    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();

    private SearchConfig objSearchConfig = new SearchConfig();
    private int itemId = 0;
    private string strSaved = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Write("<script type=\"text/javascript\">window.close();</script>");

            Response.Redirect("Login.aspx");
        }
        if (Session["TYPEID"] == null)
        {
            Session["TYPEID"] = "4";//Mac dinh la tai khoan loai AM
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        try
        {
            this.itemId = int.Parse(Request.QueryString["id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        try
        {
            this.strSaved = Request.QueryString["saved"].ToString();
            this.saved.Value = saved.ToString();
        }
        catch
        {
            this.strSaved = "";
        }
        if (!Page.IsPostBack)
        {
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

        if (!Page.IsPostBack)
        {
            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name");
            this.getData();
        }
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
        this.objTable = this.objCustomer.getData(0, this.txtSearch.Value, ProvincerId, DistrictId, WardId, int.Parse(Session["TYPEID"].ToString()), Session["ACCOUNT"].ToString(), 0, 0);
        cpCustomer.MaxPages = 1000;
        cpCustomer.PageSize = 10;
        cpCustomer.SliderSize = 20;
        cpCustomer.DataSource = this.objTable.DefaultView;
        cpCustomer.BindToControl = dtlCustomer;
        dtlCustomer.DataSource = cpCustomer.DataSourcePaged;
        dtlCustomer.DataBind();
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

        #region Luu gia tri tim kiem vao bang cau hinh
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblCustomer", "Name", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            NameValueCollection nvc = Request.Form;
            int CustomerId = 0;
            bool saved = false;
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
                                this.objTarget.setData(this.itemId, CustomerId);
                                saved = true;
                            }
                        }
                    }
            }
            if (saved)
            {
                this.saved.Value = saved.ToString();
                Response.Redirect("ChooseCustomer?id="+this.itemId.ToString()+"&saved=True");
            }
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

        this.getData();
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

            this.getData();
        }
    }
    #endregion
}