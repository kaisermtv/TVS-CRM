<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" ValidateRequest ="false" AutoEventWireup="true" CodeFile="TargetEdit.aspx.cs" Inherits="Admin_TargetEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

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
            &nbsp;&nbsp;Tên gọi:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="AdminItem" style ="height:33px; padding-left:0px !important; margin-top:10px;">
        <div class="AdminLeftItem">
            &nbsp;&nbsp;Ngày bắt đầu:
        </div>
        <div class="AdminRightItem" >

            <div class='input-group date' id='datetimepicker1' style ="margin-left:0px; width:180px !important;">
                <input type='text' class="form-control" id="txtDayBegin" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>

            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker();
                });
            </script>

            <span style ="float:left;">&nbsp;&nbsp;<b>Kết thúc:</b></span>

             <div class='input-group date' id='datetimepicker2' style ="margin-left:10px; width:180px !important;">
                <input type='text' class="form-control" id="txtDayEnd" runat="server" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
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
            &nbsp;&nbsp;Người tạo:
        </div>
        <div class="AdminRightItem">
            <asp:TextBox ID="txtUserCreateName" runat="server" class="AdminTextControl" Style="width: 40.3% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserCreate" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>
            Người thực hiện:
            <asp:TextBox ID="txtUserManagermentName" runat="server" class="AdminTextControl" Style="width: 33.5% !important;"></asp:TextBox>
            <asp:TextBox ID="txtUserManagerment" runat="server" class="AdminTextControl" Style="width: 1% !important; visibility: hidden;"></asp:TextBox>
            <button class="btn btn-primary" type="button" onclick="SelectName1()" style="height: 28px !important; line-height: 14px !important; margin-top: -2px !important;">Chọn</button>
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
            var newWindow = window.open("ChooseAccount.aspx", "CHỌN NGƯỜI DÙNG", 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

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

