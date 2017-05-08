<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="RepChiTietThueBao.aspx.cs" Inherits="Report_RepChiTietThueBao" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <style>
        table {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
            border: 1px solid #ddd;
        }

        th, td {
            border: none;
            text-align: left;
            padding: 8px;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>

    <asp:Repeater ID="dtlCustomer" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div class="table-responsive" <%--style="max-height:500px"--%>>
                <table style="min-width:2000px">
                    <tr class="DataListTableHeader">
<%--                        <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                        <th class="DataListTableHeaderTdItemJustify">Tài khoản</th>
                        <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                        <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>--%>

                        <th>STT</th>
                        <th>Mã DN</th>
                        <th>Mã KH</th>
                        <th>ISDN</th>
                        <th>Tên KH</th>
                        <th>Địa chỉ thanh toán</th>
                        <th>GPKD</th>
                        <th>MST</th>
                        <th>Cước PS</th>
                        <th>Tỉnh, TP</th>
                        <th>Quận, Huyện</th>
                        <th>Phường, Xã</th>
                        <th>Ngày nhập/tách khỏi DN</th>
                        <th>Ghi chú</th>
                        <th>TTTB</th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("MAKHACHHANG") %>&nbsp;</td>
                <td><%#Eval("MAKHACHHANG") %>&nbsp;</td>
                <td><%#Eval("MAKHACHHANG") %>&nbsp;</td>
                <td><%#Eval("MAKHACHHANG") %>&nbsp;</td>
                <td><%#Eval("TENKHACHHANG") %>&nbsp</td>
                <td><%#Eval("DIACHITHANHTOAN") %>&nbsp;</td>
                <td><%#Eval("GPKD") %>&nbsp;</td>
                <td><%#Eval("MST") %>&nbsp;</td>
                <td><%#Eval("TINHTHANHPHO") %>&nbsp;</td>
                <td><%#Eval("QUANHUYEN") %>&nbsp;</td>
                <td><%#Eval("PHUONGXA") %>&nbsp;</td>
                <td>1</td>
                <td>2</td>
                <td>3</td>
                <td>4</td>
                <td>5</td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
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
</asp:Content>

