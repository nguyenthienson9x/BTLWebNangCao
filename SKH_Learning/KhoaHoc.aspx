<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="KhoaHoc.aspx.cs" Inherits="SKH_Learning.KhoaHoc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Data/Style/HocVien/KhoaHoc.css" rel="stylesheet" />
    <script>
        function Comment() {
            var sNoiDung = document.getElementById('ContentPlaceHolder1_txtbBinhLuan').value;
            if (sNoiDung == "") {
                return false;
            }

            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var result = JSON.parse(this.responseText);
                    /*alert(result.d);*/
                    if (result.d == true) {
                        document.getElementById('ContentPlaceHolder1_txtbBinhLuan').value = "";

                        var firstCmt = (document.getElementsByClassName('TenNguoiBinhLuan'))[0];
                        if (firstCmt != null) {
                            var ten = (document.getElementsByClassName('lblLoiChao'))[0].innerHTML;
                            ten = ten.substring(5, ten.length);
                            var span1 = document.createElement('span');
                            span1.innerHTML = ten + "&nbsp;";
                            span1.setAttribute("class", "TenNguoiBinhLuan");
                            var span2 = document.createElement('span');
                            span2.innerText = sNoiDung;

                            firstCmt.parentNode.insertBefore(span1, firstCmt);    //Insert tên -> nội dung -> br 
                            firstCmt.parentNode.insertBefore(span2, span1.nextElementSibling);
                            firstCmt.parentNode.insertBefore(document.createElement('br'), span2.nextElementSibling);
                        }
                        else {
                            var ten = (document.getElementsByClassName('lblLoiChao'))[0].innerHTML;
                            ten = ten.substring(5, ten.length);
                            var span1 = document.createElement('span');
                            span1.innerHTML = ten + "&nbsp;";
                            span1.setAttribute("class", "TenNguoiBinhLuan");
                            var span2 = document.createElement('span');
                            span2.innerText = sNoiDung;
                            document.getElementById('ContentPlaceHolder1_BinhLuan').append(span1);
                            document.getElementById('ContentPlaceHolder1_BinhLuan').append(span2);
                        }
                    }
                    else {
                        alert("THẤT BẠI");
                    }
                }
            };
            xhttp.open("POST", "KhoaHoc.aspx/Comment", true);
            xhttp.setRequestHeader("Content-type", "application/json; charset=utf-8");
            xhttp.send('{sNoiDung: "' + sNoiDung + '"}');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Main" runat="server" id="VideoTool">
        <video controls="controls" class="video" runat="server" id="videoPlayer" autoplay>
            <source src="..." type="video/mp4" />
        </video>
        <div class="listBaiHoc">
            <h3 style="text-align: center; margin-bottom: 1em;">DANH MỤC BÀI HỌC</h3>
            <asp:ListView ID="lsVVideo" runat="server">
                <ItemTemplate>
                    <div class="itemListView">
                        <a href="KhoaHoc.aspx?KhoaHocID=<%# Eval("Fk_iKhoaHocID") %>&&VideoID=<%#Eval("IID") %>">
                            <video height="50">
                                <source src="../Data/video/<%# Eval("sLink") %>" type="video/mp4" />
                            </video>
                            <span style="margin-left: 10px;"><b><%# Eval("STenBaiHoc") %></b></span>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div class="MoTa">
        <b style="font-size: 1.5em">Bài: 
            <asp:Label ID="lblBaiHoc" runat="server" Text="Label" CssClass="lblBaiHoc"></asp:Label></b>
    </div>

    <div class="MoTa">
        <h2>Nội dung khóa học: </h2>
        <div runat="server" id="sNoiDungKhoaHoc" class="sNoiDungP"></div>
    </div>

    <div class="MoTa" runat="server" id="NoiDungBaiHoc">
        <h2>Nội dung bài học: </h2>
        <div runat="server" id="sNoiDungBaiHoc" class="sNoiDungP"></div>
    </div>

    <div class="MoTa" runat="server">
        <div runat="server" id="sNoiDungThongbao" class="sNoiDungP"></div>
        <asp:Button ID="btnDangKyHoc" runat="server" Text="Đăng ký học" Visible="false" CssClass="btnDangKyHoc" OnClick="btnDangKyHoc_Click" />
        <asp:Button ID="btnHuyDangKyHoc" runat="server" Text="Hủy đăng ký" Visible="false" CssClass="btnHuyDangKyHoc" OnClick="btnHuyDangKyHoc_Click" />
    </div>

    <div class="MoTa BinhLuan" runat="server" id="BinhLuan">
        <h2>Bình luận</h2>
        <asp:TextBox ID="txtbBinhLuan" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic" ControlToValidate="txtbBinhLuan"></asp:RequiredFieldValidator>
        <asp:Button ID="btnBinhLuan" runat="server" Text="Bình luận" CssClass="btnBinhLuan" OnClick="btnBinhLuan_Click" Visible="false" />
        <input type="button" name="name" value="Bình Luận" id="btnComment" onclick="Comment();" class="btnBinhLuan" /><br />

        <asp:ListView ID="lsVBinhLuan" runat="server" OnItemDataBound="lsVBinhLuan_ItemDataBound">
            <ItemTemplate>
                <%--<span id="TenNguoiBinhLuan" class="TenNguoiBinhLuan" runat="server"><b><%#Eval("sHoTen") %>:</b></span>--%>
                <asp:Label ID="lblTenNguoiBL" runat="server" Text='<%#Eval("sHoTen") %>' CssClass="TenNguoiBinhLuan"></asp:Label>
                <span><%#Eval("sNoiDung") %></span>
                <br />
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
