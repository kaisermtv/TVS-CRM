using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_RepTakeCareCustomer : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private Provincer objProvincer = new Provincer();

    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0, typeCustomer = 1;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }

        try
        {
            typeCustomer = int.Parse(Request.QueryString["type"].ToString());
        }
        catch
        {
            typeCustomer = 1;
        }
        if (typeCustomer == 2)
        {
            Session["TITLE"] = "BÁO CÁO CHĂM SÓC KHÁCH HÀNG TIỀM NĂNG";
        }
        else if (typeCustomer == 3)
        {
            Session["TITLE"] = "BÁO CÁO CHĂM SÓC KHÁCH HÀNG HIỆN HỮU";
        }
        if (!Page.IsPostBack)
        {
            this.txtDayBegin.Value = DateTime.Now.AddDays(-3).ToString();
            this.txtDayEnd.Value = DateTime.Now.ToString();

            this.ddlProvincer.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlProvincer.DataTextField = "Name";
            this.ddlProvincer.DataValueField = "Id";
            this.ddlProvincer.DataBind();

            this.ddlProvincer.SelectedValue = "0";

            bool correctFormat = false;
            DateTime objDayBegin = TVSSystem.convertDateTime(this.txtDayBegin.Value.Trim(), ref correctFormat);
            correctFormat = false;
            DateTime objDayEnd = TVSSystem.convertDateTime(this.txtDayEnd.Value.Trim(), ref correctFormat);

            int tmpProvincerId = 0, tmpAccount = 0;

            if (this.ddlProvincer.SelectedValue != null && this.ddlProvincer.SelectedValue.ToString() != "")
            {
                tmpProvincerId = int.Parse(this.ddlProvincer.SelectedValue.ToString());
            }

            if (this.ddlAccount.SelectedValue != null && this.ddlAccount.SelectedValue.ToString() != "")
            {
                tmpAccount = int.Parse(this.ddlAccount.SelectedValue.ToString());
            }

            this.ddlAccount.DataSource = this.objAccount.getDataToCombobox(objDayBegin, objDayEnd, tmpProvincerId);
            this.ddlAccount.DataTextField = "FullName";
            this.ddlAccount.DataValueField = "Id";
            this.ddlAccount.DataBind();

            this.ddlAccount.SelectedValue = "0";

            this.getData();
        }
    } 
    #endregion

    #region method getData
    private void getData()
    {
        int tmpProvincerId = 0, tmpAccount = 0;

        if (this.ddlProvincer.SelectedValue != null && this.ddlProvincer.SelectedValue.ToString() != "")
        {
            tmpProvincerId = int.Parse(this.ddlProvincer.SelectedValue.ToString());
        }

        if (this.ddlAccount.SelectedValue != null && this.ddlAccount.SelectedValue.ToString() != "")
        {
            tmpAccount = int.Parse(this.ddlAccount.SelectedValue.ToString());
        }

        if (this.txtDayBegin.Value.Trim() == "" || this.txtDayEnd.Value.Trim() == "")
        {
            return;
        }

        try
        {
            bool correctFormat = false;
            DateTime objDayBegin = TVSSystem.convertDateTime(this.txtDayBegin.Value.Trim(), ref correctFormat);
            correctFormat = false;
            DateTime objDayEnd = TVSSystem.convertDateTime(this.txtDayEnd.Value.Trim(), ref correctFormat);

            this.objTable = objCustomer.getRepDataTask(objDayBegin, objDayEnd,tmpProvincerId, tmpAccount, this.typeCustomer);
            cpCustomer.MaxPages = 1000;
            cpCustomer.PageSize = 9;
            cpCustomer.SliderSize = 20;
            cpCustomer.ShowPageNumbers = true;
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
        catch (Exception Ex)
        {
            Response.Write(Ex.Message);
        }
    }
    #endregion

    #region method btnSearch_Click
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.getData();
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlProvincer_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool correctFormat = false;
        DateTime objDayBegin = TVSSystem.convertDateTime(this.txtDayBegin.Value.Trim(), ref correctFormat);
        correctFormat = false;
        DateTime objDayEnd = TVSSystem.convertDateTime(this.txtDayEnd.Value.Trim(), ref correctFormat);

        this.ddlAccount.DataSource = this.objAccount.getDataToCombobox(objDayBegin, objDayEnd, int.Parse(this.ddlProvincer.SelectedValue.ToString()));
        this.ddlAccount.DataTextField = "FullName";
        this.ddlAccount.DataValueField = "Id";
        this.ddlAccount.DataBind();

        this.ddlAccount.SelectedValue = "0";
    } 
    #endregion

    #region method btnExportToExcel_Click
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {

        if (this.txtDayBegin.Value.Trim() == "" || this.txtDayEnd.Value.Trim() == "")
        {
            return;
        }
        
        bool correctFormat = false;
        DateTime objDayBegin = TVSSystem.convertDateTime(this.txtDayBegin.Value.Trim(), ref correctFormat); 
        correctFormat = false;
        DateTime objDayEnd = TVSSystem.convertDateTime(this.txtDayEnd.Value.Trim(), ref correctFormat);

        this.objTable = objCustomer.getRepDataTask(objDayBegin, objDayEnd, int.Parse(this.ddlProvincer.SelectedValue.ToString()), int.Parse(this.ddlAccount.SelectedValue.ToString()), this.typeCustomer);
        this.ExportToExcel(this.objTable);
    }
    #endregion

    #region method ExportToExcel
    public void ExportToExcel(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            string filename = "RepTakeCareCustomer.xls";
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
}