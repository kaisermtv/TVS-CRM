<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Target.aspx.cs" Inherits="Admin_Target" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table class="table" border="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Tên tài khoản cần tìm" runat="server" class="form-control" />
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -18px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top:-20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 36px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 25%;">Chỉ tiêu, nhiệm vụ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 40%;">Mô tả
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Người thực hiện
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày tạo
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlTarget" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <input type="checkbox" name="ckb<%# Eval("Id") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 25%;">
                         <a href ="TargetDetail.aspx?id=<%# Eval("Id") %>"><%# Eval("Name") %></a>&nbsp;<div class="badge"><%# Eval("CountItem") %></div>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 40%;">
                        <%# Eval("Note") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 16%;">
                        <%# Eval("UserCreateName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("DayCreate","{0:dd/MM/yyyy}") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TargetEdit.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="TargetDel.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpTarget" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
     <br />
    <a href="TargetEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
</asp:Content>

