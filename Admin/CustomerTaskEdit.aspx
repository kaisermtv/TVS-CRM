<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CustomerTaskEdit.aspx.cs" Inherits="Admin_CustomerTaskEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker({
                format: 'DD/MM/YYYY hh:mm'
            });
        });

        $(function () {
            $('#datetimepicker2').datetimepicker({
                format: 'DD/MM/YYYY hh:mm'
            });
        });
    </script>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Tên gọi, chủ đề:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="AdminTextControl"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style ="height:33px; padding-left:0px !important;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Ngày bắt đầu:
        </div>
        <div class="AdminRightItem" >

            <div class='input-group date' id='datetimepicker1' style ="margin-left:0px; width:33.5% !important;">
                <input type='text' class="form-control" id="txtDayBegin" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span> (mm/dd/yyyy)
                </span>
            </div>

            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker();
                });
            </script>

            <span style ="float:left;">&nbsp;&nbsp;<b>Ngày kết thúc:</b></span>

             <div class='input-group date' id='datetimepicker2' style ="margin-left:10px; width:33% !important;">
                <input type='text' class="form-control" id="txtDayEnd" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span> (mm/dd/yyyy)
                </span>
            </div>

            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker2').datetimepicker();
                });
            </script>

        </div>
    </div>
    

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Mức độ ưu tiên:
        </div>
        <div class="AdminRightItem">
            <asp:DropDownList ID="ddlPriority" AutoPostBack="true" runat="server" Style="width: 33.5%; height: 28px; line-height: 28px;">
                <asp:ListItem Value="1">Cao</asp:ListItem>
                <asp:ListItem Value="2">Trung bình</asp:ListItem>
                <asp:ListItem Value="3">Thấp</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Trạng thái:&nbsp;</b>
            <asp:DropDownList ID="ddlState" AutoPostBack="true" runat="server" Style="width: 15%; height: 28px; line-height: 28px;">
                <asp:ListItem Value="1">Chưa bắt đầu</asp:ListItem>
                <asp:ListItem Value="2">Đang triển khai</asp:ListItem>
                <asp:ListItem Value="3">Đã hoàn thành</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Người tạo :
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserCreateName" runat="server" class="AdminTextControl" Style="width: 33.5% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserCreate" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

            &nbsp;&nbsp;Người thực hiện :&nbsp;
            <asp:TextBox ID="txtUserManagermentName" runat="server" class="AdminTextControl" Style="width: 30% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserManagerment" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName1()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>

        </div>
    </div>

    <div class="AdminItem">
        <div class="AdminLeftItem" style="display: block;">
            &nbsp;&nbsp;Điện thoại:
        </div>
        <div class="AdminRightItem" style="display: block;">
            <asp:TextBox ID="txtContactPhone" class="AdminTextControl" runat="server" Style="width: 100%;"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style="display: block; height: 115px;">
        <div class="AdminLeftItem" style="display: block;">
            &nbsp;&nbsp;Diễn giải:
        </div>
        <div class="AdminRightItem" style="display: block;">
            <asp:TextBox ID="txtNote" TextMode="MultiLine" Rows="3" runat="server" Style="width: 100%;"></asp:TextBox>
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

            var w = 900;
            var h = 600;

            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open("ChooseContact2.aspx", "CHỌN NGƯỜI LIÊN HỆ", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            if (window.focus) {
                newWindow.focus();
            }
        }

        function SelectName1() {

            var w = 900;
            var h = 600;

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
    </script>

</asp:Content>

