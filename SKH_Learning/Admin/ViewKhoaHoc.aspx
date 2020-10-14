<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ViewKhoaHoc.aspx.cs" Inherits="SKH_Learning.Admin.ViewKhoaHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Main {
            height: 70%;
            display: flex;
            position: relative;
        }

        .listBaiHoc {
            height: 100%;
            overflow-y: scroll;
            margin-left: 1em;
            width: 35%;
            box-sizing: border-box;
            display: inline-block;
            background-color: white;
            padding: 10px 1em;
            position: absolute;
            right: 15px;
        }

        .video {
            width: 60%;
            /*height: 400px;*/
        }

        .itemListView {
            margin-top: 5px;
            margin-bottom: 5px;
        }

            .itemListView video {
                display: inline-block;
                vertical-align: middle;
            }

            .itemListView a {
                color: black;
                text-decoration: none;
            }

        .MoTa {
            margin-top: 2em;
            padding: 1em;
            width: 95%;
            background-color: white;
        }

        .sNoiDungP {
            margin-left: 1em;
            margin-top: 1em;
        }

        .btnDangKyHoc {
            border-radius: 30px;
            border: 0px;
            padding: 10px 15px;
            color: white;
            margin: 2em;
            background-color: #07B455;
        }

        .btnHuyDangKyHoc {
            border-radius: 30px;
            border: 0px;
            padding: 10px 15px;
            color: white;
            margin: 2em;
            background-color: #ef5350;
        }

        .BinhLuan h2 {
            margin-bottom: 0.5em;
        }

        .btnBinhLuan {
            border-radius: 30px;
            border: 0px;
            padding: 10px 15px;
            color: white;
            background-color: dodgerblue;
            margin: 2em;
        }

        .BinhLuan input[type=text] {
            margin-bottom: 1em;
            margin-left: 2em;
            padding: 5px;
            font-size: larger;
            width: 30%;
        }

        .TenNguoiBinhLuan {
            color: dodgerblue;
            margin-left: 2em;
            margin-bottom: 15px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Main" runat="server" id="VideoTool">
        <video controls="controls" class="video" runat="server" id="videoPlayer" autoplay>
            <source src="..." type="video/mp4" />
        </video>
        <div class="listBaiHoc">
            <h3 style="text-align: center; margin-bottom: 1em;">DANH MỤC BÀI HỌC</h3>
            <asp:listview id="lsVVideo" runat="server">
                <ItemTemplate>
                    <div class="itemListView">
                        <a href="ViewKhoaHoc.aspx?ID=<%# Eval("Fk_iKhoaHocID") %>&&VideoID=<%#Eval("IID") %>">
                            <video height="50">
                                <source src="../Data/video/<%# Eval("sLink") %>" type="video/mp4" />
                            </video>
                            <span style="margin-left: 10px;"><b><%# Eval("STenBaiHoc") %></b></span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:listview>
        </div>
    </div>

    <div class="MoTa">
        <h2>Nội dung khóa học: </h2>
        <div runat="server" id="sNoiDungKhoaHoc" class="sNoiDungP"></div>
    </div>

    <div class="MoTa" runat="server" id="NoiDungBaiHoc">
        <h2>Nội dung bài học: </h2>
        <div runat="server" id="sNoiDungBaiHoc" class="sNoiDungP"></div>
    </div>

</asp:Content>
