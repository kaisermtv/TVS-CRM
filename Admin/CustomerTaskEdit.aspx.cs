using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CustomerTaskEdit : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private Business objBusiness = new Business();
    private Activity objActivity = new Activity();
    private DataTable objTable = new DataTable();

    private int itemId = 0;
    private int CustomerId = 1;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CẬP NHẬT CÔNG VIỆC VỚI KHÁCH HÀNG";
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
            this.CustomerId = int.Parse(Request["cid"].ToString());
        }
        catch
        {
            this.CustomerId = 1;
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objCustomer.getDataByIdTask(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.txtDayBegin.Value = this.objTable.Rows[0]["DayBegin"].ToString();
                this.txtDayEnd.Value = this.objTable.Rows[0]["DayEnd"].ToString();
                this.ddlPriority.SelectedValue = this.objTable.Rows[0]["Priority"].ToString();
                this.ddlState.SelectedValue = this.objTable.Rows[0]["State"].ToString();

                this.txtUserCreate.Text = this.objTable.Rows[0]["ContactId"].ToString();
                this.txtUserCreateName.Text = this.objTable.Rows[0]["ContactName"].ToString();
                this.txtContactPhone.Text = this.objTable.Rows[0]["ContactPhone"].ToString();

                this.txtUserManagerment.Text = this.objTable.Rows[0]["ManagerId"].ToString();
                this.txtUserManagermentName.Text = this.objTable.Rows[0]["ManagerName"].ToString();

                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();

                #region Check For Create and permisstion update
                DataTable tmpTableAccount = new DataTable();
                tmpTableAccount = this.objAccount.getDataByUserName(Session["ACCOUNT"].ToString());
                if (tmpTableAccount.Rows.Count > 0)
                {
                    if (tmpTableAccount.Rows[0]["Id"].ToString() == this.txtUserCreate.Text)
                    {
                        this.btnSave.Enabled = true;
                    }
                    else
                    {
                        this.btnSave.Enabled = false;
                    }
                }
                #endregion
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
            this.lblMsg.Text = "Bạn chưa nhập tên của công việc";
            this.txtName.Focus();
            return;
        }

        if (this.txtDayBegin.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn ngày bắt đầu";
            this.txtDayBegin.Focus();
            return;
        }

        bool correctFormat = false;
        DateTime objDayBegin = TVSSystem.convertDateTime(this.txtDayBegin.Value.Trim(), ref correctFormat);
        if (!correctFormat)
        {
            this.lblMsg.Text = "Định dạng ngày bắt đầu chưa đúng, vui lòng kiểm tra lại";
            this.txtDayBegin.Focus();
            return;
        }

        if (this.txtDayEnd.Value.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa chọn ngày kết thúc";
            this.txtDayEnd.Focus();
            return;
        }

        correctFormat = false;
        DateTime objDayEnd = TVSSystem.convertDateTime(this.txtDayEnd.Value.Trim(), ref correctFormat);
        if (!correctFormat)
        {
            this.lblMsg.Text = "Định dạng ngày kết thúc chưa đúng, vui lòng kiểm tra lại";
            this.txtDayEnd.Focus();
            return;
        }

        if (this.txtUserCreate.Text.Trim() == "" || this.txtUserCreate.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người tạo tạo công việc";
            this.txtUserCreate.Text = "0";
            this.txtUserCreateName.Focus();
            return;
        }

        if (this.txtUserManagerment.Text.Trim() == "" || this.txtUserManagerment.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người thực thi công việc";
            this.txtUserManagerment.Text = "0";
            this.txtUserManagermentName.Focus();
            return;
        }

        if (this.txtNote.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập thông tin diễn giải của công việc";
            this.txtNote.Focus();
            return;
        }

        if (this.objCustomer.setDataTask(this.itemId, this.txtName.Text, TVSSystem.convertDateTime(this.txtDayBegin.Value, ref correctFormat), TVSSystem.convertDateTime(this.txtDayEnd.Value, ref correctFormat), int.Parse(this.ddlPriority.SelectedValue.ToString()), int.Parse(this.ddlState.SelectedValue.ToString()), this.CustomerId, int.Parse(this.txtUserCreate.Text), this.txtUserCreateName.Text, this.txtContactPhone.Text, int.Parse(this.txtUserManagerment.Text), this.txtUserManagermentName.Text, this.txtNote.Text) == 1)
        {
            if (this.itemId == 0)
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Thêm công việc <b><a href = \"CustomerTaskEdit.aspx?id=" + this.objCustomer.getDataIdTask().ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            else
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Truy cập công việc <b><a href = \"CustomerTaskEdit.aspx?id=" + this.itemId.ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            Response.Redirect("CustomerTask.aspx?id=" + this.CustomerId.ToString());
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
        Response.Redirect("CustomerTask.aspx?id=" + this.CustomerId.ToString());
    }
    #endregion
}