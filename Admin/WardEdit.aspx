﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="WardEdit.aspx.cs" Inherits="Admin_WardEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mã phường, xã:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtCode" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>
    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên phường, xã:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tỉnh, thành:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlProvincer" AutoPostBack="true" runat="server" Style="width: 29.5%; height: 28px; line-height: 28px;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Quận, huyện:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" Style="width: 29.5%; height: 28px; line-height: 28px;"></asp:DropDownList>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Trạng thái: 
        </div>
        <div class="AdminRightItem">
            <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" runat="server" Style="font-weight: normal;" />
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

