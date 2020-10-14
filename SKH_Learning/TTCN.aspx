<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="TTCN.aspx.cs" Inherits="SKH_Learning.TTCN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .TTCN-ctn {
            padding: 2em;
            box-sizing: border-box;
        }

        .TTCN > div, .DoiMK > div {
            height: 40px;
            align-items: center;
        }

            .TTCN > div > p {
                width: 100px;
                display: inline-block;
            }

            .TTCN > div > input, .DoiMK > div > input {
                height: 25px;
                box-sizing: border-box;
                padding: 0 4px;
            }

            .DoiMK > div > p {
                width: 150px;
                display: inline-block;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="TTCN-ctn">
        <div id="ThongTinCaNhan" class="TTCN" runat="server">
            <div>
                <p>Email: </p>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <p>Họ tên: </p>
                <asp:Label ID="lblHoTen" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtbHoTen" runat="server" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbHoTen" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="SuaTT" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div>
                <p>SĐT: </p>
                <asp:Label ID="lblSDT" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtbSDT" runat="server" Visible="false"></asp:TextBox>
                <%--<asp:RegularExpressionValidator runat="server" ID="RegExSDT" ControlToValidate="txtbSDT" ValidationExpression="^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)?(\d{3})$" ForeColor="Red" Display="Dynamic" Text="</br>SĐT không đúng định dạng!" ErrorMessage="SĐT không đúng định dạng!" ValidationGroup="SuaTT"></asp:RegularExpressionValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbSDT" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="SuaTT" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div>
                <p>Địa chỉ: </p>
                <asp:Label ID="lblDiaChi" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtbDiaChi" runat="server" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbDiaChi" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="SuaTT" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div>
                <p>Ngày sinh: </p>
                <asp:Label ID="lblNgaySinh" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtbNgaySinh" runat="server" Visible="false" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbNgaySinh" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="SuaTT" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div class="btn-ctn">
                <asp:Button ID="btnSuaTT" runat="server" Text="Sửa thông tin" OnClick="btnSuaTT_Click" CausesValidation="false" />
                <asp:Button ID="btnDoiMK" runat="server" Text="Đổi mật khẩu" OnClick="btnDoiMK_Click" CausesValidation="false" />
                <asp:Button ID="btnSua_OK" runat="server" Text="OK" OnClick="btnSua_OK_Click" Visible="false" ValidationGroup="SuaTT" />
                <asp:Button ID="btnSua_Huy" runat="server" Text="Hủy" OnClick="btnSua_Huy_Click" Visible="false" CausesValidation="false" />
            </div>
        </div>
        <div id="DoiMK" class="DoiMK" runat="server" visible="false">
            <div>
                <p>Mật khẩu hiện tại</p>
                <asp:TextBox ID="txtbCurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbCurrentPassword" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="DoiMK" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div>
                <p>Mật khẩu mới</p>
                <asp:TextBox ID="txtbNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbNewPassword" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="DoiMK" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
            </div>
            <div>
                <p>Nhập lại mật khẩu</p>
                <asp:TextBox ID="txtbReEnterPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbReEnterPassword" ErrorMessage="Vui lòng điền vào trường này" ValidationGroup="DoiMK" ForeColor="Red" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtbReEnterPassword" ControlToValidate="txtbNewPassword" Display="Dynamic" ErrorMessage="Không khớp" ForeColor="Red" ValidationGroup="DoiMK"></asp:CompareValidator>
            </div>
            <div class="btn-ctn">
                <asp:Button ID="btnDoiMK_OK" runat="server" Text="OK" OnClick="btnDoiMK_OK_Click" Visible="false" ValidationGroup="DoiMK" />
                <asp:Button ID="btnDoiMK_Huy" runat="server" Text="Hủy" OnClick="btnDoiMK_Huy_Click" Visible="false" CausesValidation="false" />
            </div>
        </div>
    </div>
</asp:Content>
