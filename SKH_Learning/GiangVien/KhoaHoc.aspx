<%@ Page Title="" Language="C#" MasterPageFile="~/GiangVien/MasterPage/GV.Master" AutoEventWireup="true" CodeBehind="KhoaHoc.aspx.cs" Inherits="SKH_Learning.KhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .giangVienTool {
            /*display: none;*/
            width: 400px;
            min-width: 400px;
            border: 1px solid black;
            padding: 1em;
            margin: 1em auto;
            box-sizing: border-box;
        }

            .giangVienTool input {
                margin: 10px;
            }


        @media screen and (min-width: 768px) {
            .grvVideo {
                margin: 1em auto;
                width: 75%;
                box-sizing: border-box;
            }
        }

        @media screen and (max-width: 768px) {
            .grvVideo {
                margin: 1em auto;
                width: 90%;
                box-sizing: border-box;
            }
        }

        .grvVideo th {
            background-color: aliceblue;
            color: black;
            font-weight: bold;
        }

        .grvVideo th, td {
            padding: 10px 10px;
            max-width: 300px;
            text-align: center;
        }

        input{
            padding: 5px 10px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" CssClass="btnChucNang btnThem" />
    <div id="giangVienTool" runat="server" class="giangVienTool">
        Tên bài học:
        <asp:TextBox ID="txtbTenBaiHoc" runat="server"></asp:TextBox><br />
        Mô tả:
        <asp:TextBox ID="txtbMoTa" runat="server"></asp:TextBox><br />
        <asp:FileUpload ID="videoUpload" runat="server" />
        <br />
        <asp:Button ID="btnThem_OK" runat="server" Text="Thêm Bài học" OnClick="btnThem_OK_Click" />
        <asp:Button ID="btnSua_OK" runat="server" Text="Sửa Bài học" OnClick="btnSua_OK_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
    </div>
    <asp:GridView ID="grvVideo" runat="server" AutoGenerateColumns="false" CssClass="grvVideo" OnSelectedIndexChanged="grvVideo_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Video bài học">
                <ItemTemplate>
                    <video controls="controls" width="250px">
                        <source src="../Data/video/<%# Eval("sLink") %>" type="video/mp4" />
                    </video>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Tên bài học" DataField="sTenBaiHoc" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
