<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="SKH_Learning.DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Data/Style/HocVien/DangNhapDangKy.css" rel="stylesheet" />       
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
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegExEmail" ControlToValidate="txtbEmail" ValidationExpression="^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$" runat="server" ErrorMessage="Email không đúng định dạng!" ForeColor="Red" Display="Dynamic" Text="</br>Email không đúng định dạng!"></asp:RegularExpressionValidator>                
            </td>
        </tr>
        <tr>
            <td>Mật khẩu</td>
            <td>
                <asp:TextBox ID="txtbPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Nhập lại mật khẩu</td>
            <td>
                <asp:TextBox ID="txtbRePassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtbRePassword" ControlToValidate="txtbPassword" Display="Dynamic" ErrorMessage="<br/>Không khớp" ForeColor="Red"></asp:CompareValidator>
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
                <%--<asp:RegularExpressionValidator runat="server" ID="RegExSDT" ControlToValidate="txtbSDT" ValidationExpression="^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$" ForeColor="Red" Display="Dynamic" Text="</br>SĐT không đúng định dạng!" ErrorMessage="SĐT không đúng định dạng!"></asp:RegularExpressionValidator>--%>
                <%--  ^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$  --%>
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
                <asp:TextBox ID="txtbNgaySinh" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNgaySinh" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbNgaySinh"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnDangKy" runat="server" Text="ĐĂNG KÝ" OnClick="btnDangKy_Click" CssClass="btnChucNang btnDangKy" Font-Bold="true" /></td>
        </tr>
    </table>
</asp:Content>
