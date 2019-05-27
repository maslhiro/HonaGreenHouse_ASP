<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ChiTietTraiCay.aspx.cs" Inherits="SellingFruitsWeb.Admin.ChiTietTraiCay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Chi tiết trái cây</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Chi tiết trái cây
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label>Mô tả :</label>
                    <textarea class="form-control" rows="10" id="txtMoTa"></textarea>
                </div>
                 <div class="form-group">
                    <label>Upload ảnh :</label>
                    <%--<input type="file" class="form-control-file" id="exampleFormControlFile1">--%>
                    <input type='file' onchange="readURL(this);" />
                    <img id="blah" src="#" alt="your image" />
                  </div>
                <button type="submit" class="btn btn-primary" id="btnSubmit">Submit</button>

            </div>
        </div>

    </div>


    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#blah')
                        .attr('src', e.target.result)
                        .width(300)
                        .height(300);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }      
    </script>
</asp:Content>
