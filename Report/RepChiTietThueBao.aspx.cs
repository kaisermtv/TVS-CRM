using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_RepChiTietThueBao : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();

    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0, typeCustomer = 1;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;

    public string strHtmlReport = "";

    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("../Admin/Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            this.objTable = objCustomer.getRepChiTietThueBao();
            //if (this.objTable.Rows.Count > 0)
            //{
            //    for (int i = 0; i < this.objTable.Rows.Count; i++)
            //    {
            //        this.strHtmlReport += "<tr>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["MAKHACHHANG"].ToString()+ "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["MAKHACHHANG"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["MAKHACHHANG"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["MAKHACHHANG"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["TENKHACHHANG"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["DIACHITHANHTOAN"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["GPKD"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["MST"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["TINHTHANHPHO"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["QUANHUYEN"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>" + this.objTable.Rows[i]["PHUONGXA"].ToString() + "</td>";
            //        this.strHtmlReport += "<td>&nbsp;</td>";
            //        this.strHtmlReport += "<td>&nbsp;</td>";
            //        this.strHtmlReport += "<td>&nbsp;</td>";
            //        this.strHtmlReport += "<td>&nbsp;</td>";
            //        this.strHtmlReport += "</tr>";
            //    }
            //}
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
    } 
    #endregion
}