<%@ Page Title="" Language="C#" MasterPageFile="~/GiangVien/MasterPage/GV.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="SKH_Learning.GiangVien.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/DangNhapDangKy.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbEmail"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtbPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnDangNhap" runat="server" Text="ĐĂNG NHẬP" OnClick="btnDangNhap_Click" CssClass="btnChucNang btnDangNhap" Font-Bold="true" />
            </td>
        </tr>
    </table>
        <script>
            window.onload = function () {
            document.getElementById("<%=txtbEmail.ClientID%>").value = "thaygiao@gmail.com";
            document.getElementById("<%=txtbPassword.ClientID%>").value = "12345678";
        }
    </script>
</asp:Content>
