<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="RepTakeCareCustomerGeneral.aspx.cs" Inherits="Report_RepTakeCareCustomer" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });

        $(function () {
            $('#datetimepicker2').datetimepicker({
                format: 'DD/MM/YYYY'
            });
        });
    </script>
    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td style="height: 36px; line-height: 36px; width: 80px;">Từ ngày :
            </td>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker1' style="margin-left: 0px; width: 100% !important;">
                    <input type='text' class="form-control" id="txtDayBegin" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker1').datetimepicker();
                    });
                </script>
            </td>
            <td style="height: 36px; line-height: 36px; width: 90px;">Đến ngày :
            </td>
            <td style="width: 180px;">
                <div class='input-group date' id='datetimepicker2' style="margin-left: 0px; width: 100% !important;">
                    <input type='text' class="form-control" id="txtDayEnd" runat="server" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>

                <script type="text/javascript">
                    $(function () {
                        $('#datetimepicker2').datetimepicker();
                    });
                </script>
            </td>
            <td>
                <asp:DropDownList ID="ddlProvincer" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -18px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <div style="width: 100%; margin-top: -20px;">
        <table class="DataListTableHeader" border="0">
            <tr style="height: 36px;">
                <td class="DataListTableHeaderTdItemJustify"style ="width:55%;">Họ và tên
                </td>
                <td class="DataListTableHeaderTdItemCenter"style ="width:15%;">K.H Tiền năng
                </td>
                <td class="DataListTableHeaderTdItemCenter"style ="width:15%;">K.H Hiện hữu
                </td>
                <td class="DataListTableHeaderTdItemCenter"style ="width:15%;">Tổng
                </td>
            </tr>
        </table>
    </div>

    <asp:DataList ID="dtlCustomer" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
        Width="100%">
        <ItemTemplate>
            <table class="DataListTable" border="1" style ="border-color:#ff00dc;">
                <tr style="height: 36px;">
                    <td class="DataListTableTdItemJustify"style ="width:55%; border-right:0px;border-color:#ff00dc;">
                        <%# Eval("FullName")%>
                    </td>
                    <td class="DataListTableTdItemCenter" style ="width:15%; border-left:0px; border-right:0px;border-color:#ff00dc;">
                        <%# Eval("Total1") %>
                    </td>
                    <td class="DataListTableTdItemCenter" style ="width:15%; border-left:0px; border-right:0px;border-color:#ff00dc;">
                        <%# Eval("Total2") %>
                    </td>
                    <td class="DataListTableTdItemCenter"style ="width:15%; border-left:0px;border-color:#ff00dc;">
                        <%# Eval("Total") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpCustomer" runat="server" BackText="<<" FirstText="Đầu" ControlCssClass="ProductPage" LabelText="" NextText=">>" UseSlider="true" ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="Split"
                    PageNumbersSeparator="&nbsp;" SliderSize="80">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnExportToExcel" runat="server" class="btn btn-primary" Text="Xuất file Excel" OnClick="btnExportToExcel_Click" />
</asp:Content>

