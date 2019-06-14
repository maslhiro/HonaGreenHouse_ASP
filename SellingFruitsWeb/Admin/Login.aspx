<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SellingFruitsWeb.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <!-- Custom fonts for this template-->
    <link href="/static/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template-->
    <link href="/static/css/sb-admin.css" rel="stylesheet" />

        <!-- Bootstrap core JavaScript-->
    <script src="/static/vendor/jquery/jquery.min.js"></script>
    <script src="/static/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="/static/vendor/jquery-easing/jquery.easing.min.js"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <div class="container">
            <div class="card card-login mx-auto mt-5">
                <div class="card-header">Login</div>
                <div class="card-body">
                    <div class="form-group">
                        <div id="alert"></div>
                        <div class="form-label-group">
                            <input type="text" name="username" id="txtUsername" class="form-control" placeholder="Username" autofocus="autofocus" runat="server"/>
                            <label for="username">Username</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <input type="password" name="password" id="txtPassword" class="form-control" placeholder="Password"  runat="server"/>
                            <label for="password">Password</label>
                        </div>
                    </div>
                    <%-- <div class="form-group">
            <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me"/>
                Remember Password
              </label>
            </div>
          </div>--%>
                    <button type="button" class="btn btn-primary btn-block" id="login" runat="server" onserverclick="login_ServerClick">Login</button>
                </div>
            </div>
        </div>
    </form>


<%--    <script>
        function onClick_Login(e) {
            e.preventDefault();

            let username = $("#username").val();
            let password = $("#password").val();
            console.log("JSON ADMIN", username + " / " + password)
            $.ajax({
                type: "GET",
                url: "/Api/Admin.ashx?DataType=1&Username=" + username + "&Password=" + password,
                success: function (result) {

                    if (result.Status_Code) {
                        $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > ` + result.Status_Text + ` </div >`)
                    }
                    else {
                        location.replace("http://localhost:55013/Admin/ThemTraiCay.aspx")
                        return;
                    }

                    $('#alert').show();

                    // ẩn alert sau 7s
                    $("#alert").delay(7000).slideUp(200, function () {
                        $(this).alert('dispose');
                    });

                },
                error: function (result) {
                    console.log(result)
                    $('#alert').empty().append(`<div class='alert alert-danger'> <strong> Warning!</strong > Có lỗi trong quá trình kết nối </div >`)
                }
            });


        }


        $(document).ready(function () {
            $("#login").click(function (e) {
                onClick_Login(e)
            })
        })

    </script>--%>
</body>
</html>
