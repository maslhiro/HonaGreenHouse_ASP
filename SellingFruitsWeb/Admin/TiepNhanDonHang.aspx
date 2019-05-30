<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="TiepNhanDonHang.aspx.cs" Inherits="SellingFruitsWeb.Admin.TiepNhanDonHangMoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Tiếp nhận đơn hàng</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <div id="alert"></div>

        <!-- DataTables -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Danh sách đơn hàng mới
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Ngày đặt</th>
                                <th>Hình thức thanh toán</th>
                                <th>Bằng chứng thanh toán</th>
                                <th>Trạng thái</th>
                                <th>#</th>
                                <th>#</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                               <th>Mã đơn hàng</th>
                                <th>Ngày đặt</th>
                                <th>Hình thức thanh toán</th>
                                <th>Bằng chứng thanh toán</th>
                                <th>Trạng thái</th>
                                <th>#</th>
                                <th>#</th>
                            </tr>
                        </tfoot>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

      
        <!-- The Modal Hủy Đơn Hàng -->
        <div class="modal fade" id="modalHuyDH">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Hủy đơn hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        Bạn có muốn thực hiện thao tác này?
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitHuy" data-dismiss="modal">OK</button>
                    </div>
                </div>
            </div>
        </div>

          <!-- The Modal Xác nhận Đơn Hàng -->
        <div class="modal fade" id="modalXacNhanDH">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xác nhận đơn hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        Bạn có muốn thực hiện thao tác này?
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitXacNhan" data-dismiss="modal">OK</button>
                    </div>
                </div>
            </div>
        </div>
      
    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/static/js/popper.min.js"></script>

    <script type="text/javascript">
        var table;

        function loadTable() {

            // Load dataTable qua Api don hang  
            
            table = $('#dataTable').DataTable({
                processing: true,
                paging: false,
                searching: false,
                ajax: {
                    url: '/Api/DonHang.ashx?DataType=1',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Don_Hang' },
                    { data: 'Ngay_Dat' },
                    { data: 'Hinh_Thuc_Thanh_Toan_String' },
                    { data: 'Bang_Chung_Thanh_Toan' },
                    { data: 'Trinh_Trang_String' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXacNhan" class="btn btn-secondary" data-toggle="modal" data-target="#modalXacNhanDH">Xác nhận</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnHuy" class="btn btn-dark" data-toggle="modal" data-target="#modalHuyDH">Hủy</button>`
                    }]
            });
            
        
            
            // Gan su kien click btn Huy cho tung row
            $('#dataTable tbody').on('click', '#btnHuy', function () {
                let data = table.row($(this).parents('')).data();
              
                // hiển thị mã đơn hàng ở modal hủy
                $('#modalHuyDH').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Hủy đơn hàng ' + data.Ma_Don_Hang)
                })

                // gán sự kiện vào btn Hủy trong modal 
                $('#btnSubmitHuy').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "GET",
                        url: "/Api/DonHang.ashx?DataType=2&MaDonHang=" + data.Ma_Don_Hang,
                        success: function (result) {

                            if (result.Status_Code) {
                                $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                            }
                            else {
                                $('#alert').empty().append(`<div class='alert alert-success'> <strong> Success!</strong > ` + result.Status_Text + ` </div >`)
                            }

                            $('#alert').show();

                            // ẩn alert sau 7s
                            $("#alert").delay(7000).slideUp(200, function () {
                                $(this).alert('dispose');
                            });

                            // load lai dataTable
                            table.ajax.reload();
                        },
                        error: function (result) {
                            console.log(result)
                            $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > Có lỗi trong quá trình kết nối </div >`)
                        }
                    });
                });

            });

             // Gan su kien click btn Xác nhận cho tung row
            $('#dataTable tbody').on('click', '#btnXacNhan', function () {
                let data = table.row($(this).parents('')).data();
              
                // hiển thị mã đơn hàng ở modal hủy
                $('#modalXacNhanDH').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Xác nhận đơn hàng ' + data.Ma_Don_Hang)
                })

                // gán sự kiện vào btn Hủy trong modal 
                $('#btnSubmitXacNhan').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "GET",
                        url: "/Api/DonHang.ashx?DataType=3&MaDonHang=" + data.Ma_Don_Hang,
                        success: function (result) {

                            if (result.Status_Code) {
                                $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                            }
                            else {
                                $('#alert').empty().append(`<div class='alert alert-success'> <strong> Success!</strong > ` + result.Status_Text + ` </div >`)
                            }

                            $('#alert').show();

                            // ẩn alert sau 7s
                            $("#alert").delay(7000).slideUp(200, function () {
                                $(this).alert('dispose');
                            });

                            // load lai dataTable
                            table.ajax.reload();
                        },
                        error: function (result) {
                            console.log(result)
                            $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > Có lỗi trong quá trình kết nối </div >`)
                        }
                    });
                });

            });
        }

       
        
        $(document).ready(function () {
            loadTable()
         });
    </script>

</asp:Content>
