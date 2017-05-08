using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CustomerEdit1 : System.Web.UI.Page
{
    #region declare objects
    private int itemId = 0;
    private Account objAccount = new Account();
    private Customer objCustomer = new Customer();
    private Activity objActivity = new Activity();
    private Business objBusiness = new Business();
    private DataTable objTable = new DataTable();

    private District objDistrict = new District();
    private Provincer objProvincer = new Provincer();
    private Ward objWard = new Ward();

    private int typeCustomer = 2;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["TITLE"] = "CẬP NHẬT THÔNG TIN KHÁCH HÀNG";
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
        if (!Page.IsPostBack)
        {
            this.ddlProvincer.DataSource = this.objProvincer.getDataCategoryToCombobox();
            this.ddlProvincer.DataTextField = "Name";
            this.ddlProvincer.DataValueField = "Id";
            this.ddlProvincer.DataBind();

            if (this.ddlProvincer.Items.Count > 0)
            {
                this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
                this.ddlDistrict.DataTextField = "Name";
                this.ddlDistrict.DataValueField = "Id";
                this.ddlDistrict.DataBind();
            }

            if (this.ddlDistrict.Items.Count > 0)
            {
                this.ddlWard.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString(), this.ddlDistrict.SelectedValue.ToString());
                this.ddlWard.DataTextField = "Name";
                this.ddlWard.DataValueField = "Id";
                this.ddlWard.DataBind();
            }

            this.ddlBusiness.DataSource = this.objBusiness.getDataCategoryToCombobox();
            this.ddlBusiness.DataTextField = "Name";
            this.ddlBusiness.DataValueField = "Id";
            this.ddlBusiness.DataBind();
        }
        if (!Page.IsPostBack && this.itemId > 0)
        {
            this.objTable = this.objCustomer.getDataById(this.itemId);
            if (this.objTable.Rows.Count > 0)
            {
                this.txtName.Text = this.objTable.Rows[0]["Name"].ToString();
                this.txtAddress.Text = this.objTable.Rows[0]["Address"].ToString();
                this.txtAddressBill.Text = this.objTable.Rows[0]["AddressBill"].ToString();
                this.txtPhone.Text = this.objTable.Rows[0]["Phone"].ToString();
                this.txtTaxCode.Text = this.objTable.Rows[0]["TaxCode"].ToString();
                this.txtContactName.Text = this.objTable.Rows[0]["ContactName"].ToString();
                this.txtEmail.Text = this.objTable.Rows[0]["Email"].ToString();

                this.ddlProvincer.SelectedValue = this.objTable.Rows[0]["ProvincerId"].ToString();
                if (this.ddlProvincer.Items.Count > 0)
                {
                    this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
                    this.ddlDistrict.DataTextField = "Name";
                    this.ddlDistrict.DataValueField = "Id";
                    this.ddlDistrict.DataBind();
                }
                this.ddlDistrict.SelectedValue = this.objTable.Rows[0]["DistrictId"].ToString();
                if (this.ddlDistrict.Items.Count > 0)
                {
                    this.ddlWard.DataSource = this.objWard.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString(), this.ddlDistrict.SelectedValue.ToString());
                    this.ddlWard.DataTextField = "Name";
                    this.ddlWard.DataValueField = "Id";
                    this.ddlWard.DataBind();
                }
                this.ddlWard.SelectedValue = this.objTable.Rows[0]["WardId"].ToString();

                this.ddlBusiness.SelectedValue = this.objTable.Rows[0]["BusinessId"].ToString();

                this.txtUserCreate.Text = this.objTable.Rows[0]["UserCreate"].ToString();
                this.txtUserCreateName.Text = this.objTable.Rows[0]["UserCreateName"].ToString();

                this.txtUserManagerment.Text = this.objTable.Rows[0]["UserManagerment"].ToString();
                this.txtUserManagermentName.Text = this.objTable.Rows[0]["UserManagermentName"].ToString();
                this.txtBusinessLlicense.Text = this.objTable.Rows[0]["BusinessLlicense"].ToString();
                this.ckbState.Checked = bool.Parse(this.objTable.Rows[0]["State"].ToString());

                this.txtNumViettel.Text = this.objTable.Rows[0]["NumViettel"].ToString();
                this.txtNumViNaPhone.Text = this.objTable.Rows[0]["NumViNaPhone"].ToString();
                this.txtNumOther.Text = this.objTable.Rows[0]["NumOther"].ToString();

                //this.txtTBTS.Text = this.objTable.Rows[0]["TBTS"].ToString();
                //this.txtTBTT.Text = this.objTable.Rows[0]["TBTT"].ToString();
                //this.txtC2C.Text = this.objTable.Rows[0]["C2C"].ToString();
                //this.txtC1C.Text = this.objTable.Rows[0]["C1C"].ToString();
                //this.txtSLMBU.Text = this.objTable.Rows[0]["SLMBU"].ToString();

                this.typeCustomer = int.Parse(this.objTable.Rows[0]["TypeId"].ToString());

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

                if (this.objTable.Rows[0]["CodeConnect"].ToString().Trim() != "")
                {
                    this.getDataConect(this.objTable.Rows[0]["CodeConnect"].ToString().Trim());
                }
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

    #region getDataConect()
    private void getDataConect(string CodeConnect)
    {
        int TBTT = 0, TBTS = 0, C2C = 0, C1C = 0, SLMBU = 0;

        this.objTable = this.objCustomer.getDataChiTietThueBao(CodeConnect, ref TBTT, ref TBTS, ref C2C, ref C1C, ref SLMBU);
        cpContact.MaxPages = 1000;
        cpContact.PageSize = 100;
        cpContact.DataSource = this.objTable.DefaultView;
        cpContact.BindToControl = dtlContact;
        dtlContact.DataSource = cpContact.DataSourcePaged;
        dtlContact.DataBind();
        if (this.objTable.Rows.Count < 100)
        {
            this.tblABC.Visible = false;
        }
        else
        {
            this.tblABC.Visible = true;
        }

        this.txtTBTS.Text = TBTS.ToString();
        this.txtTBTT.Text = TBTT.ToString();
        this.txtC2C.Text = C2C.ToString();
        this.txtC1C.Text = C1C.ToString();
        this.txtSLMBU.Text = SLMBU.ToString();

        this.objCustomer.setCustomerInfor1(CodeConnect,TBTT,TBTS,C2C,C1C,SLMBU);

    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.lblMsg.Text = "";

        if (this.txtName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập tên khách hàng";
            this.txtName.Focus();
            return;
        }

        if (this.txtAddress.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập địa chỉ khách hàng";
            this.txtAddress.Focus();
            return;
        }

        if (this.txtAddressBill.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập địa chỉ thanh toán của khách hàng";
            this.txtAddressBill.Focus();
            return;
        }     

        if (this.txtTaxCode.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập mã số thuế/GPKD";
            this.txtTaxCode.Focus();
            return;
        }

        if (this.txtTaxCode.Text.Trim() == "0" || this.txtTaxCode.Text.Trim() == "" || this.txtContactName.Text.Trim() == "")
        {
            this.lblMsg.Text = "Bạn chưa nhập thông tin người liên hệ";
            this.txtContactName.Focus();
            return;
        }

        if (this.ddlProvincer.SelectedValue.ToString() == "0")
        {
            this.lblMsg.Text = "Bạn chưa nhập tỉnh, thành phố của khách hàng";
            this.ddlProvincer.Focus();
            return;
        }

        if (this.ddlBusiness.SelectedValue.ToString() == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn ngành nghề kinh doanh của khách hàng";
            this.ddlBusiness.Focus();
            return;
        }

        if (this.txtUserCreate.Text.Trim() == "" || this.txtUserCreate.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người cập nhật thông tin khách hàng";
            this.txtUserCreate.Text = "0";
            this.txtUserCreateName.Focus();
            return;
        }

        if (this.txtUserManagerment.Text.Trim() == "" || this.txtUserManagerment.Text == "0")
        {
            this.lblMsg.Text = "Bạn chưa chọn người quản lý thông tin khách hàng";
            this.txtUserManagerment.Text = "0";
            this.txtUserManagermentName.Focus();
            return;
        }

        if (this.txtNumViettel.Text == "")
        {
            this.txtNumViettel.Text = "0";
        }

        if (this.txtNumViNaPhone.Text == "")
        {
            this.txtNumViNaPhone.Text = "0";
        }

        if (this.txtNumOther.Text == "")
        {
            this.txtNumOther.Text = "0";
        }

        int tmpNumber = 0;
        try
        {
            tmpNumber = int.Parse(this.txtNumViettel.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập số thuê bao Viettel";
            this.txtNumViettel.Focus();
            return;
        }

        try
        {
            tmpNumber = int.Parse(this.txtNumViNaPhone.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập số thuê bao Vinaphone";
            this.txtNumViNaPhone.Focus();
            return;
        }

        try
        {
            tmpNumber = int.Parse(this.txtNumOther.Text);
        }
        catch
        {
            this.lblMsg.Text = "Bạn chưa nhập số thuê bao khác";
            this.txtNumOther.Focus();
            return;
        }

        if (this.objCustomer.setData(this.itemId, this.txtName.Text, this.txtTaxCode.Text, 
            this.txtContactName.Text, this.txtPhone.Text, int.Parse(this.ddlProvincer.SelectedValue.ToString()), int.Parse(this.ddlDistrict.SelectedValue.ToString()), int.Parse(this.ddlWard.SelectedValue.ToString()), 
            this.txtAddress.Text, this.txtAddressBill.Text, this.txtEmail.Text, int.Parse(this.ddlBusiness.SelectedValue.ToString()), this.ddlBusiness.SelectedItem.Text, 
            int.Parse(this.ddlNumDept.SelectedValue.ToString()), int.Parse(this.ddlNumLeader.SelectedValue.ToString()), int.Parse(this.ddlNumEmp.SelectedValue.ToString()),
            int.Parse(this.txtUserCreate.Text), this.txtUserCreateName.Text, int.Parse(this.txtUserManagerment.Text), this.txtUserManagermentName.Text, this.typeCustomer, this.txtBusinessLlicense.Text, int.Parse(this.txtNumViettel.Text), int.Parse(this.txtNumViNaPhone.Text), int.Parse(this.txtNumOther.Text), this.ckbState.Checked) == 1)
        {
            if (this.itemId == 0)
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Thêm khách hàng <b><a href = \"CustomerTask.aspx?id=" + this.objCustomer.getDataId().ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            else
            {
                this.objActivity.setData(Session["FULLNAME"].ToString() + " - Cập nhật khách hàng <b><a href = \"CustomerEdit.aspx?id=" + this.itemId.ToString() + "\">" + this.txtName.Text + "</a></b>", Session["ACCOUNT"].ToString(), Session["FULLNAME"].ToString());
            }
            Response.Redirect("Customer.aspx?type=" + this.typeCustomer.ToString());
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
        Response.Redirect("Customer.aspx?type="+this.typeCustomer.ToString());
    }
    #endregion

    #region method ddlProvincer_SelectedIndexChanged
    protected void ddlProvincer_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlDistrict.DataSource = this.objDistrict.getDataCategoryToCombobox(this.ddlProvincer.SelectedValue.ToString());
        this.ddlDistrict.DataTextField = "Name";
        this.ddlDistrict.DataValueField = "Id";
        this.ddlDistrict.DataBind();
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
        }
    } 
    #endregion
}