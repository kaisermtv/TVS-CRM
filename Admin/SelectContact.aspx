﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SelectContact.aspx.cs" Inherits="Admin_SelectContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div>
        <h3>Danh sách nhân viên</h3>
        Click vào tên nhân viên để chọn
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>#</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Username</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">1</th>
                    <td><a href="#" onclick="return SetName('Ngọc Trinh');">Ngọc Trinh</a></td>
                    <td>Otto</td>
                    <td>mdo</td>
                </tr>
                <tr>
                    <th scope="row">2</th>
                    <td><a href="#" onclick="return SetName('Phương Trinh');">Phương Trinh</a></td>
                    <td>Thornton</td>
                    <td>fat</td>
                </tr>
                <tr>
                    <th scope="row">3</th>
                    <td><a href="#" onclick="return SetName('Lệ Rơi');">Lệ Rơi</a></td>
                    <td>the Bird</td>
                    <td>twitter</td>
                </tr>
                <tr>
                    <th scope="row">4</th>
                    <td><a href="#" onclick="return SetName('Bà Tưng');">Bà Tưng</a></td>
                    <td>the Bird</td>
                    <td>twitter</td>
                </tr>
                <tr>
                    <th scope="row">5</th>
                    <td><a href="#" onclick="return SetName('Kenny Sang');">Kenny Sang</a></td>
                    <td>the Bird</td>
                    <td>twitter</td>
                </tr>
            </tbody>
        </table>
    </div>
    <script type="text/javascript">
        function SetName(value) {
            if (window.opener != null && !window.opener.closed) {
                var txtName = window.opener.document.getElementById("MainContent_txtUserCreate");
                txtName.value = value;
            }
            window.close();
        }
    </script>

</asp:Content>

