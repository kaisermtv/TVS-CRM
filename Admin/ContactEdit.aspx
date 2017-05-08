<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ContactEdit.aspx.cs" Inherits="Admin_ContactEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên gọi:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Điện thoại:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPhone" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Đơn vị:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtCompanyName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Chức vụ:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtPossition" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Phòng ban:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtDepartment" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Địa chỉ Email:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtEmail" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Người tạo:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserCreateName" runat="server" class="AdminTextControl" Style="width: 90% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserCreate" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility:hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Người quản lý:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserManagermentName" runat="server" class="AdminTextControl" Style="width: 90% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserManagerment" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility:hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName1()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>
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
            var newWindow = window.open("ChooseContact.aspx", "CHỌN DANH BẠ", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

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
            var newWindow = window.open("ChooseContact1.aspx", "CHỌN DANH BẠ", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }
    </script>

</asp:Content>

