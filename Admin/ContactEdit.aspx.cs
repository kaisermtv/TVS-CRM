using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ContactEdit : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private Contact objContact = new Contact();
    private Activity objActivity = new Activity();
    private DataTable objTable = new DataTable();
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CẬP NHẬT DANH BẠ";
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
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objContact.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.txtPhone.Text = this.objTable.Rows[0]["Phone"].ToString();
                this.txtCompanyName.Text = this.objTable.Rows[0]["CompanyName"].ToString();
                this.txtPossition.Text = this.objTable.Rows[0]["Possition"].ToString();
                this.txtDepartment.Text = this.objTable.Rows[0]["Department"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();

                this.txtUserCreate.Text = this.objTable.Rows[0]["UserCreate"].ToString();
                this.txtUserCreateName.Text = this.objTable.Rows[0]["UserCreateName"].ToString();

                this.txtUserManagerment.Text = this.objTable.Rows[0]["UserManagerment"].ToString();
                this.txtUserManagermentName.Text = this.objTable.Rows[0]["UserManagermentName"].ToString();

                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());
            }
        }
        else
        {
            this.objTable = this.objAccount.getDataByUserName(Session["ACCOUNT"].ToString());
            if (this.objTable.Rows.Count > 0)
            {
                this.txtUserCreate.Text = this.objTable.Rows[0]["Id"].ToString();
                this.txtUserCreateName.Text = this.objTable.Rows[0]["FullName"].ToString();
            }
        }
        this.txtName.Focus();
    } 
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập họ và tên";
            this.txtName.Focus();
            return;
        }

        if (this.txtPhone.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập số điện thoại";
            this.txtPhone.Focus();
            return;
        }

        if (this.txtUserCreate.Text.Trim() == "" || this.txtUserCreate.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người cập nhật thông tin danh bạ";
            this.txtUserCreate.Text = "0";
            this.txtUserCreateName.Focus();
            return;
        }

        if (this.txtUserManagerment.Text.Trim() == "" || this.txtUserManagerment.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người quản lý thông tin danh bạ";
            this.txtUserManagerment.Text = "0";
            this.txtUserManagermentName.Focus();
            return;
        }

        if (this.objContact.setData(this.itemId, this.txtName.Text, this.txtPhone.Text, this.txtCompanyName.Text, this.txtPossition.Text, this.txtDepartment.Text, this.txtEmail.Text, int.Parse(this.txtUserCreate.Text), this.txtUserCreateName.Text, int.Parse(this.txtUserManagerment.Text), this.txtUserManagermentName.Text, this.ckbState.Checked) == 1)
        {
            if (this.itemId == 0)
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Thêm danh bạ <b><a href = \"ContactEdit.aspx?id=" + this.objContact.getDataId().ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            else
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Cập nhật danh bạ <b><a href = \"ContactEdit.aspx?id=" + this.itemId.ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            Response.Redirect("Contact.aspx");
        }
        else
        {
            this.lblMsg.Text = "Lỗi xảy ra khi cập nhật thông tin.";
        }

        this.txtName.Focus();
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contact.aspx");
    }
    #endregion
}