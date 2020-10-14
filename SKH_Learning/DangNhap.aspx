<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="SKH_Learning.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Data/Style/HocVien/DangNhapDangKy.css" rel="stylesheet" />
    <style>
        /*#content {
            display: flex;
            justify-content: center;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Vui lòng nhập vào trường này" Text="*" Display="Dynamic" ForeColor="Red" ControlToValidate="txtbEmail" ClientIDMode="Static"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegExEmail" ControlToValidate="txtbEmail" ValidationExpression="^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$" runat="server" ErrorMessage="Email không đúng định dạng!" ForeColor="Red" Display="Dynamic" Text="</br>Email không đúng định dạng!"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <p style="display: none" id="password" runat="server">g</p>
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

    <script src="Data/md5.js"></script>
    <%--    <script>
        function HashPassword() {
            alert("1, Inner HTML: "+document.getElementById('ContentPlaceHolder1_password').innerHTML);
            var pass = document.getElementById('ContentPlaceHolder1_txtbPassword').value;
            alert('2, Pass ở txtb: '+ pass);
            var passhash = md5(pass);      
            alert("3, hashed: " + passhash);
            document.getElementById('ContentPlaceHolder1_password').innerHTML = passhash;
            alert('4, InnerHTML P: ' + document.getElementById('ContentPlaceHolder1_password').innerHTML);
            return true;
        }
    </script>--%>
</asp:Content>
