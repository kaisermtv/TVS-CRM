<%@ Page Title="XÓA DANH BẠ" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ContactDel.aspx.cs" Inherits="Admin_ContactDel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <br />
        <div style="text-align: center; font-weight: bold;">
            <% Response.Write(this.strHtmlTitle); %>
                <br />
            &nbsp;
            <br />
            <br />
            <asp:Button CssClass="btn btn-danger" runat="server" Text="Đồng ý xóa" ID="btnSave" OnClick="btnSave_Click" />
            &nbsp;
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Bỏ qua" ID="btnCancel" OnClick="btnCancel_Click" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>

