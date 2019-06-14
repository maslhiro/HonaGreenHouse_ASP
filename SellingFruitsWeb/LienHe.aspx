<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="SellingFruitsWeb.LienHe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Liên hệ</title>
    <link href="https://fonts.googleapis.com/css?family=Pacifico&display=swap" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder" runat="server">
    <style type="text/css">
    .Contact{
        margin: 1em 4em;
    }

    .Contact ul{
        display: flex;
        flex-wrap: wrap;
        padding: 0;
        justify-content: space-between;
    }

    .Contact li{
        display: inline-block;
        width: 288px;
        margin: .5em;
        text-align: center;
    }

    card_contact{
        box-shadow: none;
        border-top: 40px;
    }

    .content{
        margin: 0.5em 0;
        font-size: 24px;

    }

    .name{
        font-size: 25px !important;
        font-family: 'Pacifico', cursive;    

    }

    .Contact img{
        border-radius: 100%;
        width: 200px;
        height: 200px;
    }

    .title {
        display : flex;
        align-items:center;
        justify-content:center;
        font-size: 45px;
        font-family: 'Pacifico', cursive;    

    }
    </style>

    <div class="Contact">

        <div class="title">
            Nhóm thực hiện
        </div>

        <ul>
            <li>
                <div class="card_contact">
                    <img src="https://scontent.fsgn5-4.fna.fbcdn.net/v/t1.15752-9/61556351_327025604659754_8934669046796779520_n.jpg?_nc_cat=102&_nc_oc=AQkmPp4s6oCpryzeEm4ptFtI2FMhyCAsu9ESbUgAcaTC0EIwMkrLm--qu77TraBnO6k&_nc_ht=scontent.fsgn5-4.fna&oh=dbf7670af610ffcf08ff85104ea54c7f&oe=5D9AA1C3" alt="Avatar">
                    <div class="content">
                        <div class="name"><b>Vinh Le Nhut</b></div>
                        <div class="mssv">15521016</div>
                        <div class="mess">Đồ án #devkl</div>
                    </div>
                </div>
            </li>
            <li>
                <div class="card_contact">
                    <img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/61705244_370872353543701_2708663529434513408_n.png?_nc_cat=101&_nc_oc=AQndfulbWCtf760R3ffNUgUOJhB11mDBG29yMbVm76qtVRG3Jyq4SFmn8FL7s1DV78cWBIEJGiiUBn5mLT9WvtLE&_nc_ad=z-m&_nc_cid=0&_nc_zor=9&_nc_ht=scontent.xx&oh=64c9c2eae317357532cff93fb25d50dc&oe=5D8A8002" alt="Avatar">
                    <div class="content">
                        <div class="name"><b>Tho Duong Phuoc Hai</b></div>
                        <div class="mssv">15520851</div>
                        <div class="mess">Dăm ba cái đồ án</div>
                    </div>
                </div>
            </li>
            <li>
                <div class="card_contact">
                    <img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/61583777_325602978119778_6943252694878388224_n.png?_nc_cat=108&_nc_oc=AQkN80g8QPcUHic7TOQP3CPo_jltg2qNsUtEFXkor52zIaNL4SBIbECZqsEC2O8SbftANny4rjW6aGahurKzUsE2&_nc_ad=z-m&_nc_cid=0&_nc_zor=9&_nc_ht=scontent.xx&oh=7391157a066b9278f51a3dc65e7d5567&oe=5D58DBE5" alt="Avatar">
                    <div class="content">
                        <div class="name"><b>Thang Do Thanh</b></div>
                        <div class="mssv">15520787</div>
                        <div class="mess">Đồ án ???</div>
                    </div>
                </div>
            </li>
            <li>
                <div class="card_contact">
                    <img src="https://scontent.xx.fbcdn.net/v/t1.15752-0/p280x280/61522594_351407545579672_7242646060399591424_n.png?_nc_cat=101&_nc_oc=AQmSClt7qKoFmlCzGJdB7yLzPt-tDRNU4ErMLX4mpKvbHQ4JLuWf00kX5-swGpcUnivmGf-lXJnvL-5ZmNmDt2BP&_nc_ad=z-m&_nc_cid=0&_nc_zor=9&_nc_ht=scontent.xx&oh=bd4b4e04efef273ed3eadd8b9a7578ca&oe=5D8B381A" alt="Avatar">
                    <div class="content">
                        <div class="name"><b>Quoc Tran Minh</b></div>
                        <div class="mssv">15520702</div>
                        <div class="mess">Đồ án #nolaidevl</div>
                    </div>
                </div>
            </li>
        </ul>
    </div>    
</asp:Content>
