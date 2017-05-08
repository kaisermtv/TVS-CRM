<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CustomerTask.aspx.cs" Inherits="Admin_CustomerTask" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-body"><b><% Response.Write(this.strHtmlName); %></b></div>
        <div class="panel-body" style="margin-top: -20px;">
            <table class="table" style ="margin-top:-15px; font-size:16px; margin-bottom:-10px;" border ="0">
                <tbody>
                    <tr style ="height:20px !important;">
                        <td colspan = "2" style ="padding-bottom:0px;">Địa chỉ: <% Response.Write(this.strHtmlAddress); %>
                        </td>
                        <td style ="padding-bottom:0px;">Điện thoại: <% Response.Write(this.strHtmlPhone); %>
                        </td>
                    </tr>
                    <tr style ="height:20px !important;">
                        <td>Tỉnh, thành: <% Response.Write(this.strHtmlProvincerName); %>
                        </td>
                        <td>Huyện: <% Response.Write(this.strHtmlDistrictName); %>
                        </td>
                        <td>GPKD: <% Response.Write(this.strHtmlTaxCode); %>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminLeftItem">
            CÔNG VIỆC
        </div>
    </div>

    <div style="width: 100%;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 36px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 45%;">Chủ đề công việc
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 14%;">Trạng thái
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Người liên hệ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Thời hạn cuối
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 6%;">&nbsp;
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlCustomerTask" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <input type="checkbox" name="ckb<%# Eval("Id") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 45%;">
                        <%# Eval("Name") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 14%;">
                        <%# Eval("StateName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 16%;">
                        <%# Eval("ContactName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 16%;">
                        <%# Eval("DayEnd") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="CustomerTaskEdit.aspx?id=<%# Eval("Id") %>&cid=<%# Eval("CustomerId") %>">
                            <img src="../Images/Edit.png" alt=""></a>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 3%;">
                        <a href="CustomerTaskDel.aspx?id=<%# Eval("Id") %>">
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
                <cc1:CollectionPager ID="cpCustomerTask" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Khởi tạo công việc" OnClick="btnAdd_Click" />
</asp:Content>

