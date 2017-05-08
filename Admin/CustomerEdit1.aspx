<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CustomerEdit1.aspx.cs" Inherits="Admin_CustomerEdit1" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <ul class="nav nav-tabs" style="margin-top: -20px;">
        <li class="active"><a data-toggle="tab" href="#home">Thông tin chung</a></li>
        <li><a data-toggle="tab" href="#menu2">Thống kê thuê bao</a></li>
        <li><a data-toggle="tab" href="#menu1">Chi tiết thuê bao</a></li>
    </ul>

    <div class="tab-content">
        <div id="home" class="tab-pane fade in active">
            <div class="AdminItem" style="margin-top: 20px;">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Tên khách hàng (*):
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Địa chỉ (*):
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtAddress" runat="server" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Địa chỉ thanh toán (*):
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtAddressBill" runat="server" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Điện thoại (*):
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtPhone" runat="server" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Mã số thuế (*):
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtTaxCode" runat="server" class="AdminTextControl" Style="width: 33.2% !important;"></asp:TextBox>
                    &nbsp;&nbsp;Người liên hệ:&nbsp;
            <asp:TextBox ID="txtContactName" runat="server" class="AdminTextControl" Style="width: 38% !important;"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;GPKD:
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtBusinessLlicense" runat="server" class="AdminTextControl" Style="width: 100% !important;"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Tỉnh, thành (*):
                </div>
                <div class="AdminRightItem">
                    <asp:DropDownList ID="ddlProvincer" AutoPostBack="true" runat="server" Style="width: 33.2%; height: 28px; line-height: 28px;" OnSelectedIndexChanged="ddlProvincer_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" Style="width: 33%; height: 28px; line-height: 28px;" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddlWard" AutoPostBack="true" runat="server" Style="width: 33%; height: 28px; line-height: 28px;"></asp:DropDownList>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Địa chỉ email:
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtEmail" runat="server" class="AdminTextControl"></asp:TextBox>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Ngành nghề:
                </div>
                <div class="AdminRightItem">
                    <asp:DropDownList ID="ddlBusiness" AutoPostBack="true" runat="server" Style="width: 100%; height: 28px; line-height: 28px;"></asp:DropDownList>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Quy mô:
                </div>
                <div class="AdminRightItem">
                    <asp:DropDownList ID="ddlNumDept" AutoPostBack="true" runat="server" Style="width: 33.2%; height: 28px; line-height: 28px;">
                        <asp:ListItem Value="1">Dưới 10 cán bộ</asp:ListItem>
                        <asp:ListItem Value="2">Từ 10 đến 50 cán bộ</asp:ListItem>
                        <asp:ListItem Value="3">Trên 50 cán bộ</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlNumLeader" AutoPostBack="true" runat="server" Style="width: 33%; height: 28px; line-height: 28px;">
                        <asp:ListItem Value="1">Dưới 5 phòng ban</asp:ListItem>
                        <asp:ListItem Value="2">Từ 5 đến 10 phòng ban</asp:ListItem>
                        <asp:ListItem Value="3">Trên 10 phòng ban</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlNumEmp" AutoPostBack="true" runat="server" Style="width: 33%; height: 28px; line-height: 28px;">
                        <asp:ListItem Value="1">Dưới 5 nhân viên</asp:ListItem>
                        <asp:ListItem Value="2">Từ 5 đến 199 nhân viên</asp:ListItem>
                        <asp:ListItem Value="3">Từ 200 đến 799 nhân viên</asp:ListItem>
                        <asp:ListItem Value="4">Trên 800 nhân viên</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Người tạo:
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtUserCreateName" runat="server" class="AdminTextControl" Style="width: 33.2% !important;"></asp:TextBox>
                    <asp:TextBox ID="txtUserCreate" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
                    <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

                    &nbsp;&nbsp;Người quản lý :&nbsp;
            <asp:TextBox ID="txtUserManagermentName" runat="server" class="AdminTextControl" Style="width: 30% !important;"></asp:TextBox>
                    <asp:TextBox ID="txtUserManagerment" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
                    <button class="btn btn-primary" type="button" onclick="SelectName1()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

                </div>
            </div>

            <div class="AdminItem">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Thuê bao Viettel:
                </div>
                <div class="AdminRightItem">
                    <asp:TextBox ID="txtNumViettel" runat="server" class="AdminTextControl" Style="width: 21.5% !important;"></asp:TextBox>
                    &nbsp;&nbsp;Thuê bao Vinaphone: 
            <asp:TextBox ID="txtNumViNaPhone" runat="server" class="AdminTextControl" Style="width: 100px!important;"></asp:TextBox>
                    &nbsp;&nbsp;Thuê bao Mobifone: 
            <asp:TextBox ID="txtNumOther" runat="server" class="AdminTextControl" Style="width: 100px!important;"></asp:TextBox>
                </div>
            </div>

            <div style="width: 100%; height: 35px; line-height: 35px; margin-top: 10px;">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;Trạng thái: 
                </div>
                <div class="AdminRightItem">
                    <asp:CheckBox ID="ckbState" Text="&nbsp;&nbsp;Kích hoạt" runat="server" Style="font-weight: normal;" />
                </div>
            </div>

            <div class="AdminItem" style="height: 26px; margin-top: -8px;">
                <div class="AdminLeftItem">
                    &nbsp;&nbsp;
                </div>
                <div class="AdminRightItem">
                    <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>

            <div class="AdminItem">
                <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
            </div>

        </div>

        <div id="menu2" class="tab-pane fade">
            <div style="margin-top: 20px;">
                <div style="width: 100%;">

                    <div class="AdminItem" style="margin-top: 20px;">
                        <div class="AdminLeftItem">
                            &nbsp;&nbsp;Thuê bao trả trước:
                        </div>
                        <div class="AdminRightItem">
                            <asp:TextBox ID="txtTBTT" runat="server" class="AdminTextControl"></asp:TextBox>
                        </div>
                    </div>

                    <div class="AdminItem">
                        <div class="AdminLeftItem">
                            &nbsp;&nbsp;Thuê bao trả sau:
                        </div>
                        <div class="AdminRightItem">
                            <asp:TextBox ID="txtTBTS" runat="server" class="AdminTextControl"></asp:TextBox>
                        </div>
                    </div>

                    <div class="AdminItem">
                        <div class="AdminLeftItem">
                            &nbsp;&nbsp;TB chặn 2 chiều:
                        </div>
                        <div class="AdminRightItem">
                            <asp:TextBox ID="txtC2C" runat="server" class="AdminTextControl"></asp:TextBox>
                        </div>
                    </div>

                    <div class="AdminItem">
                        <div class="AdminLeftItem">
                            &nbsp;&nbsp;TB chặn 1 chiều:
                        </div>
                        <div class="AdminRightItem">
                            <asp:TextBox ID="txtC1C" runat="server" class="AdminTextControl"></asp:TextBox>
                        </div>
                    </div>

                    <div class="AdminItem">
                        <div class="AdminLeftItem">
                            &nbsp;&nbsp;Số lượng MBU:
                        </div>
                        <div class="AdminRightItem">
                            <asp:TextBox ID="txtSLMBU" runat="server" class="AdminTextControl"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div id="menu1" class="tab-pane fade">
            <div style="margin-top: 20px;">
                <div style="width: 100%;">
                    <table class="DataListTableHeader" border="0">
                        <tr style="height: 30px;">
                            <td class="DataListTableHeaderTdItemCenter" style="width: 4%;">TT
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Mã thuê bao
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Số thuê bao
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 16%;">Tên thuê bao
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Tỉnh, thành
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">Trả trước(Sau)
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 15%;">TT Chặn, cắt
                            </td>
                            <td class="DataListTableHeaderTdItemJustify">TT Hoạt động
                            </td>
                            <td class="DataListTableHeaderTdItemJustify" style="width: 10%;">Ngày ĐK_MBU
                            </td>
                        </tr>
                    </table>
                </div>

                <asp:DataList ID="dtlContact" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                    Width="100%">
                    <ItemTemplate>
                        <table class="DataListTable" border="0">
                            <tr style="height: 30px;">
                                <td class="DataListTableTdItemCenter" style="width: 4%;">
                                    <%# Eval("TT") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 10%;">
                                    <%# Eval("SUB_ID") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 10%;">
                                    <%# Eval("ISDN") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 16%;">
                                    <%# Eval("Name") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 10%;">
                                    <%# Eval("PROVINCE") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 15%;">
                                    <%# Eval("IS_FONE") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 15%;">
                                    <%# Eval("STATUS") %>
                                </td>
                                <td class="DataListTableTdItemJustify">
                                    <%# Eval("ACT_STATUS") %>
                                </td>
                                <td class="DataListTableTdItemJustify" style="width: 10%;">
                                    <%# Eval("NGAYDK_MB") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <table width="100%" cellpadding="0" cellspacing="0" border="0" style="margin-top: 5px; height: 26px;"
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
        </div>

    </div>

    <script type="text/javascript">
        function SelectName() {

            var w = 800;
            var h = 500;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChooseAccount.aspx", "CHỌN NGƯỜI DÙNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function SelectName1() {

            var w = 800;
            var h = 500;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChooseAccount1.aspx", "CHỌN NGƯỜI DÙNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function ViewInformation() {

            var CodeConnect = document.getElementById("MainContent_txtCodeConnect").value;

            if (CodeConnect != '') {
                var w = 1000;
                var h = 600;

                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                var newWindow = window.open("InformationConnect.aspx?id=" + CodeConnect, "THÔNG TIN KHÁCH HÀNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                if (window.focus) {
                    newWindow.focus();
                }
            }
        }
    </script>

</asp:Content>

