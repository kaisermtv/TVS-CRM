<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AccountDistrict.aspx.cs" Inherits="Admin_AccountDistrict" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminLeftItem">
            QUẬN, HUYỆN
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlProvincer" AutoPostBack="true" CssClass="form-control" runat="server" Style="width: 29.5%; float: left; margin-right: 10px;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="width: 35% !important; float: left; margin-right: 10px;"></asp:TextBox>
            <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -8px; margin-right: 20px;" OnClick="btnSearch_Click" />
            <input type="button" class="btn btn-primary" value="Danh sách huyện đã quản lý" onclick ="OpenForm()" />
        </div>
    </div>
    <b>Danh sách huyện chưa quản lý</b>
    <div style="width: 100%;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 36px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Mã huyện
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 62%;">Tên huyện
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số xã
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái
                </td>
            </tr>
        </table>
    </div>
    <asp:DataList ID="dtlDistrict" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <input type="checkbox" name="ckb<%# Eval("Id") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("Code") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 62%;">
                        <%# Eval("Name") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("CountItem") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 10%;">
                        <%# Eval("StateName") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpDistrict" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Chấp nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Bỏ qua" CssClass="btn btn-default" OnClick="btnCancel_Click" />

    <input type="hidden" id="txtUserName" runat="server" />
    <input type="hidden" id="txtProId" runat="server" />

    <script type="text/javascript">

        function OpenForm() {

            var txtUserName = document.getElementById("MainContent_txtUserName").value;
            var txtProId = document.getElementById("MainContent_txtProId").value;

            if (txtUserName != "") {

                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("AccountDistrict1.aspx?acc=" + txtUserName + "&pro=" + txtProId, "THÔNG TIN QUẢN LÝ", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }
    </script>

</asp:Content>

