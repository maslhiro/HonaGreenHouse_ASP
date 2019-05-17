<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThemSanPham.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThemSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="/static/js/popper.min.js"></script>

    <script type="text/javascript" >
        var table;

        function loadTable() {
            table = $('#dataTable').DataTable({
                processing: true,
                paging: false,
                searching: false,
                ajax: {
                    url: '/Api/GetListTraiCay.ashx',
                    dataSrc: ''
                },
                columns: [
                    { data: 'Ma_Trai_Cay' },
                    { data: 'Ten_Trai_Cay' },
                    { data: 'Loai_ID' },
                    { data: 'Xuat_Xu' },
                    { data: 'So_Luong' },
                    { data: 'Don_Vi_Tinh' },
                    { data: 'Don_Gia' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnSua" class="btn btn-secondary">Sửa</button>`
                    },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnXoa" class="btn btn-dark">Xoá</button>`
                    }]
            });

            $('#dataTable tbody').on('click', '#btnSua', function () {
                var data = table.row($(this).parents('tr')).data();
                alert(data.Ten_Trai_Cay);
            });

            $('#dataTable tbody').on('click', '#btnXoa', function () {
                var data = table.row($(this).parents('tr')).data();
                alert(data.Ma_Trai_Cay);
            });
        }

        $(document).ready(function () {
            loadTable()
        });    </script>
    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thêm sản Phẩm</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button Them Trai Cay-->
        <div class="d-flex m-3 flex-row-reverse">
            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalThemTC">Thêm trái cây</button>
            <asp:Button runat="server" ID="btnReload" OnClick="btnReload_Click" CssClass="btn btn-dark" Text="Reload Table"/>
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
                        <button type="button" class="close"  id="btnClose" runat="server" onserverclick="btnClose_Click">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div id="alertError" runat="server"></div>
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên trái cây: (*)</label>
                                    <input type="text" class="form-control" id="txtTenTraiCay" runat="server" ClientIdMode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Xuất xứ:</label>
                                    <input type="text" class="form-control" id="txtXuatXu" runat="server" ClientIdMode="Static">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số lượng nhập: (*)</label>
                                    <input type="text" class="form-control" id="txtSoLuongNhap" runat="server" ClientIdMode="Static">
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Đơn giá: (*)</label>
                                    <input type="text" class="form-control" id="txtDonGia" runat="server" ClientIdMode="Static" >
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Đơn vị tính: (*)</label>
                                    <input type="text" class="form-control" id="txtDonViTinh" runat="server" ClientIdMode="Static" >
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Loại trái cây:</label>
                                    <select class="form-control" id="selLoaiTraiCay" runat="server" ClientIdMode="Static" tabindex="0">
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


    </div>
</asp:Content>
