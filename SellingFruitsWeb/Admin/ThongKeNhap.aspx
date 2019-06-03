<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThongKeNhap.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThongKeNhap" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/static/gijgo-datepicker/css/gijgo.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thống kê nhập xuất</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button thống kê filter-->
        <div class="d-flex m-3 flex-row">
            <input id="dpkFrom" width="180" />
            <div>&#160</div>
            <div class="d-flex justify-content-center align-items-center m-2">
                <i class="fas fa-arrow-alt-circle-right fa-lg"></i>
            </div>
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
                                <th>Mã</th>
                                <th>Tên trái cây</th>
                                <th>Thời gian</th>
                                <th>Xuất xứ</th>
                                <th>#</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã</th>
                                <th>Tên trái cây</th>
                                <th>Thời gian</th>
                                <th>Xuất xứ</th>
                                <th>#</th>
                            </tr>
                        </tfoot>
                        <tbody>
                        </tbody>
                    </table>
                </div>
                <div class="d-flex row m-4 justify-content-end">
                    <div  id="txtTotal">Tổng cộng : </div>
                </div>
            </div>

        </div>

        <!-- The Modal Xem chi tiet trai cay -->
        <div class="modal fade" id="modalXemChiTiet">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xem chi tiết trái cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertXemChiTiet"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="txtTenTraiCay">Tên trái cây:</label>
                                    <input class="form-control" id="txtTenTraiCay" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="txtDonViTinh">Đơn vị tính:</label>
                                    <input class="form-control" id="txtDonViTinh" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="txtXuatXu">Xuất xứ:</label>
                                    <input class="form-control" id="txtXuatXu" readonly>
                                </div>
                            </div>
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="txtDonGiaNhap">Đơn giá nhập:</label>
                                    <input class="form-control" id="txtDonGiaNhap" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="txtSoLuong">Số lượng nhập:</label>
                                    <input class="form-control" id="txtSoLuong" readonly>
                                </div>
                                <div class="form-group">
                                    <label for="txtTongTien">Tổng tiền:</label>
                                    <input class="form-control" id="txtTongTien" readonly>
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
    <script src="/static/gijgo-datepicker/js/gijgo.js" type="text/javascript"></script>

    <script type="text/javascript">
        var table;

        function loadTable() {
            table = $('#dataTable').DataTable({
                processing: true,
                paging: true,
                searching: true,
                ajax: {
                    url: '/Api/ThongKeNhapXuat.ashx?DataType=1',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Trai_Cay' },
                    { data: 'Ten_Trai_Cay' },
                    { data: 'Thoi_Gian' },
                    { data: 'Xuat_Xu' },
                    {
                        "data": null,
                        "defaultContent": `<div align="center"><button type="button" id="btnXemChiTiet" class="btn btn-secondary" data-toggle="modal" data-target="#modalXemChiTiet">Xem chi tiết</button></div>`
                    },
                ]
            });
        }

        //Button XemChiTiet
        $('#dataTable tbody').on('click', '#btnXemChiTiet', function () {
            let data = table.row($(this).parents('tr')).data();

            $('#modalXemChiTiet').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-body #txtTenTraiCay').val(data.Ten_Trai_Cay)
                modal.find('.modal-body #txtDonViTinh').val(data.Don_Vi_Tinh)
                modal.find('.modal-body #txtDonGiaNhap').val(data.Don_Gia_Nhap)
                modal.find('.modal-body #txtXuatXu').val(data.Xuat_Xu)
                modal.find('.modal-body #txtSoLuong').val(data.So_Luong_Nhap)
                modal.find('.modal-body #txtTongTien').val(data.Tong_Tien_Nhap)

                modal.find('.modal-title').text('Chi tiết trái cây mã ' + data.Ma_Trai_Cay)
            })

            // Gan su kien cho btn Dong xem chi tiet
            $("#btnCloseXemChiTiet").click(function (e) {
                e.preventDefault();

                $("#modalXemChiTiet").modal('hide')

                $("#txtTenTraiCay").val("")
                $("#txtDonViTinh").val("")
                $("#txtDonGiaNhap").val("")
                $("#txtXuatXu").val("")
                $("#txtSoLuongNhap").val("")
                $("#txtTongTien").val("")

            })
        });

        function btnThongKeTheoNgay_OnClick(e) {
            e.preventDefault();

            let thoiGianThongKe = {
                "From_Date": $("#dpkFrom").val() ? $("#dpkFrom").val() : "",
                "To_Date": $("#dpkTo").val() ? $("#dpkTo").val() : "",
            }

            let thongkeUrl = "/Api/ThongKeNhapXuat.ashx?DataType=2&From_Date=" + thoiGianThongKe.From_Date + "&To_Date=" + thoiGianThongKe.To_Date;

            console.log("JSON", thoiGianThongKe)
            $.ajax({
                type: "GET",
                url: thongkeUrl,
                success: function (result) {
                    if (result.Status_Code == 0) {
                        //$('#alert').empty().append(`<div class='alert alert-success'>  <strong> Success! </strong >` + result.Status_Text + ` </div >`)

                        //$('#alert').show();
                        //// ẩn alert sau 7s
                        //$("#alert").delay(7000).slideUp(200, function () {
                        //    $(this).alert('dispose');
                        //});
                        $('#txtTotal').empty().append("Tổng cộng : "+result.Status_Text+" đ");

                        table.ajax.url(thongkeUrl).load();
                    }
                    else {
                        $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi! </strong > ` + result.Status_Text + ` </div >`);
                    }
                },
                error: function (result) {
                    $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Lỗi! </strong > Có lỗi trong quá trình kết nối </div >`)
                    console.log(result)
                }
            });
        }

        function btnRefresh_OnClick(e) {
            e.preventDefault();
            table.ajax.url("/Api/ThongKeNhapXuat.ashx?DataType=1").load();
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
