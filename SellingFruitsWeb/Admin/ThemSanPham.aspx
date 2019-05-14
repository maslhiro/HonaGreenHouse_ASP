<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="ThemSanPham.aspx.cs" Inherits="SellingFruitsWeb.Admin.ThemSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Thêm sản Phẩm</a>
            </li>
            <li class="breadcrumb-item active">Overview</li>
        </ol>

        <!-- Button Them Trai Cay-->
        <div class="d-flex m-4 flex-row-reverse">
            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">Thêm trái cây</button>
        </div>

        <!-- DataTables Example -->
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

        <!-- The Modal -->
        <div class="modal fade" id="myModal">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Thêm Trái Cây</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="d-flex">
                            <div class="p-1 flex-fill">
                                <div class="form-group">
                                    <label for="usr">Tên trái cây:</label>
                                    <input type="text" class="form-control" id="usr" name="username">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Xuất xứ:</label>
                                    <input type="password" class="form-control" name="password">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Số lượng nhập:</label>
                                    <input type="password" class="form-control" name="password">
                                </div>

                            </div>
                            <div class="p-1 flex-fill">

                                <div class="form-group">
                                    <label for="pwd">Đơn giá:</label>
                                    <input type="password" class="form-control" name="password">
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Đơn vị tính:</label>
                                    <input type="password" class="form-control" name="password">
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Loại trái cây:</label>
                                    <select class="form-control" id="sel1" name="sellistLoaiTC" runat="server"  ClientIDMode="Static" >
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                    </select>
                                </div>

                            </div>
                        </div>
                        <div class="form-group">
                            <label for="comment">Mô tả:</label>
                            <textarea class="form-control" rows="5" id="comment"></textarea>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary">Submit</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>

    <script type="text/javascript">
        $(document).ready(
            function () {
                var table = $('#dataTable').DataTable({
                    processing: true,
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
                        { data: 'Don_Gia', type: 'num-fmt' },
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

            })


    </script>
</asp:Content>
