<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="DuyetKhoaHoc.aspx.cs" Inherits="SKH_Learning.Admin.DuyetKhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tblKhoaHoc {
            margin-bottom: 1em;
        }

            .tblKhoaHoc th {
                background-color: aliceblue;
            }

            .tblKhoaHoc th, .tblKhoaHoc td {
                padding: 10px;
            }

            .tblKhoaHoc a {
                text-decoration: none;
                font-weight:bold;
                color: darkblue;
            }

        .lblTrangThai {
            margin: 1em;
        }

        .btn {
            border-radius: 30px;
            border: 0px;
            padding: 10px 15px;
            color: white;
            font-weight: bold;
            background-color: #07B455;
        }

        input {
            padding: 5px 10px;
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="lblTrangThai" id="lblTrangThai" runat="server"></h2>
    <asp:GridView ID="grvKhoaHoc" runat="server" AutoGenerateColumns="False" CssClass="tblKhoaHoc" OnRowDataBound="grvKhoaHoc_RowDataBound">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="iID" DataNavigateUrlFormatString="/Admin/ViewKhoaHoc.aspx?ID={0}" HeaderText="Tên khóa học" DataTextField="sTenKhoaHoc" />
            <%--<asp:BoundField DataField="sTenKhoaHoc" HeaderText="Tên khóa học" />--%>
            <asp:BoundField DataField="sCate" HeaderText="Tên bộ môn" />
            <asp:BoundField DataField="sSub" HeaderText="Tên môn học" />
            <asp:BoundField DataField="sHoTen" HeaderText="Tên giảng viên" />
            <asp:TemplateField HeaderText="Trạng thái">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTrangThai"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Duyệt/Không">
                <ItemTemplate>
                    <asp:Button ID="btnDuyet" runat="server" Text="Duyệt" OnClick="btnDuyet_Click" CommandArgument='<%# Eval("iID") %>' />
                    <asp:Button ID="btnTuChoi" runat="server" Text="Từ chối" OnClick="btnTuChoi_Click" CommandArgument='<%# Eval("iID") %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <asp:Button runat="server" ID="btnXemTatCa" OnClick="btnXemTatCa_Click" Text="Xem tất cả" CssClass="btn" />
    <asp:Button runat="server" ID="btnXemDeDuyet" OnClick="btnXemDeDuyet_Click" Text="Xem để duyệt!" Visible="false" CssClass="btn" />

</asp:Content>
