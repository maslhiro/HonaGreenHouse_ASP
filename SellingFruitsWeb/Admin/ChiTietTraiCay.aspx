<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ChiTietTraiCay.aspx.cs" Inherits="SellingFruitsWeb.Admin.ChiTietTraiCay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#" runat="server" id="title">Chi tiết trái cây</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Chi tiết trái cây
            </div>
            <div class="card-body">
                <div id="alert"></div>
                <div class="form-group">
                    <label for="txtMoTa">Mô tả :</label>
                    <textarea class="form-control" rows="10" id="txtMoTa" runat="server"></textarea>
                </div>
                 <div class="form-group">
                    <label>Upload ảnh :</label>
                    <input ID="imageUpload" type="file" name="file" onchange="previewFile()"  runat="server" />
                 </div>
                <asp:Image ID="image" runat="server"  Height="225px" Width="225px" />
                <button type="submit" class="btn btn-primary" id="btnSubmit" runat="server" onserverclick="btnSubmit_ServerClick">Cập nhật</button>

            </div>
        </div>

    </div>


     <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=image.ClientID %>');
            var file = document.querySelector('#<%=imageUpload.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>
