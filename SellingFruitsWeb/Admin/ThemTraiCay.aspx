<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThemTraiCay.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThemSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thêm trái cây</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button Them Trai Cay-->
        <div class="d-flex m-3 flex-row-reverse">
            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalThemTC">Thêm trái cây</button>
        </div>

        <div id="alert"></div>

        <!-- DataTables -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Danh sách trái cây
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <thead>
                            <tr>
                                <th>Mã</th>
                                <th>Tên TC</th>
                                <th>Loại TC</th>
                                <th>Xuất xứ</th>
                                <th>SL tồn</th>
                                <th>ĐVT</th>
                                <th>ĐGiá nhập</th>
                                <th>ĐGiá xuất</th>
                                <th>#</th>
                                <th>#</th>
                                <th>#</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã</th>
                                <th>Tên TC</th>
                                <th>Loại TC</th>
                                <th>Xuất xứ</th>
                                <th>SL tồn</th>
                                <th>ĐVT</th>
                                <th>ĐGiá nhập</th>
                                <th>ĐGiá xuất</th>
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

        <!-- The Modal Them Trai Cay -->
        <div class="modal fade" id="modalThemTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Thêm Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertThem"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="txtTenTraiCay">Tên trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenTraiCay">
                                </div>
                                <div class="form-group">
                                    <label for="txtXuatXu">Xuất xứ:</label>
                                    <input type="text" class="form-control" id="txtXuatXu">
                                </div>
                                <div class="form-group">
                                    <label for="txtSoLuongNhap">Số lượng nhập: (*)</label>
                                    <input type="number" class="form-control" id="txtSoLuongNhap" min="0" step="1" value="0">
                                </div>
                                 <div class="form-group">
                                    <label for="selLoaiTraiCay">Loại trái cây:</label>
                                    <select class="form-control" id="selLoaiTraiCay" tabindex="0">
                                        <option value="LTC01">LTC01 - Trái cây miền bắc</option>
                                        <option value="LTC02">LTC02 - Trái cây miền trung</option>
                                        <option value="LTC03">LTC03 - Trái cây miền nam</option>
                                        <option value="LTC04">LTC04 - Trái cây nhập khẩu</option>
                                    </select>
                                </div>
                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="txtDonGiaNhap">Đơn giá nhập: (*)</label>
                                    <input type="number" class="form-control" id="txtDonGiaNhap" min="0" step="1" value="0">
                                </div>
                                <div class="form-group">
                                    <label for="txtDonGiaXuat">Đơn giá xuất: (*)</label>
                                    <input type="number" class="form-control" id="txtDonGiaXuat" min="0" step="1" value="0">
                                </div>
                                <div class="form-group">
                                    <label for="txtDonViTinh">Đơn vị tính: (*)</label>
                                    <input type="text" class="form-control" id="txtDonViTinh">
                                </div>
                               

                            </div>
                        </div>                        
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitThem">Submit</button>
                    </div>

                </div>
            </div>
        </div>
        <!-- The Modal Xoa Trai Cay -->
        <div class="modal fade" id="modalXoaTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xoá Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <!-- Modal body -->
                    <div class="modal-body">
                        Bạn có chăc chắn muốn xoá ?
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitXoa" data-dismiss="modal">Submit</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- The Modal Sua Trai Cay -->
        <div class="modal fade" id="modalSuaTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Sửa Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertSua"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="txtTenTraiCay01">Tên trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenTraiCay01">
                                </div>
                                <div class="form-group">
                                    <label for="txtXuatXu01">Xuất xứ:</label>
                                    <input type="text" class="form-control" id="txtXuatXu01">
                                </div>
                                <div class="form-group">
                                    <label for="txtSoLuongNhap01">Số lượng nhập: (*)</label>
                                    <input type="number" class="form-control" id="txtSoLuongNhap01" min="0" step="1" value="0">
                                </div>
                                <div class="form-group">
                                    <label for="selLoaiTraiCay01">Loại trái cây:</label>
                                    <select class="form-control" id="selLoaiTraiCay01">
                                        <option value="LTC01">LTC01 - Trái cây miền bắc</option>
                                        <option value="LTC02">LTC02 - Trái cây miền trung</option>
                                        <option value="LTC03">LTC03 - Trái cây miền nam</option>
                                        <option value="LTC04">LTC04 - Trái cây nhập khẩu</option>
                                    </select>
                                </div>
                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="txtDonGiaNhap01">Đơn giá nhập: (*)</label>
                                    <input type="number" class="form-control" id="txtDonGiaNhap01" min="0" step="1" value="0">
                                </div>

                                <div class="form-group">
                                    <label for="txtDonGiaXuat01">Đơn giá xuất: (*)</label>
                                    <input type="number" class="form-control" id="txtDonGiaXuat01" min="0" step="1" value="0">
                                </div>

                                <div class="form-group">
                                    <label for="txtDonViTinh01">Đơn vị tính: (*)</label>
                                    <input type="text" class="form-control" id="txtDonViTinh01">
                                </div>
                            

                            </div>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmitSua">Submit</button>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    
    <script type="text/javascript">
        var table;

        function loadTable() {

            // Load dataTable qua Api trai cay  
            table = $('#dataTable').DataTable({
                processing: true,
                paging: true,
                searching: true,
                ajax: {
                    url: '/Api/TraiCay.ashx?DataType=1',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Trai_Cay' },
                    { data: 'Ten_Trai_Cay' },
                    //{ data: 'Loai_ID' },
                    { data: 'Ten_Loai_TC' },
                    { data: 'Xuat_Xu' },
                    { data: 'So_Luong' },
                    { data: 'Don_Vi_Tinh' },
                    { data: 'Don_Gia_Nhap' },
                    { data: 'Don_Gia_Xuat' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnChiTietTC" class="btn btn-primary">Chi tiết</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnSua" class="btn btn-secondary" data-toggle="modal" data-target="#modalSuaTC">Sửa</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXoa" class="btn btn-dark" data-toggle="modal" data-target="#modalXoaTC">Xoá</button>`
                    }]
            });

            // Gan su kien click btn Sua cho tung row
            $('#dataTable tbody').on('click', '#btnSua', function () {
                let data = table.row($(this).parents('tr')).data();

                // Load data vao modal Sua
                $('#modalSuaTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-body #txtTenTraiCay01').val(data.Ten_Trai_Cay)
                    modal.find('.modal-body #txtXuatXu01').val(data.Xuat_Xu)
                    modal.find('.modal-body #txtSoLuongNhap01').val(data.So_Luong)
                    modal.find('.modal-body #txtDonGiaXuat01').val(data.Don_Gia_Xuat)
                    modal.find('.modal-body #txtDonGiaNhap01').val(data.Don_Gia_Nhap)
                    modal.find('.modal-body #txtDonViTinh01').val(data.Don_Vi_Tinh)

                    modal.find('.modal-title').text('Sửa trái cây mã ' + data.Ma_Trai_Cay)
                })

                let loaiTC = data.Loai_ID.toString().trim();
                $("#selLoaiTraiCay01 option[value='" + loaiTC + "']").attr("selected", "selected");

                // Gan su kien submit cho modal Sua
                $("#btnSubmitSua").click(function (e) {
                    e.preventDefault();

                    let traiCay = {
                        "Ma_Trai_Cay": data.Ma_Trai_Cay,
                        "Ten_Trai_Cay": $("#txtTenTraiCay01").val() ? $("#txtTenTraiCay01").val() : "",
                        "Don_Vi_Tinh": $("#txtDonViTinh01").val() ? $("#txtDonViTinh01").val() : "",
                        "Don_Gia_Xuat": $("#txtDonGiaXuat01").val(),
                        "Don_Gia_Nhap": $("#txtDonGiaNhap01").val(),
                        "So_Luong": $("#txtSoLuongNhap01").val(),
                        "Xuat_Xu": $("#txtXuatXu01").val() ? $("#txtXuatXu01").val() : "",
                        "Loai_ID": $("#selLoaiTraiCay01").val()
                    }
                    console.log("JSON", traiCay)
                    $.ajax({
                        type: "POST",
                        url: "/Api/TraiCay.ashx?DataType=4",
                        data: JSON.stringify(traiCay),
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
                                // dong modal va xoa cac truong du lieu da nhap
                                $("#modalSuaTC").modal('hide')

                                $("#txtTenTraiCay01").val("")
                                $("#txtDonViTinh01").val("")
                                $("#txtDonGiaNhap01").val("")
                                $("#txtDonGiaXuat01").val("")
                                $("#txtSoLuongNhap01").val("")
                                $("#txtXuatXu01").val("")
                                $("#selLoaiTraiCay01").val("LTC01")

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

            // Gan su kien click btn Xoa cho tung row
            $('#dataTable tbody').on('click', '#btnXoa', function () {
                let data = table.row($(this).parents('tr')).data();

                // hiển thị mã trái cây ở modal xoá
                $('#modalXoaTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Xoá trái cây mã ' + data.Ma_Trai_Cay)
                })

                // gán sự kiện vào btn Xoa trong modal 
                $('#btnSubmitXoa').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "GET",
                        url: "/Api/TraiCay.ashx?DataType=2&MaTraiCay=" + data.Ma_Trai_Cay,
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

            $('#dataTable tbody').on('click', '#btnChiTietTC', function () {
                let data = table.row($(this).parents('tr')).data();
                window.open('/Admin/ChiTietTraiCay.aspx?MaTraiCay=' + data.Ma_Trai_Cay,'_blank');
            });
        }

        function btnSubmitThem_OnClick(e) {
            e.preventDefault();

            let traiCay = {
                "Ten_Trai_Cay": $("#txtTenTraiCay").val() ? $("#txtTenTraiCay").val() : "",
                "Don_Vi_Tinh": $("#txtDonViTinh").val() ? $("#txtDonViTinh").val() : "",
                "Don_Gia_Nhap": $("#txtDonGiaNhap").val(),
                "Don_Gia_Xuat": $("#txtDonGiaXuat").val(),
                "So_Luong": $("#txtSoLuongNhap").val(),
                "Xuat_Xu": $("#txtXuatXu").val() ? $("#txtXuatXu").val() : "",
                "Loai_ID": $("#selLoaiTraiCay").val()
            }
            console.log("JSON", traiCay)
            $.ajax({
                type: "POST",
                url: "/Api/TraiCay.ashx?DataType=3",
                data: JSON.stringify(traiCay),
                dataType: 'json',
                contentType: 'application/json',
                success: function (result) {
                    // Lôi 
                    if (result.Status_Code) {
                        $('#alertThem').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                        $('#alertThem').show();
                        // ẩn alert sau 7s
                        $("#alertThem").delay(7000).slideUp(200, function () {
                            $(this).alert('dispose');
                        });
                    }
                    else {
                        // dong modal va xoa cac truong du lieu da nhap
                        $("#modalThemTC").modal('hide')

                        $("#txtTenTraiCay").val("")
                        $("#txtDonViTinh").val("")
                        $("#txtDonGiaNhap").val("")
                        $("#txtDonGiaXuat").val("")
                        $("#txtSoLuongNhap").val("")
                        $("#txtXuatXu").val("")
                        $("#selLoaiTraiCay").val("LTC01")

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
        }
        
        $(document).ready(function () {
            loadTable()

            $("#btnSubmitThem").click(function (e) {
                btnSubmitThem_OnClick(e)
            })
        });
    </script>

</asp:Content>
