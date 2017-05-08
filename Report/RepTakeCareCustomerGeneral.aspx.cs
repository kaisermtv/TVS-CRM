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
            Session["TITLE"] = "BÁO CÁO TỔNG HỢP CHĂM SÓC KHÁCH HÀNG";
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

            this.getData();
        }
    } 
    #endregion

    #region method getData
    private void getData()
    {
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

            this.objTable = objCustomer.getRepDataTaskGeneral(objDayBegin, objDayEnd, int.Parse(this.ddlProvincer.SelectedValue.ToString()));
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

    #region method btnExportToExcel_Click
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        if (this.txtDayBegin.Value.Trim() == "" || this.txtDayEnd.Value.Trim() == "")
        {
            return;
        }
        this.objTable = objCustomer.getRepDataTaskGeneral(DateTime.Parse(this.txtDayBegin.Value.Trim()), DateTime.Parse(this.txtDayEnd.Value.Trim()), int.Parse(this.ddlProvincer.SelectedValue.ToString()));
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