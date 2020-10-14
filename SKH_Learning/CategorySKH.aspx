<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="CategorySKH.aspx.cs" Inherits="SKH_Learning.CategorySKH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <%--<p><%# Eval("sMoTa") %></p>--%>
                </a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
