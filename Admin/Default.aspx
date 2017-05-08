<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table  id="mytable" class="table table-bordred table-striped" border="0" style="width: 100%; margin-top:-20px;">
        <thead>
            <th style ="padding:8px!important;padding-left:0px!important;">Công việc</th>
            <th style ="padding:8px!important;">Thời gian</th>
        </thead>
        <asp:Repeater ID="dtlActivity" runat="server">
            <ItemTemplate>
                <tbody>
                    <tr style="height:30px;">
                        <td style ="padding:8px!important; padding-left:0px!important;">
                            <%# Eval("ActivityContent") %>
                        </td>
                        <td style="width:150px; padding:8px!important; padding-right:0px!important;">
                            <%# Eval("DayCreate") %>
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; background-color: #fbf4f4; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td style="padding-left: 6px;">
                <cc1:CollectionPager ID="cpActivity" runat="server" BackText="" FirstText="Đầu"
                    ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                    ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                    PageNumbersSeparator="&nbsp;">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
</asp:Content>

