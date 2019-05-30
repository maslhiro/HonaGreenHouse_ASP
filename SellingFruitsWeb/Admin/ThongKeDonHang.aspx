<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThongKeDonHang.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThongKeDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thống kê đơn hàng</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button thống kê filter-->
        <div class="d-flex m-3 flex-row">
            <input id="dpkFrom" width="180" />
            <div>&#160</div>
            <input id="dpkTo" width="180" />
            <div>&#160</div>
            <button type="button" id="btnThongKeTheoNgay" class="btn btn-danger" data-toggle="modal" data-target="#modalThemTC">Lọc</button>
            <div>&#160</div>
            <button type="button" id="btnRefresh" class="btn btn-danger">Tải lại</button>
            
        </div>

        <div id="alert"></div>
        <div id="selected-filter"></div>

        <!-- DataTables -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                <label id="tableHeader">Thống kê </label>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th></th>
                                <th>Thời gian</th>
                                <th>Tổng tiền</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th></th>
                                <th>Thời gian</th>
                                <th>Tổng tiền</th>
                                

                            </tr>
                        </tfoot>
                        <tbody>
                        </tbody>
                    </table>
                </div>
            </div>
            <div align="right">
                <b>Tổng tiền: </b>
                <b id="txtTongTien"></b>
            </div>
        </div>

        <!-- The Modal Xem chi tiet don hang -->
        <div class="modal fade" id="modalXemChiTiet">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xem chi tiết đơn hàng</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertXemChiTiet"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Mã khách hàng:</label>
                                    <input type="text" class="form-control" id="txtMaKhachHang">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Hình thức thanh toán:</label>
                                    <input type="text" class="form-control" id="txtHinhThuc">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Wait to add data:</label>
                                    <input type="number" class="form-control" id="txtSoLuongNhap01" min="0" step="1" value="0">
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Họ tên người nhận:</label>
                                    <input type="text" class="form-control" id="txtHoten">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số điện thoại:</label>
                                    <input type="text" class="form-control" id="txtSDT">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Địa chỉ giao hàng:</label>
                                    <input type="text" class="form-control" id="txtDiaChiGiao">
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnCloseXemChiTiet">Đóng</button>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/static/js/popper.min.js"></script>
    <script src="/static/js/popper.min.js"></script>
    <script src="/static/gijgo-datepicker/js/gijgo.js" type="text/javascript"></script>

    <script type="text/javascript">
        var table;

        function loadTable() {
            table = $('#dataTable').DataTable({
                processing: true,
                paging: false,
                searching: false,
                ajax: {
                    url: '/Api/ThongKeDonHang.ashx?DataType=1',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Don_Hang' },
                    {
                        "data": null,
                        "defaultContent": `<div align="center"><button type="button" id="btnXemChiTiet" class="btn btn-secondary" data-toggle="modal" data-target="#modalXemChiTiet">Xem chi tiết</button></div>`
                    },
                    { data: 'Thoi_Gian' },
                    { data: 'Tong_Tien' },
                    ]
            });
        }

        //Button XemChiTiet
        $('#dataTable tbody').on('click', '#btnXemChiTiet', function () {
            let data = table.row($(this).parents('tr')).data();

            $('#modalXemChiTiet').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-body #txtMaKhachHang').val(data.Ma_Khach_Hang)
                modal.find('.modal-body #txtHinhThuc').val(data.Hinh_Thuc)
                modal.find('.modal-body #txtHoTen').val(data.Ho_Ten)
                modal.find('.modal-body #txtSDT').val(data.So_Dien_Thoai)
                modal.find('.modal-body #txtDiaChiGiao').val(data.Dia_Chi_Nhan)

                modal.find('.modal-title').text('Chi tiết đơn hàng mã ' + data.Ma_Don_Hang)
            })

            // Gan su kien cho btn Dong xem chi tiet
            $("#btnCloseXemChiTiet").click(function (e) {
                e.preventDefault();

                $("#modalXemChiTiet").modal('hide')

                $("#txtMaKhachHang").val("")
                $("#txtHinhThuc").val("")
                $("#txtHoTen").val("")
                $("#txtSDT").val("")
                $("#txtDiaChiGiao").val("")
            })
        });

        function btnThongKeTheoNgay_OnClick(e) {
            e.preventDefault();

            let thoiGianThongKe = {
                "From_Date": $("#dpkFrom").val() ? $("#dpkFrom").val() : "",
                "To_Date": $("#dpkTo").val() ? $("#dpkTo").val() : "",
            }
            console.log("JSON", thoiGianThongKe)
            $.ajax({
                type: "POST",
                url: "/Api/ThongKeDonHang.ashx?DataType=2",
                data: JSON.stringify(thoiGianThongKe),
                dataType: 'json',
                contentType: 'application/json',
                success: function (result) {
                    // Lôi 
                    if (result.Status_Code) {
                        $('#alertSua').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                        $('#alertSua').show();
                        // ẩn alert sau 7s
                        $("#alertSua").delay(7000).slideUp(200, function () {
                            $(this).alert('dispose');
                        });
                    }
                    else {
                        table.ajax.url('/Api/ThongKeDonHang.ashx?DataType=2').load();
                    }
                },
                error: function (result) {
                    console.log(result)
                    $('#alertThem').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > Có lỗi trong quá trình kết nối </div >`)
                }
            });
        }

        function btnRefresh_OnClick(e) {
            e.preventDefault();
            table.ajax.url( '/Api/ThongKeDonHang.ashx?DataType=1' ).load();
        }

        //function tinhTongTien() {
        //    $('#dataTable').DataTable{

        //    }
        //}

        //function appendLeadingZeroes(n){
        //    if(n <= 9){
        //        return "0" + n;
        //    }
        //    return n
        //}

        //let current_datetime = Date.now;
        //let formatted_date = current_datetime.getFullYear() + "-" + appendLeadingZeroes(current_datetime.getMonth() + 1) + "-" + appendLeadingZeroes(current_datetime.getDate()) + " " + appendLeadingZeroes(current_datetime.getHours()) + ":" + appendLeadingZeroes(current_datetime.getMinutes()) + ":" + appendLeadingZeroes(current_datetime.getSeconds());
        
        $(document).ready(function () {
            loadTable()

            $("#btnThongKeTheoNgay").click(function (e) {
                btnThongKeTheoNgay_OnClick(e)
            })

            $("#btnRefresh").click(function (e) {
                btnRefresh_OnClick(e)
            })

            $('#dpkFrom').datepicker({
                uiLibrary: 'bootstrap4',
                format: 'dd/mm/yyyy'
            })
            
            $('#dpkTo').datepicker({
                uiLibrary: 'bootstrap4',
                format: 'dd/mm/yyyy',
            })
        });
    </script>

</asp:Content>
