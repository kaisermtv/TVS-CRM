<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InformationConnect.aspx.cs" Inherits="Admin_InformationConnect" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>THÔNG TIN KHÁCH HÀNG</title>
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
        <div>
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 36px;">
                        <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Số thuê bao
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 13%;">Tỉnh
                        </td>
                        <td class="DataListTableHeaderTdItemCenter">GPKD
                        </td>
                    </tr>
                </table>
            </div>

            <asp:DataList ID="dtlContact" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                Width="100%">
                <ItemTemplate>
                    <table class="DataListTable" border="0">
                        <tr style="height: 36px;">
                            <td class="DataListTableTdItemCenter" style="width: 16%;">
                                <%# Eval("ISDN") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 13%;">
                                <%# Eval("PROVINCE") %>
                            </td>
                            <td class="DataListTableTdItemCenter">
                                <%# Eval("BUS_NO") %>
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
