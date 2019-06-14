<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DonHangMoi.aspx.cs" Inherits="SellingFruitsWeb.Admin.DonHangMoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Đơn hàng mới</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Danh sách đơn hàng mới</a>
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
                                <th>Tổng tiền</th>
                                <th>Tình trạng</th>
                                <th>#</th>
                                <th>#</th>
                                <th>#</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Ngày đặt</th>
                                <th>Tổng tiền</th>
                                <th>Tình trạng</th>
                                <th>#</th>

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

        <!-- The Modal Huy Don Hang -->
        <div class="modal fade" id="modalHuyDH">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Hủy Đơn Hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        Bạn có chăc chắn muốn hủy đơn hàng này ?
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitHuy" data-dismiss="modal">Submit</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- The Modal Xac nhan Don Hang -->
        <div class="modal fade" id="modalXacNhanDH">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xác Nhận Đơn Hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Upload ảnh :</label>
                            <input id="imageUpload" type="file" />
                        </div>
                        <div class="m-2">
                            <img id="image" height="225px" width="225px" src="data:image/gif;base64,R0lGODlhAQABAAD/ACwAAAAAAQABAAACADs%3D" />
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmit" data-dismiss="modal">Submit</button>
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
        var table, imageBase64;

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
                    { data: 'Tinh_Trang_Text' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnChiTiet" class="btn btn-secondary">Chi tiết ĐH</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXacNhan" class="btn btn-primary" data-toggle="modal" data-target="#modalXacNhanDH">Xác nhận</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnHuy" class="btn btn-secondary" data-toggle="modal" data-target="#modalHuyDH">Hủy</button>`
                    }]
            });

            $('#dataTable tbody').on('click', '#btnChiTiet', function () {
                let data = table.row($(this).parents('tr')).data();
                window.open('/Admin/ChiTietDonHang.aspx?MaDonHang=' + data.Ma_Don_Hang, '_blank');
            });

            // Gan su kien click btn Huy cho tung row
            $('#dataTable tbody').on('click', '#btnHuy', function () {
                let data = table.row($(this).parents('tr')).data();

                $('#modalHuyDH').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Hủy đơn hàng mã ' + data.Ma_Don_Hang)
                })

                $('#btnSubmitHuy').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "GET",
                        url: "/Api/DonHang.ashx?DataType=2&MaDonHang=" + data.Ma_Don_Hang,
                        success: function (result) {
                            console.log(result)
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

            // Gan su kien click btn Xac nhan cho tung row
            $('#dataTable tbody').on('click', '#btnXacNhan', function () {
                let data = table.row($(this).parents('tr')).data();

                // hiển thị mã trái cây ở modal xoá
                $('#modalXacNhanDH').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Cập nhật bằng chứng thanh toán đơn hàng mã ' + data.Ma_Don_Hang)
                })

                // gán sự kiện vào btn Xoa trong modal 
                $('#btnSubmit').click(function (e) {
                    e.preventDefault();

                    let donHang = {
                        Bang_Chung_Thanh_Toan: imageBase64,
                        Ma_Don_Hang: data.Ma_Don_Hang
                    }

                    $.ajax({
                        type: "POST",
                        url: "/Api/DonHang.ashx?DataType=3",
                        data: JSON.stringify(donHang),
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

        function readFile() {
            if (this.files && this.files[0]) {

                var FR = new FileReader();

                FR.addEventListener("load", function (e) {
                    $("#image").attr("src", e.target.result);
                    imageBase64 = e.target.result;
                    console.log(e.target.result);
                });

                FR.readAsDataURL(this.files[0]);
            }
        }

        $("#imageUpload").change(readFile);

        $(document).ready(function () {
            loadTable()
        });
    </script>

</asp:Content>
