<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="DuyetDangKyHoc.aspx.cs" Inherits="SKH_Learning.Admin.DuyetDangKyHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tblHoc {
            margin-bottom: 1em;
        }

            .tblHoc th {
                background-color: aliceblue;
            }

            .tblHoc th, .tblHoc td {
                padding: 10px;
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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 runat="server" class="lblTrangThai" id="lblTrangThai"></h2>
    <asp:GridView ID="grvHoc" CssClass="tblHoc" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvHoc_DataBound">
        <Columns>
            <asp:BoundField DataField="iID" HeaderText="ID" SortExpression="iID" Visible="false" />
            <asp:BoundField DataField="sTenHocVien" HeaderText="Tên học viên" />
            <asp:BoundField DataField="sTenKhoaHoc" HeaderText="Tên khóa học" />
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
            <%--<asp:BoundField DataField="IDuyet" HeaderText="Trạng thái" SortExpression="iID" Visible="false" />--%>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" ID="btnXemTatCa" OnClick="btnXemTatCa_Click" Text="Xem tất cả" CssClass="btn" />
    <asp:Button runat="server" ID="btnXemDeDuyet" OnClick="btnXemDeDuyet_Click" Text="Xem để duyệt!" Visible="false" CssClass="btn" />
</asp:Content>
