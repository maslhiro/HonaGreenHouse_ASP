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

        <div runat="server" id="alertSuccest"></div>


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
                                <th>Tên trái cây</th>
                                <th>Mã loại trái cây</th>
                                <th>Loại trái cây</th>
                                <th>Xuất xứ</th>
                                <th>Số lượng tồn</th>
                                <th>Đơn vị tính</th>
                                <th>Đơn giá</th>
                                <th>#</th>
                                <th>#</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã</th>
                                <th>Tên trái cây</th>
                                <th>Mã loại trái cây</th>
                                <th>Loại trái cây</th>
                                <th>Xuất xứ</th>
                                <th>Số lượng tồn</th>
                                <th>Đơn vị tính</th>
                                <th>Đơn giá</th>
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
                        <button type="button" class="close" id="btnClose" runat="server" onserverclick="btnClose_Click">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertError" runat="server"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenTraiCay" runat="server" clientidmode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Xuất xứ:</label>
                                    <input type="text" class="form-control" id="txtXuatXu" runat="server" clientidmode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số lượng nhập: (*)</label>
                                    <input type="text" class="form-control" id="txtSoLuongNhap" runat="server" clientidmode="Static">
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Đơn giá: (*)</label>
                                    <input type="text" class="form-control" id="txtDonGia" runat="server" clientidmode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Đơn vị tính: (*)</label>
                                    <input type="text" class="form-control" id="txtDonViTinh" runat="server" clientidmode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Loại trái cây:</label>
                                    <select class="form-control" id="selLoaiTraiCay" runat="server" clientidmode="Static" tabindex="0">
                                        <option>LTC01 - Trái cây miền bắc</option>
                                        <option>LTC02 - Trái cây miền trung</option>
                                        <option>LTC03 - Trái cây miền nam</option>
                                        <option>LTC04 - Trái cây nhập khẩu</option>
                                    </select>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="comment">Mô tả:</label>
                            <textarea class="form-control" rows="5" id="txtMoTa" runat="server"></textarea>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn btn-dark" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" />
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
                        <button class="btn btn-dark" id="btnSubmitXoa" onclick="btnSubmit_Click">Submit</button>
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
                        <div id="alertError01"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenTraiCay01">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Xuất xứ:</label>
                                    <input type="text" class="form-control" id="txtXuatXu01">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số lượng nhập: (*)</label>
                                    <input type="text" class="form-control" id="txtSoLuongNhap01">
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Đơn giá: (*)</label>
                                    <input type="text" class="form-control" id="txtDonGia01">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Đơn vị tính: (*)</label>
                                    <input type="text" class="form-control" id="txtDonViTinh01">
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Loại trái cây:</label>
                                    <select class="form-control" id="selLoaiTraiCay01">
                                        <option value="LTC01">LTC01 - Trái cây miền bắc</option>
                                        <option value="LTC02">LTC02 - Trái cây miền trung</option>
                                        <option value="LTC03">LTC03 - Trái cây miền nam</option>
                                        <option value="LTC04">LTC04 - Trái cây nhập khẩu</option>
                                    </select>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="comment">Mô tả:</label>
                            <textarea class="form-control" rows="5" id="txtMoTa01"></textarea>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button class="btn btn-dark" id="btnSubmit01" onclick="btnSubmit_Click">Submit</button>
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
            table = $('#dataTable').DataTable({
                processing: true,
                paging: false,
                searching: false,
                ajax: {
                    url: '/Api/TraiCay.ashx?DataType=1',
                    dataSrc: ''
                },
                columns: [
                    { data: 'Ma_Trai_Cay' },
                    { data: 'Ten_Trai_Cay' },
                    { data: 'Loai_ID' },
                    { data: 'Ten_Loai_TC' },
                    { data: 'Xuat_Xu' },
                    { data: 'So_Luong' },
                    { data: 'Don_Vi_Tinh' },
                    { data: 'Don_Gia' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnSua" class="btn btn-secondary" data-toggle="modal" data-target="#modalSuaTC">Sửa</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXoa" class="btn btn-dark" data-toggle="modal" data-target="#modalXoaTC">Xoá</button>`
                    }]
            });

            $('#dataTable tbody').on('click', '#btnSua', function () {
                let data = table.row($(this).parents('tr')).data();
                $('#modalSuaTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-body #txtTenTraiCay01').val(data.Ten_Trai_Cay)
                    modal.find('.modal-body #txtXuatXu01').val(data.Xuat_Xu)
                    modal.find('.modal-body #txtSoLuongNhap01').val(data.So_Luong)
                    modal.find('.modal-body #txtMoTa01').val(data.Mo_Ta)
                    modal.find('.modal-body #txtDonGia01').val(data.Don_Gia)
                    modal.find('.modal-body #txtDonViTinh01').val(data.Don_Vi_Tinh)

                    modal.find('.modal-title').text('Sửa trái cây mã ' + data.Ma_Trai_Cay)
                })


                let loaiTC = data.Loai_ID.toString().trim();
                $("#selLoaiTraiCay01 option[value='" + loaiTC + "']").attr("selected", "selected");
            });

            $('#dataTable tbody').on('click', '#btnXoa', function () {
                let data = table.row($(this).parents('tr')).data();
                $('#modalXoaTC').on('show.bs.modal', function (event) {
                    var modal = $(this)
                    modal.find('.modal-title').text('Xoá trái cây mã ' + data.Ma_Trai_Cay)
                })
            });
        }

        $(document).ready(function () {
            loadTable()
        });
    </script>
</asp:Content>
