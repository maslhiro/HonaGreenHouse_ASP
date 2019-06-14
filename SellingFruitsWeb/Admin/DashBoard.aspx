<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="SellingFruitsWeb.Admin.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Dashboard</a>

            </li>
             <li class="breadcrumb-item active">Overview</li>
        </ol>
 
        <!-- Icon Cards-->
        <div class="row">
          <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-primary o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-carrot"></i>
                </div>
                <div class="mr-5" id="txtTraiCay" runat="server">26 New Messages!</div>
              </div>
              <a class="card-footer text-white clearfix small z-1" href="/Admin/ThemTraiCay.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                  <i class="fas fa-angle-right"></i>
                </span>
              </a>
            </div>
          </div>
          <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-warning o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-shopping-cart"></i>
                </div>
                <div class="mr-5" id="txtDHH" runat="server">11 New Tasks!</div>
              </div>
              <a class="card-footer text-white clearfix small z-1" href="/Admin/DonHangDaXuLi.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                  <i class="fas fa-angle-right"></i>
                </span>
              </a>
            </div>
          </div>
          <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-success o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-shopping-cart"></i>
                </div>
                <div class="mr-5" id="txtDHM" runat="server">123 New Orders!</div>
              </div>
              <a class="card-footer text-white clearfix small z-1" href="/Admin/DonHangMoi.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                  <i class="fas fa-angle-right"></i>
                </span>
              </a>
            </div>
          </div>
          <div class="col-xl-3 col-sm-6 mb-3">
            <div class="card text-white bg-danger o-hidden h-100">
              <div class="card-body">
                <div class="card-body-icon">
                  <i class="fas fa-fw fa-shopping-cart"></i>
                </div>
                <div class="mr-5" id="txtDHDXL" runat="server">13 New Tickets!</div>
              </div>
              <a class="card-footer text-white clearfix small z-1" href="/Admin/DonHangDaXuLi.aspx">
                <span class="float-left">View Details</span>
                <span class="float-right">
                  <i class="fas fa-angle-right"></i>
                </span>
              </a>
            </div>
          </div>
        </div>
      
        <!-- DataTables Example -->
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>
            Đơn hàng mới</div>
          <div class="card-body">
            <div class="table-responsive">
              <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0" >
                <thead>
                  <tr>
                    <th>Mã đơn hàng</th>
                    <th>Ngày đặt</th>
                    <th>Tổng tiền</th>
                    <th>Tình trạng</th>
                  </tr>
                </thead>
                <tfoot>
                  <tr>
                    <th>Mã đơn hàng</th>
                    <th>Ngày đặt</th>
                    <th>Tổng tiền</th>
                    <th>Tình trạng</th>
                  </tr>
                </tfoot>
                <tbody>
                 
                </tbody>
              </table>
            </div>
          </div>
          <div class="card-footer small text-muted">Updated now</div>
        </div>

    </div>
    
    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/static/js/popper.min.js"></script>

    <script>
          function loadTable() {

            // Load dataTable qua Api don hang  

            table = $('#dataTable').DataTable({
                processing: true,
                paging: true,
                searching: true,
                ajax: {
                    url: '/Api/DonHang.ashx?DataType=1',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Don_Hang' },
                    { data: 'Ngay_Dat' },
                    { data: 'Tong_Tien' },
                    { data: 'Tinh_Trang_Text' }]
            });         
        }

        $(document).ready(function () {
            loadTable()
        })
    </script>
</asp:Content>
