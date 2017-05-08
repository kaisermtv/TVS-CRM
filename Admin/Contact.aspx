<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Admin_Contact" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   <table class="table" border="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <input type="text" id="txtSearch" placeholder="Tên danh bạ, điện thoại, địa chỉ email cần tìm" runat="server" class="form-control" />
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
                <td class="DataListTableHeaderTdItemJustify" style="width: 25%;">Họ, tên
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 36%;">Điện thoại
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Địa chỉ Email
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlContact" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <%# Eval("TT") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 25%;">
                        <%# Eval("Name") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 36%;">
                        <%# Eval("Phone") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 20%;">
                        <%# Eval("Email") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="ContactEdit.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="ContactDel.aspx?id=<%# Eval("Id") %>">
                            <img src="../Images/delete.png" alt=""></a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpContact" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnExportToExcel" runat="server" class="btn btn-primary" Text="Xuất file Excel" OnClick="btnExportToExcel_Click" />
    <a href="ContactEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>

</asp:Content>

