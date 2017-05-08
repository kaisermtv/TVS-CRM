<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseCustomer.aspx.cs" Inherits="Admin_ChooseCustomer" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN KHÁCH HÀNG</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../css/Adminstyle.css" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
</head>
<body style="margin: 0px !important; padding:10px; " onload="CloseForm()">
    <form id="form1" runat="server">
        <table class="table" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Nhập tên hoặc mã doanh nghiệp" runat="server" class="form-control" />
                </td>
                <td>
                    <input type="text" id="txtAM" placeholder="Người quản lý" runat="server" class="form-control" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlProvincer" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDistrict" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlWard" CssClass="form-control" AutoPostBack="true" runat="server" Style="width: 100%;"></asp:DropDownList>
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -18px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <div style="margin-top: -20px;">
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 36px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 42%;">Khách hàng
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Điện thoại
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tỉnh, thành
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Người liên hệ
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 15%;">Người quản lý
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
                            <td class="DataListTableTdItemJustify" style="width: 42%;">
                                <a href="#" onclick="return SetName('<%# Eval("Id") %>','<%# Eval("Name") %>');"><%# Eval("Name") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 15%;">
                                <%# Eval("Phone") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 10%;">
                                <%# Eval("ProvincerName") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 15%;">
                                <%# Eval("ContactName") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 15%;">
                                <%# Eval("FullName") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 15px; height: 26px;"
                id="tblABC" runat="server">
                <tr>
                    <td style="padding-left: 6px;">
                        <cc1:CollectionPager ID="cpCustomer" runat="server" BackText="" FirstText="Đầu"
                            ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
                            ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
                            PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </td>
                </tr>
            </table>

        </div>
        <br />
        <input type="hidden" id="saved" name="saved" runat="server" value="" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClientClick="CloseForm()" OnClick="btnSave_Click" />
        &nbsp;
        <input type="text" value="Đóng" class="btn btn-default" style="width: 60px !important;" onclick="window.close();" />
        <script type="text/javascript">
            function CloseForm() {
                var saved = document.getElementById('saved').value;
                if (saved != '') {
                    window.opener.location.reload(true);
                    window.close();
                }
            }

            function SetName(value1, value2) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtUserCreate");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtUserCreateName");
                    txtName.value = value2;
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
