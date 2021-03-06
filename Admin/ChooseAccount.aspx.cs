﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChooseAccount : System.Web.UI.Page
{
    #region declare objects
    private DataTable objTable = new DataTable();
    private Account objAccount = new Account();
    private Contact objContact = new Contact();
    private SearchConfig objSearchConfig = new SearchConfig();
    private int currPage = 0;
    private bool View = false, Add = false, Edit = false, Del = false, Orther = false;
    #endregion

    #region method Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ACCOUNT"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        //if (!this.objAccount.checkForFunction(Session["ACCOUNT"].ToString(), 3, ref View, ref Add, ref Edit, ref Del, ref Orther))
        //{
        //    Response.Redirect("NoPermission.aspx");
        //}
        if (!Page.IsPostBack)
        {
            this.txtSearch.Value = this.objSearchConfig.getData(Session["ACCOUNT"].ToString(), "tblContact", "Name");
            this.getData();
        }
    }
    #endregion

    #region getData()
    private void getData()
    {
        this.objTable = this.objAccount.getDataByProvincer(this.txtSearch.Value, Session["ACCOUNT"].ToString());
        cpContact.MaxPages = 1000;
        cpContact.PageSize = 12;
        cpContact.DataSource = this.objTable.DefaultView;
        cpContact.BindToControl = dtlContact;
        dtlContact.DataSource = cpContact.DataSourcePaged;
        dtlContact.DataBind();
        if (this.objTable.Rows.Count < 12)
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
        this.objSearchConfig.setData(Session["ACCOUNT"].ToString(), "tblAccount", "Name", this.txtSearch.Value.Trim());
        #endregion
    }
    #endregion
}