<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="SKH_Learning.Admin.DangNhap" %>
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
                <asp:Button ID="btnDangNhap" runat="server" Text="ĐĂNG NHẬP" CssClass="btnChucNang btnDangNhap" Font-Bold="true" OnClick="btnDangNhap_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
