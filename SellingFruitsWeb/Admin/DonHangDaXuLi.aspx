<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="DonHangDaXuLi.aspx.cs" Inherits="SellingFruitsWeb.Admin.DonHangDaXuLi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="#">Danh sách đơn hàng mới</a>
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
                                <th>Tổng tiền</th>
                                <th>Tình trạng</th>
                                <th>#</th>

                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Ngày đặt</th>
                                <th>Tổng tiền</th>
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
                paging: true,
                searching: true,
                ajax: {
                    url: '/Api/DonHang.ashx?DataType=4',
                    dataSrc: 'Data'
                },
                columns: [
                    { data: 'Ma_Don_Hang' },
                    { data: 'Ngay_Dat' },
                    { data: 'Tong_Tien' },
                    { data: 'Tinh_Trang_Text' },
                    {
                        "data": null,
                        "defaultContent": `<button type="button" id="btnChiTiet" class="btn btn-secondary">Chi tiết ĐH</button>`
                    }]
            });

            $('#dataTable tbody').on('click', '#btnChiTiet', function () {
                let data = table.row($(this).parents('tr')).data();
                window.open('/Admin/ChiTietDonHang.aspx?MaDonHang=' + data.Ma_Don_Hang, '_blank');
            });

        }
    
        $(document).ready(function () {
            loadTable()
        });
    </script>

</asp:Content>
