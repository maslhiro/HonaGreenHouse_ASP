<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DanhMuc.aspx.cs" Inherits="SellingFruitsWeb.DanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Danh mục</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder" runat="server">
    <div class="Selling_Products">
        <div class="selling_title">
            <div id="danh_muc" runat="server"></div>
        </div>
        <div class="list_products">
            <ul id="ul_list_danhmuc" runat="server">
            </ul>
        </div>   
    </div>
</asp:Content>
