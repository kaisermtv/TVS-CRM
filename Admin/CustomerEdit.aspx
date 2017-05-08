<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CustomerEdit.aspx.cs" Inherits="Admin_CustomerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên khách hàng(*):
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Địa chỉ(*):
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtAddress" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Điện thoại(*):
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPhone" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mã số thuế(*):
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtTaxCode" runat="server" class="AdminTextControl" style = "width:33.2% !important;"></asp:TextBox>
            &nbsp;&nbsp;Người liên hệ (*):&nbsp;
            <asp:TextBox ID="txtContactName" runat="server" class="AdminTextControl" style = "width:38% !important;"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tỉnh, thành(*):
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
                <asp:ListItem Value ="1">Dưới 10 cán bộ</asp:ListItem> 
                <asp:ListItem Value ="2">Từ 10 đến 50 cán bộ</asp:ListItem> 
                <asp:ListItem Value ="3">Trên 50 cán bộ</asp:ListItem> 
            </asp:DropDownList>
            <asp:DropDownList ID="ddlNumLeader" AutoPostBack="true" runat="server" Style="width: 33%; height: 28px; line-height: 28px;">
                <asp:ListItem Value = "1">Dưới 5 phòng ban</asp:ListItem>
                <asp:ListItem Value = "2">Từ 5 đến 10 phòng ban</asp:ListItem>
                <asp:ListItem Value = "3">Trên 10 phòng ban</asp:ListItem>
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
            <asp:TextBox ID="txtUserCreate" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility:hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

             &nbsp;&nbsp;Người quản lý :&nbsp;
            <asp:TextBox ID="txtUserManagermentName" runat="server" class="AdminTextControl" Style="width: 30% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserManagerment" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility:hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName1()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mã đấu nối:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtCodeConnect" runat="server" class="AdminTextControl" Style="width: 21.5% !important;"></asp:TextBox>
            <button class="btn btn-primary" type="button" runat ="server" onclick="ViewInformation()" id = "btnCodeConnect" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important; margin-left:12px;">Xem thông tin</button>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Thuê bao Viettel:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtNumViettel" runat="server" class="AdminTextControl" Style ="width: 21.5% !important;"></asp:TextBox>
            &nbsp;&nbsp;Thuê bao Vinaphone: 
            <asp:TextBox ID="txtNumViNaPhone" runat="server" class="AdminTextControl" Style ="width:100px!important;"></asp:TextBox>
            &nbsp;&nbsp;Thuê bao Mobifone: 
            <asp:TextBox ID="txtNumOther" runat="server" class="AdminTextControl" Style ="width:100px!important;"></asp:TextBox>
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

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;
        </div>
        <div class="AdminRightItem">
            <asp:Button ID="btnSave" runat="server" Text="Ghi nhận" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Thoát" CssClass="btn btn-default" OnClick="btnCancel_Click" />
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

