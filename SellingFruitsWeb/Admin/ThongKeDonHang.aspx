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
            <div>Từ</div>
            <input id="dpkFrom" width="180" />
            <div>&#160</div>
            <div>Đến</div>
            <input id="dpkTo" width="180" />
            <div>&#160</div>
            <button type="button" id="btnThongKeTheoNgay" class="btn btn-danger">Lọc</button>
            <div>&#160</div>
            <button type="button" id="btnRefresh" class="btn btn-danger">Tải lại</button>
            
        </div>

        <div id="alert"></div>

        <!-- DataTables -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                <label id="tableHeader">Bảng thống kê </label>
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
            <div>
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
                                    <input class="form-control" id="txtMaKhachHang" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Hình thức thanh toán:</label>
                                    <input class="form-control" id="txtHinhThuc" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Địa chỉ giao hàng:</label>
                                    <input class="form-control" id="txtDiaChiGiao" readonly>
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Họ tên người nhận:</label>
                                    <input class="form-control" id="txtHoTen" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số điện thoại:</label>
                                    <input class="form-control" id="txtSDT" readonly>
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
                modal.find('.modal-body #txtHinhThuc').val(data.Hinh_Thuc_Thanh_Toan)
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

            let thongkeUrl = "/Api/ThongKeDonHang.ashx?DataType=2&From_Date=" + thoiGianThongKe.From_Date + "&To_Date=" + thoiGianThongKe.To_Date;
            debugger;
            var StatusCode;
            console.log("JSON", thoiGianThongKe)
            $.ajax({
                type: "GET",
                url: thongkeUrl,
                success: function (result) {
                    if (result.Status_Code == 0) {
                        $('#alert').empty().append(`<div class='alert alert-success'>` + result.Status_Text + ` </div >`)

                        $('#alert').show();
                        // ẩn alert sau 7s
                        $("#alert").delay(7000).slideUp(200, function () {
                            $(this).alert('dispose');
                        });
                        table.ajax.url(thongkeUrl).load();
                    }
                    else if (result.Status_Code == -2) {
                        $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi!</strong > ` + result.Status_Text + ` </div >`);
                    }
                    else if (result.Status_Code == -3)
                    {
                        $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi</strong > ` + result.Status_Text + ` </div >`);
                    }
                    else if (result.Status_Code == -1 || result.Status_Code == 1)
                    {
                        $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi!</strong > ` + result.Status_Text + ` </div >`);
                    }
                },
                error: function (result) {
                    $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi!</strong > Có lỗi trong quá trình kết nối </div >`)
                    console.log(result)
                }
            });
        }

        function btnRefresh_OnClick(e) {
            e.preventDefault();
            table.ajax.url( '/Api/ThongKeDonHang.ashx?DataType=1' ).load();
        }      
        
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
