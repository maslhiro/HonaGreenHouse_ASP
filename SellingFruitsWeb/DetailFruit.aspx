<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailFruit.aspx.cs" Inherits="SellingFruitsWeb.DetailFruit" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="/static/css/bootstrap.css" type="text/css" />
     <style type="text/css">
        .img-fruite {
            height: 300px;
            width: 100%;
        }

        .container-fruite {
            margin-top: 50px;
        }

        .left-fruite {
            margin-left: 0px;
        }

        .color-titel-fruite {
            color: #8bc04e;
        }

        .notes-fruite {
            height: auto;
            width: 100%;
        }

        .add-to-cart {
            background-color: #46aa48;
            font-size: 14px !important;
            color: white;
            border-radius: 40px;
            border-width: 0px;
            border-style: solid;
            border-color: #fff;
            font-weight: bold;
            font-family: 'PT Sans', Arial, Helvetica, sans-serif;
            min-height: 32px;
            text-transform: uppercase;
            text-align: center;
            padding: 0 20px;
            margin: 0;
        }

        .number-add-to-cart {
            width: 60px;
        }

        .top-cart {
            margin-top: 20px;
        }

        .top-caption {
            margin-top: 40px;
        }

        .top-img {
            margin-top: 13px;
        }

        .caption {
            text-align: left;
            font-size: 18px !important;
            font-weight: bold !important;
            font-family: "OpenSans-Bold" !important;
            color: #fff !important;
            background-color: #8BC04E !important;
            padding: 10px 10px 10px 10px !important;
            width: 100px !important;
            position: relative;
            text-transform: uppercase;
        }

        .entry-content {
            float: left;
            margin: 0px;
            width: 100%;
            border-top: none;
            padding: 20px;
            border: 1px solid #e7e6e6;
            box-sizing: border-box;
            color: #666666;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholder" runat="server">
    <div class="container container-fruite">
        <div class="row">
            <div class="col-md-5 top-img">
                <%--<img class="img-fruite" src="http://greenyhouse.com/assets/uploads/2017/02/15697472_1221461517929374_8918126270662443058_n-400x300.jpg"/>--%>
                <asp:Image ID="imgFruiteId" runat="server" class="img-fruite" />
            </div>

            <div class="col-md-7 left-fruite">

                <div class="row">
                    <div class="col-md-12 color-titel-fruite">
                        <h1>
                            <asp:Label ID="lblTenTC" runat="server" Text=""></asp:Label></h1>
                    </div>
                    <div class="col-md-12">
                        <h5>
                            <asp:Label ID="lblDonGiaInt" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblDonGia" runat="server" Text=""></asp:Label>đ</h5>
                    </div>
                    <div class="col-md-12"><span>Đơn vị tính:
                        <asp:Label ID="lblDonViTinh" runat="server" Text=""></asp:Label>
                    </span></div>

                    <%--<div class="col-md-12">
                        <h5>Yêu cầu đặc biệt </h5>
                    </div>
                    <div class="col-md-12">
                        <textarea placeholder="" class="notes-fruite" data-price="" id="textarea_note" tabindex="1" rows="5" cols="20"></textarea>
                    </div>--%>

                 

                        <%--<div class="col-md-12">
                        <span>Tổng tiền: </span>
                        <span id="total-cart"> <asp:Label ID="lblTongTien" runat="server" Text=""></asp:Label>đ</span>
                    </div>--%>
                        <div class="col-md-12 top-cart">
                            <span>Số lượng </span>
                            <asp:TextBox ID="txbSoLuong" runat="server" type="number" step="1" min="1" value="1" class="number-add-to-cart" />
                            <asp:Button ID="btnBuy" runat="server" Text="MUA NGAY" class="add-to-cart" OnClick="btnBuy_Click" />
                        </div>
                   

                </div>


            </div>

            <div class="col-md-12 top-caption">
                <span class="caption">MIÊU TẢ
                    <br />
                </span>
                <div class="panel entry-content" id="tab-description" style="display: block;">
                    <span>
                        <asp:Label ID="lblMieuTa" runat="server" Text=""></asp:Label>
                    </span>
                </div>
            </div>
        </div>
    </div>

    <script src="static/js/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script src="static/js/bootstrap.js" type="text/javascript"></script>
</asp:Content>