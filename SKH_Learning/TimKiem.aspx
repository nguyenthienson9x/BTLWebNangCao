<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="SKH_Learning.TimKiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Data/Style/HocVien/index.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="lblThongBao" id="lblThongBao" runat="server">Không tìm thấy khóa học nào!</h1>
    <asp:ListView ID="lsVKhoaHoc" runat="server">
        <ItemTemplate>
            <div class="itemKhoaHoc">
                <a href="KhoaHoc.aspx?KhoaHocID=<%# Eval("iID")%>">
                    <div class="itemImgKhoaHoc">
                        <img src="Data/img/KhoaHoc/<%# Eval("sImgLink") %>" class="imgKhoaHoc" align="top" />
                    </div>
                    <br />
                    <p><b><%#Eval("sTenKhoaHoc") %></b></p>
                    <p>GV: <%# Eval("sHoTen") %></p>
                    <%--<p><%# Server.HtmlDecode(Eval("sMoTa").ToString()) %></p>--%>
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
