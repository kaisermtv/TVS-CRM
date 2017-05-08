<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChooseContact1.aspx.cs" Inherits="Admin_ChooseContact1" %>

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
<body style ="margin:0px !important; height:500px !important;">
    <form id="form1" runat="server">
        <div style="width: 100%; height: 35px; line-height: 35px; margin-bottom: 10px; margin-top: 20px;">
            <div class="AdminLeftItem">
                DANH BẠ
            </div>
            <div class="AdminRightItem">
                <asp:TextBox ID="txtSearch" runat="server" Style="width: 35% !important; height: 28px; line-height: 28px;"></asp:TextBox>
                <asp:ImageButton ID="btnSearch" ImageUrl="../images/Search.png" runat="server" Style="margin-bottom: -8px;" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div>
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
                                <a href="#" onclick="return SetName('<%# Eval("Id") %>','<%# Eval("Name") %>');"><%# Eval("Name") %></a>
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
            function SetName(value1, value2) {
                if (window.opener != null && !window.opener.closed) {
                    var txtNameId = window.opener.document.getElementById("MainContent_txtUserManagerment");
                    txtNameId.value = value1;

                    var txtName = window.opener.document.getElementById("MainContent_txtUserManagermentName");
                    txtName.value = value2;
                }
                window.close();
            }
        </script>
    </form>
</body>
</html>
