using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Setting : System.Web.UI.Page
{
    #region declare objects
    public string strReturlActCustomer = "";
    private Customer objCustomer = new Customer();
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CÀI ĐẶT HỆ THỐNG";
    } 
    #endregion

    #region method btnActionCustomer_Click
    protected void btnActionCustomer_Click(object sender, EventArgs e)
    {
        this.strReturlActCustomer = this.objCustomer.setCustomerInfor();
    } 
    #endregion
}