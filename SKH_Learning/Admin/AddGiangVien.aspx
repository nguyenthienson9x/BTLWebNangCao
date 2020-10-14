<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AddGiangVien.aspx.cs" Inherits="SKH_Learning.Admin.AddGiangVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/DangNhapDangKy.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <%--<tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="txtbUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbUsername"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>
        <tr>
            <td colspan="2" align="center">
                <h2 style="margin-bottom: 1em">THÊM MỚI GIẢNG VIÊN</h2>
            </td>
        </tr>
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
            <td>Họ tên</td>
            <td>
                <asp:TextBox ID="txtbHoTen" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorHoTen" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbHoten"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>SĐT</td>
            <td>
                <asp:TextBox ID="txtbSDT" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorSDT" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbSDT"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ</td>
            <td>
                <asp:TextBox ID="txtbDiaChi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiaChi" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbDiaChi"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Ngày sinh</td>
            <td>
                <asp:TextBox ID="txtbNgaySinh" TextMode="Date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNgaySinh" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbNgaySinh"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnDangKy" runat="server" Text="THÊM MỚI" OnClick="btnDangKy_Click" CssClass="btnChucNang btnDangKy" Font-Bold="true" /></td>
        </tr>
    </table>
</asp:Content>
