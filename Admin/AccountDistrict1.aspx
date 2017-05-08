<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountDistrict1.aspx.cs" Inherits="Admin_AccountDistrict1" %>

<!DOCTYPE html>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TVS CRM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/TVSStyle.css" rel="stylesheet" />
    <link href="../css/Adminstyle.css" type="text/css" rel="stylesheet" />

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- Bootstrap Core CSS -->
    <link href="../Admin/css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="../Admin/css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="../Admin/css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->

    <link href="../Admin/css/primeui.css" rel="stylesheet" />
    <link href="../Admin/css/theme.css" rel="stylesheet" />


    <!-- lined-icons -->
    <link href="../Admin/css/icon-font.min.css" rel="stylesheet" type='text/css' />
    <!-- //lined-icons -->
    <!-- chart -->
    <script src="../Admin/js/Chart.js"></script>
    <!-- //chart -->
    <!--animate-->
    <link href="../Admin/css/animate.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../Admin/js/wow.min.js"></script>
    <script>
        new WOW().init();
    </script>
    <!--//end-animate-->
    <!----webfonts--->
    <link href='../Admin/css/fonts-googleapis.css' rel='stylesheet' type='text/css' />
    <!---//webfonts--->
    <!-- Meters graphs -->
    <script src="../Admin/js/jquery-1.10.2.min.js"></script>
    <!-- Placed js at the end of the document so the pages load faster -->

    <!-- DateTime Picker -->
    <link rel="stylesheet" type="text/css" media="screen" href="../Content/bootstrap.min.css" />
    <link href="../Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../Scripts/moment-with-locales.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.js"></script>
    <!-- -->
    <style>
        .main-content {
            min-height: 0px !important;
        }

        .main-content2copy {
            min-height: 0px !important;
        }
    </style>
</head>
<body style="height: 600px;">
    <form id="form1" runat="server">
        <div>
            <div style="width: 100%;">
                <table class="DataListTableHeader" border="0">
                    <tr style="height: 36px;">
                        <td class="DataListTableHeaderTdItemTT" style="width: 3%;">#
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 12%;">Mã huyện
                        </td>
                        <td class="DataListTableHeaderTdItemJustify" style="width: 80%;">Tên huyện
                        </td>
                        <td class="DataListTableHeaderTdItemCenter" style="width: 5%;">Xóa
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
                            <td class="DataListTableTdItemJustify" style="width: 12%;">
                                <%# Eval("Code") %>
                            </td>
                            <td class="DataListTableTdItemJustify" style="width: 80%;">
                                <%# Eval("Name") %>
                            </td>
                            <td class="DataListTableTdItemCenter" style="width: 5%;">
                                <a href="?acc=<%= this.curr_UserName %>&pro=<%=this.providerId %>&id=<%# Eval("Id") %>">
                                    <img src="../Images/delete.png" alt=""></a>
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
        </div>
    </form>
</body>
</html>
