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
    <script src="static/js/slider.js" type="text/javascript"></script>
</asp:Content>
