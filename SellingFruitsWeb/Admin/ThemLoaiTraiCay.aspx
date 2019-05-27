<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThemLoaiTraiCay.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThemLoaiTraiCay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thêm loại trái cây</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button Them Loại Trai Cay-->
        <div class="d-flex m-3 flex-row-reverse">
            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalThemLTC">Thêm loại trái cây</button>
        </div>

        <div id="alert"></div>

        <!-- DataTables -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Danh sách loại trái cây
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable">
                        <thead>
                            <tr>
                                <th>Mã</th>
                                <th>Tên loại trái cây</th>
                                <th>#</th>
                                <th>#</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã</th>
                                <th>Tên loại trái cây</th>
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
        <div class="modal fade" id="modalThemLTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Thêm Loại Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertThem"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên loại trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenLoaiTraiCay">
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
        <!-- The Modal Xoa Loai Trai Cay -->
        <div class="modal fade" id="modalXoaLTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Xoá Loại Trái Cây</h4>
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
        <!-- The Modal Sua Loại Trai Cay -->
        <div class="modal fade" id="modalSuaLTC">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Sửa Loại Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertSua"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên loại trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenLoaiTraiCay01">
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
    <script src="/static/js/popper.min.js"></script>

    <script type="text/javascript">
        var table;

        function loadTable() {

            // Load dataTable qua Api loai trai cay  
            table = $('#dataTable').DataTable({
                processing: true,
                paging: false,
                searching: false,
                ajax: {
                    url: '/Api/LoaiTraiCay.ashx?DataType=8',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Loai_Trai_Cay' },
                    { data: 'Ten_Loai_Trai_Cay' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnSua" class="btn btn-secondary" data-toggle="modal" data-target="#modalSuaLTC">Sửa</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXoa" class="btn btn-dark" data-toggle="modal" data-target="#modalXoaLTC">Xoá</button>`
                    }]
            });

            // Gan su kien click btn Sua cho tung row
            $('#dataTable tbody').on('click', '#btnSua', function () {
                let data = table.row($(this).parents('tr')).data();

                // Load data vao modal Sua
                $('#modalSuaTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-body #txtTenLoaiTraiCay01').val(data.Ten_Loai_Trai_Cay)

                    modal.find('.modal-title').text('Sửa loại trái cây mã ' + data.Ma_Loai_Trai_Cay)
                })

                // Gan su kien submit cho modal Sua
                $("#btnSubmitSua").click(function (e) {
                    e.preventDefault();

                    let loaiTraiCay = {
                        "Ma_Loai_Trai_Cay": data.Ma_Loai_Trai_Cay,
                        "Ten_Loai_Trai_Cay": $("#txtTenLoaiTraiCay01").val() ? $("#txtTenLoaiTraiCay01").val() : "",
                    }
                    console.log("JSON", loaiTraiCay)
                    $.ajax({
                        type: "POST",
                        url: "/Api/LoaiTraiCay.ashx?DataType=9",
                        data: JSON.stringify(loaiTraiCay),
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
                                $("#modalSuaLTC").modal('hide')

                                $("#txtTenLoaiTraiCay01").val("")

                                $('#alert').empty().append(`<div class='alert alert-success'> <strong> Thành công!</strong > ` + result.Status_Text + ` </div >`)

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
                $('#modalXoaLTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Xoá loại trái cây mã ' + data.Ma_Loai_Trai_Cay)
                })

                // gán sự kiện vào btn Xoa trong modal 
                $('#btnSubmitXoa').click(function (e) {
                    e.preventDefault();
                    $.ajax({
                        type: "GET",
                        url: "/Api/LoaiTraiCay.ashx?DataType=10&MaLoaiTraiCay=" + data.Ma_Loai_Trai_Cay,
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

        function btnSubmitThem_OnClick(e) {
            e.preventDefault();

            let loaiTraiCay = {
                "Ten_Loai_Trai_Cay": $("#txtTenLoaiTraiCay").val() ? $("#txtTenLoaiTraiCay").val() : "",
            }
            console.log("JSON", loaiTraiCay)
            $.ajax({
                type: "POST",
                url: "/Api/LoaiTraiCay.ashx?DataType=11",
                data: JSON.stringify(loaiTraiCay),
                dataType: 'json',
                contentType: 'application/json',
                success: function (result) {
                    // Lỗi 
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
                        $("#modalThemLTC").modal('hide')

                        $("#txtTenLoaiTraiCay").val("")

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
