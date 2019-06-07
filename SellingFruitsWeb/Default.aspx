<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SellingFruitsWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholder" runat="server">
    <div style="display: flex; flex: 1; align-items: center; justify-content: center; margin-top: 10px; flex-direction: column">
        <div class="slideshow-container">
            <div class="mySlides fade">
                <img src="static/img/slider01.jpg" style="width: 100%">
            </div>

            <div class="mySlides fade">
                <img src="static/img/slider02.jpg" style="width: 100%">
            </div>

            <div class="mySlides fade">
                <img src="static/img/slider03.jpg" style="width: 100%">
            </div>
        </div>
        <br>

        <div style="text-align: center">
            <span class="dot" onclick="currentSlide(0)"></span>
            <span class="dot" onclick="currentSlide(1)"></span>
            <span class="dot" onclick="currentSlide(2)"></span>
        </div>
    </div>
    <div class="Category">
        <a href="/DanhMuc.aspx?id=LTC01">
            <div class="card">
                <img src="static/img/trai-cay-mien-nam.jpg" alt="Avatar">
                <div class="content">
                <span class="category_name"><b>TRÁI CÂY MIỀN NAM</b></span> 
                </div>
            </div>
        </a>
        
        <a href="/DanhMuc.aspx?id=LTC02">
            <div class="card">
              <img src="static/img/trai-cay-dac-san-mien-bac.jpg" alt="Avatar">
              <div class="content">
                <span class="category_name"><b>TRÁI CÂY MIỀN BẮC</b></span> 
              </div>
            </div>
        </a>

        <a href="/DanhMuc.aspx?id=LTC03">
            <div class="card">
              <img src="static/img/trai-cay-mien-trung.jpg" alt="Avatar">
              <div class="content">
                <span class="category_name"><b>TRÁI CÂY MIỀN TRUNG</b></span> 
              </div>
            </div>
        </a>
        
        <a href="/DanhMuc.aspx?id=LTC04">
            <div class="card">
              <img src="static/img/trai-cay-nhap-khau.jpg" alt="Avatar">
              <div class="content">
                <span class="category_name"><b>TRÁI CÂY NHẬP KHẨU</b></span> 
              </div>
            </div>
        </a>
    </div>

    <div class="Selling_Products">
        <div class="selling_title">
            <span>SẢN PHẨM XEM NHIỀU</span>
        </div>
        <div class="list_products">
            <ul id="ul_list_tc" runat="server">
            </ul>
        </div>
        <div class="see_more"><button class="button_see_more" onserverclick="button_see_more_ServerClick" runat="server">XEM THÊM</button></div>     
    </div>
    <script src="static/js/slider.js" type="text/javascript"></script>
</asp:Content>
