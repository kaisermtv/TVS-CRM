<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Admin_Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

   <table>
       <tr>
           <td colspan = "2">
               Cập nhật khách hàng hiện hữu
           </td>
       </tr>
       <tr style ="height:50px;">
           <td style ="width:100px;">
               <asp:Button ID="btnActionCustomer" runat="server" Text="Thực hiện" CssClass ="btn btn-primary" OnClick="btnActionCustomer_Click" />
           </td>
           <td>
               <% Response.Write(this.strReturlActCustomer); %>
           </td>
       </tr>
   </table>

</asp:Content>

