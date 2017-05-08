<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Admin_Customer" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <table class="table" border="0" style="margin-top: -20px;">
        <tr>
            <td style="width: 350px;">
                <input type="text" id="txtSearch" placeholder="Tên, GPKD, Người liên hệ của doanh nghiệp" runat="server" class="form-control" />
            </td>
            <td>
                <asp:DropDownList ID="ddlNumEmp" CssClass="form-control" runat="server">
                    <asp:ListItem Value="0">Tìm theo số nhân viên</asp:ListItem>
                    <asp:ListItem Value="1">Dưới 5 nhân viên</asp:ListItem>
                    <asp:ListItem Value="2">Từ 5 đến 199 nhân viên</asp:ListItem>
                    <asp:ListItem Value="3">Từ 200 đến 799 nhân viên</asp:ListItem>
                    <asp:ListItem Value="4">Trên 800 nhân viên</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlBusiness" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlBusiness_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlProvincer" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlDistrict" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlWard" CssClass="form-control" runat="server" Style="width: 100%;"></asp:DropDownList>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -18px; margin-left: -15px;" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <asp:Repeater ID="dtlCustomer" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <div id="tblfilter" class="ui-datatable ui-widget table-responsive" style="margin-top: -20px;">
                <div class="ui-datatable-tablewrapper">
                    <table>
                        <thead>
                            <tr class="ui-state-default">
                                <th class="ui-state-default" id="ui-id-1" style="width: 35px!important;"><span class="ui-column-title">#</span></th>
                                <th class="ui-state-default" id="ui-id-2"><span class="ui-column-title">Khách hàng</span></th>
                                <th class="ui-state-default" id="ui-id-3" style="width: 55px!important;"><span class="ui-column-title">TSTB</span></th>
                                <th class="ui-state-default" id="ui-id-4" style="width: 100px!important;"><span class="ui-column-title">GPKD</span></th>
                                <th class="ui-state-default" id="ui-id-5" style="width: 120px!important;"><span class="ui-column-title">Mã số thuế</span></th>
                                <th class="ui-state-default" id="ui-id-6" style="width: 100px!important;"><span class="ui-column-title">Tỉnh, thành</span></th>
                                <th class="ui-state-default" id="ui-id-7"><span class="ui-column-title">Địa chỉ</span></th>
                                <th class="ui-state-default" id="ui-id-8" style="width: 140px!important;"><span class="ui-column-title">Người quản lý</span></th>
                                <th class="ui-state-default" id="ui-id-9" style="width: 43px!important;"><span class="ui-column-title">&nbsp;</span></th>
                            </tr>
                        </thead>
                        <tbody class="ui-datatable-data ui-widget-content">
        </HeaderTemplate>
        <ItemTemplate>
            <% index++; %>
            <tr class="ui-widget-content <% =(index%2).ToString().Replace("0","ui-datatable-even").Replace("1","ui-datatable-odd") %> ">
                <td>
                    <input type="checkbox" name="ckb<%# Eval("Id") %>" /></td>
                <td style="text-align: justify;"><a href="CustomerTask.aspx?id=<%# Eval("Id") %>&type=<%# Eval("TypeId") %>"><%# Eval("Name") %></a></td>
                <td style="text-align: right;"><%# Eval("SoThueBao") %></td>
                <td><%# Eval("BusinessLlicense") %></td>
                <td><%# Eval("TaxCode") %></td>
                <td><%# Eval("ProvincerName") %></td>
                <td style="text-align: justify;"><%# Eval("Address") %></td>
                <td><%# Eval("FullName") %></td>
                <td style="width: 43px!important;"><a href="CustomerEdit<%Response.Write(this.typeCustomer.ToString().Replace("1", "").Replace("2", "").Replace("3", "1")); %>.aspx?id=<%# Eval("Id") %>&type=<%# Eval("TypeId") %>">
                    <img src="../Images/Edit.png" alt="" style="margin-right: 10px!important;"></a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                </table>
            </div>
        </div>
        </FooterTemplate>
    </asp:Repeater>
    Tổng số khách hàng: <% Response.Write(String.Format("{0:0,0}", double.Parse(this.objTable.Rows.Count.ToString()))); %>
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 10px; height: 26px;"
        id="tblABC" runat="server">
        <tr>
            <td>
                <cc1:CollectionPager ID="cpCustomer" runat="server" BackText="<<" FirstText="Đầu" ControlCssClass="ProductPage" LabelText="" NextText=">>" UseSlider="true" ResultsFormat="" BackNextLinkSeparator="&amp;nbsp;" ResultsLocation="None" BackNextLocation="Split"
                    PageNumbersSeparator="&nbsp;" SliderSize="80" ShowFirstLast="True" BackNextStyle="&lt;&lt;" LastText="Cuối" ShowLabel="True" PagingMode="PostBack">
                </cc1:CollectionPager>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnExportToExcel" runat="server" class="btn btn-primary" Text="Xuất file Excel" OnClick="btnExportToExcel_Click" />
    <a href="CustomerEdit.aspx">
        <input type="text" value="Thêm mới" class="btn btn-primary" style="width: 90px !important;" /></a>
    <asp:Button ID="btnForward" runat="server" CssClass="btn btn-primary" Text="Chuyển khách hàng" OnClick="btnForward_Click" />
    <label class="radio-inline">
        <input type="checkbox" name="optradio" value="3" id="rdbType3" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;<% Response.Write(this.strCheckBoxTitle); %></label>
</asp:Content>

