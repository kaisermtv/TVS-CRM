﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ContactDel : System.Web.UI.Page
{
    #region declare objects
    private Account objAccount = new Account();
    private Contact objContact = new Contact();
    public int itemId = 0;
    public string strHtmlTitle = "";
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 4, ref View, ref Add, ref Edit, ref Del, ref Orther))
        {
            Response.Redirect("NoPermission.aspx");
        }
        try
        {
            this.itemId = int.Parse(Request["Id"].ToString());
        }
        catch
        {
            this.itemId = 0;
        }
        if (!this.objContact.checkForUserCreateContact(this.itemId, Session["ACCOUNT"].ToString()))
        {
            this.btnSave.Enabled = false;
            this.strHtmlTitle = "Bạn không có quyền xóa nội dung này!";
        }
        else
        {
            this.strHtmlTitle = "Bạn có chắc chắn muốn xóa mục được chọn không?";
        }
        Session["TITLE"] = "XÓA DANH BẠ";
    }
    #endregion

    #region method btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        this.objContact.delData(this.itemId);
        Response.Redirect("Contact.aspx");
    }
    #endregion

    #region method btnCancel_Click
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Contact.aspx");
    }
    #endregion
}