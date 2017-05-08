using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TargetEdit : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    private Target objTarget = new Target();
    private Activity objActivity = new Activity();
    private DataTable objTable = new DataTable();

    private int itemId = 0, curr_UserCreate_Id = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region declare Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CẬP NHẬT CHỈ TIÊU, NHIỆM VỤ";
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
            this.objTable = this.objTarget.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.txtNote.Text = this.objTable.Rows[0]["Note"].ToString();
                this.txtDayBegin.Value = this.objTable.Rows[0]["DayBegin"].ToString();
                this.txtDayEnd.Value = this.objTable.Rows[0]["DayEnd"].ToString();
                this.txtUserCreate.Text = this.objTable.Rows[0]["UserCreate"].ToString();
                this.txtUserCreateName.Text = this.objTable.Rows[0]["UserCreateName"].ToString();
                this.txtUserManagerment.Text = this.objTable.Rows[0]["UserDeployment"].ToString();
                this.txtUserManagermentName.Text = this.objTable.Rows[0]["UserDeploymentName"].ToString();

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
            this.lblMsg.Text = "Bạn chưa nhập tên chỉ tiêu, nhiệm vụ";
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
            this.lblMsg.Text = "Bạn chưa nhập diễn giải của chỉ tiêu, nhiệm vụ";
            this.txtNote.Focus();
            return;
        }

        if (this.objTarget.setData(this.itemId, this.txtName.Text, this.txtNote.Text, int.Parse(this.txtUserCreate.Text), this.txtUserCreateName.Text, int.Parse(this.txtUserManagerment.Text), this.txtUserManagermentName.Text, TVSSystem.convertDateTimeFull(this.txtDayBegin.Value, ref correctFormat), TVSSystem.convertDateTimeFull(this.txtDayEnd.Value, ref correctFormat)) == 1)
        {
            if (this.itemId == 0)
            {
                #region Gui email cho nguoi duoc giao viec
                DataTable objTableAccount = this.objAccount.getDataById(int.Parse(this.txtUserManagerment.Text));
                if (objTableAccount.Rows.Count > 0)
                {
                    if (objTableAccount.Rows[0]["Email"].ToString() != "")
                    {
                        TVSEmail.SendMail("V/v chỉ tiêu nhiệm vụ mới từ MMobifone CRM", Session["FULLNAME"].ToString() + " - Thêm chỉ tiêu, nhiệm vụ <b><a href = \"TargetEdit.aspx?id=" + this.objTarget.getDataId().ToString() + "\">" + this.txtName.Text + "</a></b>",objTableAccount.Rows[0]["Email"].ToString(),true, true);
                    }
                }
                #endregion
                
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Thêm chỉ tiêu, nhiệm vụ <b><a href = \"TargetEdit.aspx?id=" + this.objTarget.getDataId().ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            else
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Cập nhật chỉ tiêu, nhiệm vụ <b><a href = \"TargetEdit.aspx?id=" + this.itemId.ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            Response.Redirect("Target.aspx");
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
        Response.Redirect("Target.aspx");
    }
    #endregion
}