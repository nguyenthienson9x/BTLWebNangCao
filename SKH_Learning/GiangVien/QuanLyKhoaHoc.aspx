<%@ Page Title="" Language="C#" MasterPageFile="~/GiangVien/MasterPage/GV.Master" AutoEventWireup="true" CodeBehind="QuanLyKhoaHoc.aspx.cs" Inherits="SKH_Learning.GiangVien.QuanLyKhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Data/tinymce/js/tinymce/tinymce.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <style>
        .imgKhoaHoc {
            width: 250px;
        }



        @media screen and (min-width: 768px) {
            .grvKhoaHoc {
                margin: 1em auto;
                width: 75%;
                box-sizing: border-box;
            }
        }

        @media screen and (max-width: 768px) {
            .grvKhoaHoc {
                margin: 1em auto;
                width: 90%;
                box-sizing: border-box;
            }
        }

        .grvKhoaHoc th {
            background-color: aliceblue;
            color: black;
            font-weight: bold;
        }

        /*.grvKhoaHoc th, td {
                padding: 20px 10px;
                max-width: 300px;
            }*/

        .grvKhoaHoc > tbody > tr > td, th {
            padding: 10px 10px;
            max-width: 300px;
            text-align: center;
        }

        .giangVienTool table {
            /*display: none;*/
            min-width: 400px;
            width: 75%;
            border: 1px solid black;
            padding: 1em;
            margin: 1em auto;
            box-sizing: border-box;
        }

        .giangVienTool input, .giangVienTool select {
            margin: 5px;
            padding: 5px 10px;
        }

        input {
            padding: 5px 10px;
        }

        #txtbMoTa {
            z-index: -1;
        }

        .txtbMoTa {
            padding: 1em;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Button ID="tbnThemKhoaHoc" runat="server" Text="Thêm khóa học" OnClick="tbnThemKhoaHoc_Click" CssClass="btnChucNang btnThem" />
    <br />
    <div id="giangVienTool" runat="server" class="giangVienTool">
        <table>
            <tr>
                <td>Tên Khóa học: 
                </td>
                <td>
                    <asp:TextBox ID="txtbKhoaHoc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mô tả: 
                </td>
                <td>
                    <textarea rows="10" cols="50" name="content" runat="server" class="inputbox autowidth txtbMoTa" id="txtbMoTa">                      
                                          </textarea>
                </td>
            </tr>
            <tr>
                <td>Thuộc: 
                </td>
                <td>Loại:
                    <asp:DropDownList ID="DDLCategory" runat="server" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
                    Môn:
                    <asp:DropDownList ID="DDLSubCategory" runat="server"></asp:DropDownList><br />
                </td>
            </tr>
            <tr>
                <td>Chọn ảnh: 
                </td>
                <td>
                    <asp:FileUpload ID="imgUpload" runat="server" />
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnThemOK" runat="server" Text="Thêm" OnClick="btnThemOK_Click" Visible="true" />
                    <asp:Button ID="btnSuaOK" runat="server" Text="Sửa" Visible="false" OnClick="btnSuaOK_Click" />
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" Text="Hủy" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    </div>

    <asp:GridView ID="grvQLKhoaHoc" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grvQLKhoaHoc_SelectedIndexChanged" CssClass="grvKhoaHoc" OnRowDataBound="grvQLKhoaHoc_RowDataBound">
        <Columns>
            <asp:BoundField DataField="iID" HeaderText="ID" SortExpression="iID" />
            <asp:HyperLinkField DataTextField="sTenKhoaHoc" HeaderText="Tên khóa học" DataNavigateUrlFields="iID" DataNavigateUrlFormatString="KhoaHoc.aspx?KhoaHocID={0}" />
            <asp:BoundField DataField="sSub" HeaderText="Môn học" />
            <asp:ImageField DataImageUrlField="sImgLink" DataImageUrlFormatString="../Data/img/KhoaHoc/{0}" ControlStyle-CssClass="imgKhoaHoc" HeaderText="Ảnh Mô tả">
                <ControlStyle CssClass="imgKhoaHoc"></ControlStyle>
            </asp:ImageField>
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
            <%--<asp:BoundField DataField="iDuyet" HeaderText="Trạng thái" />--%>
            <asp:TemplateField HeaderText="Trạng thái">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTrangThai"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <script>
        /*$(document).ready(function () {
            tinymce.init({
                selector: 'textarea',
                encoding: 'xml'
            });
        });*/
    </script>
</asp:Content>
