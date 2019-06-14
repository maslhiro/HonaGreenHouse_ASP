<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ChiTietDonHang.aspx.cs" Inherits="SellingFruitsWeb.Admin.ChiTietDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Chi tiết đơn hàng</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#" runat="server" id="title">Chi tiết đơn hàng</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Chi tiết giao hàng
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="txtHoTen">Họ tên : </label>
                    <input type="text" class="form-control" id="txtHoTen" readonly runat="server">
                </div>
                <div class="form-group">
                    <label for="txtSoDienThoai">Số điện thoại : </label>
                    <input type="text" class="form-control" id="txtSoDienThoai" readonly runat="server">
                </div>
                <div class="form-group">
                    <label for="txtDiaChiNhan">Địa chỉ nhận : </label>
                    <input type="text" class="form-control" id="txtDiaChiNhan" readonly runat="server">
                </div>
                <div class="form-group">
                    <label for="txtHoTen">Ghi Chú : </label>
                    <textarea class="form-control" rows="5" id="txtGhiChu" readonly runat="server"></textarea>
                </div>
                <div class="form-group">
                    <label>Bằng chứng thanh toán :</label>
                </div>
                <img id="image" src="data:image/gif;base64,R0lGODlhAQABAAD/ACwAAAAAAQABAAACADs%3D" runat="server" />

            </div>

        </div>

        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Chi tiết giao hàng
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <thead>
                            <tr>
                                <th>Mã chi tiết DH</th>
                                <th>Tên trái cây</th>
                                <th>Xuất xứ</th>
                                <th>SL</th>
                                <th>ĐG</th>
                                <th>Tổng tiền</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã chi tiết DH</th>
                                <th>Tên trái cây</th>
                                <th>Xuất xứ</th>
                                <th>SL</th>
                                <th>ĐG</th>
                                <th>Tổng tiền</th>
                            </tr>
                        </tfoot>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/static/js/popper.min.js"></script>

    <script type="text/javascript">
        let table;

        function loadTable() {

            // Load dataTable qua Api don hang  
            let url = new URL(window.location.href);
            let maDonHang = url.searchParams.get("MaDonHang");
            table = $('#dataTable').DataTable({
                processing: true,
                paging: true,
                searching: true,
                ajax: {
                    url: '/Api/DonHang.ashx?DataType=6&MaDonHang='+maDonHang,
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Chi_Tiet_DH' },
                    { data: 'Ten_Trai_Cay' },
                    { data: 'Xuat_Xu' },
                    { data: 'So_Luong_Xuat' },
                    { data: 'Don_Gia_Xuat' },
                    { data: 'Tong_Tien_Xuat' }]
            });



            // Gan su kien click btn Chi tiet cho tung row
            $('#dataTable tbody').on('click', '#btnChiTiet', function () {
                let data = table.row($(this).parents('tr')).data();

                // Load data vao modal Sua
                $('#modalChiTietDH').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-body #txtNgayDat01').val(data.Ngay_Dat)
                    modal.find('.modal-body #txtTinhTrang01').val(data.Trinh_Trang_String)
                    modal.find('.modal-body #txtBangChungThanhToan01').val(data.Bang_Chung_Thanh_Toan)

                    modal.find('.modal-title').text('Sửa đơn hàng ' + data.Ma_Don_Hang)
                })

                let hTTT = data.Hinh_Thuc_Thanh_Toan_String.toString().trim();
                $("#selHTTT01 option[value='" + hTTT + "']").attr("selected", "selected");

                //selTinhTrang01
                let tinhTrang = data.Trinh_Trang_String.toString().trim();
                $("#selTinhTrang01 option[value='" + tinhTrang + "']").attr("selected", "selected");

                // Gan su kien submit cho modal Chi Tiet
                $("#btnSubmitChiTiet").click(function (e) {
                    e.preventDefault();

                    let chiTietDH = null;
                    chiTietDH = {
                        "Ma_Don_Hang": data.Ma_Don_Hang.trim(),
                        "Ngay_Dat": $("#txtNgayDat01").val() ? $("#txtNgayDat01").val() : "",
                        "Hinh_Thuc_Thanh_Toan_String": $("#selHTTT01").val(),
                        "Bang_Chung_Thanh_Toan": $("#txtBangChungThanhToan01").val(),
                        "Trinh_Trang_String": $("#selTinhTrang01").val(),
                    }
                    console.log("JSON", chiTietDH)
                    $.ajax({
                        type: "POST",
                        url: "/Api/DonHang.ashx?DataType=5",
                        data: JSON.stringify(chiTietDH),
                        dataType: 'json',
                        contentType: 'application/json',
                        success: function (result) {
                            // Lôi 
                            if (result.Status_Code) {
                                $('#alertChiTietDH').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                                $('#alertChiTietDH').show();
                                // ẩn alert sau 7s
                                $("#alertChiTietDH").delay(7000).slideUp(200, function () {
                                    $(this).alert('dispose');
                                });
                            }
                            else {
                                // dong modal va xoa cac truong du lieu da nhap
                                $("#modalChiTietDH").modal('hide')

                                $("#txtNgayDat01").val("")
                                $("#selHTTT01").val("0")
                                $("#selTinhTrang01").val("0")
                                $("#txtBangChungThanhToan01").val("")

                                $('#alert').empty().append(`<div class='alert alert-success'> <strong> Success!</strong > ` + result.Status_Text + ` </div >`)

                                $('#alert').show();
                                // ẩn alert sau 7s
                                $("#alert").delay(7000).slideUp(200, function () {
                                    $(this).alert('dispose');
                                });

                                // load lai dataTable
                                table.ajax.reload();
                            }


                        },
                        error: function (result) {
                            console.log(result)
                            $('#alertThem').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > Có lỗi trong quá trình kết nối </div >`)
                        }
                    });
                })

            });
        }



        $(document).ready(function () {
            loadTable()
        });
    </script>
</asp:Content>
