<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseContact2.aspx.cs" Inherits="Admin_ChooseContact2" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CHỌN DANH BẠ</title>
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
<body style="margin: 0px !important; height: 500px !important;">
    <form id="form1" runat="server">
        <table class="table" border="0">
            <tr>
                <td>
                    <input type="text" id="txtSearch" placeholder="Tên tài khoản cần tìm" runat="server" class="form-control" />
                </td>
                <td style="width: 40px !important; text-align: center;">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -18px; margin-left: -15px;" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>

        <div style ="margin-top:-20px;">
            Click vào thông tin họ, tên để chọn
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 36px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 31%;">Họ, tên
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 31%;">Điện thoại
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 20%;">Địa chỉ Email
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Trạng thái
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
                            <td class="DataListTableTdItemJustify" style="width: 31%;">
                                <a href="#" onclick="return SetName('<%# Eval("Id") %>','<%# Eval("Name") %>','<%# Eval("Phone") %>');"><%# Eval("Name") %></a>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 31%;">
                                <%# Eval("Phone") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 20%;">
                                <%# Eval("Email") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 15%;">
                                <%# Eval("StateName") %>
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

        </div>
        <script type="text/javascript">
            function SetName(value1, value2, value3) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtUserCreate");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtUserCreateName");
                    txtName.value = value2;

                    var txtContactPhone = window.opener.document.getElementById("MainContent_txtContactPhone");
                    txtContactPhone.value = value3;
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
