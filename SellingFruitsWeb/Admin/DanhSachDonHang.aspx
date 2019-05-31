<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DanhSachDonHang.aspx.cs" Inherits="SellingFruitsWeb.Admin.DanhSachDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Danh sách đơn hàng</a>
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
                                <th>Tình trạng</th>
                                <th>#</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                               <th>Mã đơn hàng</th>
                                <th>Ngày đặt</th>
                                <th>Hình thức thanh toán</th>
                                <th>Bằng chứng thanh toán</th>
                                <th>Tình trạng</th>
                                <th>#</th>
                            </tr>
                        </tfoot>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

      
        <!-- The Modal Chi Tiet Don Hang -->
        <div class="modal fade" id="modalChiTietDH">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Chi Tiết Đơn Hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertChiTietDH"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Ngày đặt:</label>
                                    <input type="text" class="form-control" id="txtNgayDat01">
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Hình thức thanh toán:</label>
                                    <select class="form-control" id="selHTTT01">
                                        <option value="0">Thanh toán qua MOMO</option>
                                        <option value="1">Thanh toán COD</option>
                                    </select>
                                </div>

                            </div>
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="sel2">Tình trạng:</label>
                                    <select class="form-control" id="selTinhTrang01">
                                        <option value="0">Chờ xác nhận</option>
                                        <option value="1">Đang xử lý</option>
                                        <option value="2">Hủy</option>
                                        <option value="3">Thành công</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Bằng chứng thanh toán:</label>
                                    <input type="text" class="form-control" id="txtBangChungThanhToan01">
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitChiTiet">Submit</button>
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
                    url: '/Api/DonHang.ashx?DataType=4',
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
                        "defaultContent": `<button type="button" id="btnChiTiet" class="btn btn-secondary" data-toggle="modal" data-target="#modalChiTietDH">Chi tiết</button>`
                    }]
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