<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="TargetDetail.aspx.cs" Inherits="Admin_TargetDetail" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <div class="panel-body"><% Response.Write(this.strHtmlName); %></div>
        <div class="panel-body" style ="margin-top:-15px;"><% Response.Write(this.strHtmlTime); %></div>
    </div>

    <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px;">
        <div class="AdminItem1">
            Danh sách khách hàng
        </div>
        <div class="AdminItem2">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" id = "btnAdd" runat ="server" onclick="SelectName()"/>
        </div>
    </div>

    <div style="width: 100%;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 36px;">
                <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 31%;">Khách hàng
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Điện thoại
                </td>
                 <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Người liên hệ
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 11%;">Tỉnh, thành
                </td>
                <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Người quản lý
                </td>
                <td class="DataListTableHeaderTdItemCenter" style="width: 10%;">Ngày giao
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlCustomer" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="0">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemTT" style="width: 3%;">
                        <input type="checkbox" name="ckb<%# Eval("Id") %>" />
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 31%;">
                        <a href="CustomerTask.aspx?id=<%# Eval("Id") %>&type=<%# Eval("TypeId") %>"><%# Eval("Name") %></a>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("Phone") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("ContactName") %>
                    </td>
                     <td class="DataListTableTdItemJustify" style="width: 11%;">
                        <%# Eval("ProvincerName") %>
                    </td>
                    <td class="DataListTableTdItemJustify" style="width: 15%;">
                        <%# Eval("UserManagermentName") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style="width: 10%;">
                        <%# Eval("DayCreate","{0:dd/MM/yyyy}") %>
                    </td>                   
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:collectionpager id="cpCustomer" runat="server" backtext="" firsttext="Đầu"
                    controlcssclass="ProductPage" labeltext="" lasttext="Cuối" nexttext="" useslider="true"
                    resultsformat="" backnextlinkseparator="" resultslocation="None" backnextlocation="None"
                    pagenumbersseparator="&nbsp;">
                </cc1:collectionpager>
            </td>
        </tr>
    </table>

    <input type ="hidden" id = "targetId" name = "targetId" runat ="server" value ="0"/>

    <script type="text/javascript">
        function SelectName() {

            var w = 1000;
            var h = 600;
            var targetId = document.getElementById('MainContent_targetId').value;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChooseCustomer.aspx?id=" + targetId, "CHỌN KHÁCH HÀNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

    </script>

</asp:Content>

