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
            <button type="button" class="btn btn-danger" runat="server">Thêm trái cây</button>
        </div>

        <!-- DataTables Example -->
        <div class="card mb-3">
            <div class="card-header">
                <i class="fas fa-table"></i>
                Danh sách trái cây
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
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
    </div>

    <!-- Page level plugin JavaScript-->
    <script src="/static/vendor/datatables/jquery.dataTables.js"></script>
    <script src="/static/vendor/datatables/dataTables.bootstrap4.js"></script>
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
                        { data: 'Don_Gia' },
                        { data: null},
                        { data: null }
                    ]
                });

                $('#datâTble tbody').on('click', 'tr', function () {
                    if ($(this).hasClass('selected')) {
                        $(this).removeClass('selected');
                    }
                    else {
                        table.$('tr.selected').removeClass('selected');
                        $(this).addClass('selected');
                    }
                });

            })
    </script>
</asp:Content>
