/************   Slide Bar   ********************/
$('#sidebarCollapse').on('click', function () {
    if ($("#sidebarIcon").hasClass("fa-bars")) {
        OpenSlidebar();
    } else {
        CloseSlidebar();
    }
});

function OpenSlidebar() {
    $("#sidebarIcon").removeClass("fa-bars");
    $("#sidebarIcon").addClass("fa-align-left");
    $("#sidebarCollapse").removeClass("btn-outline-primary");
    $("#sidebarCollapse").addClass("btn-primary ");
    $("#sidebarIcon").css("color", "white");
    $("#sidebar-wrapper").removeClass("d-none");
}

function CloseSlidebar() {
    $("#sidebarIcon").removeClass("fa-align-left");
    $("#sidebarIcon").addClass("fa-bars");
    $("#sidebarCollapse").removeClass("btn-primary ");
    $("#sidebarCollapse").addClass("btn-outline-primary");
    $("#sidebarIcon").css("color", "");
    $("#sidebar-wrapper").addClass("d-none");
}

function NavBarItemSelected(item) {
    $("#" + item).addClass("bg-info");
    $("#" + item).removeClass("bg-light");
    $("#" + item).addClass("text-light");
    CloseSlidebar();
}

/*************************************************/

function ChangeLanguage(code) {
    var selected = $('#selectedFlag');
    selected.attr('src', '/Files/Language/' + code + '.gif');
}

/********************* Account ***************** */
$('#signInModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
});

$('#signOutModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
});

function SignOut() {
    $.ajax({
        beforeSend: function () {
            $('.wait').attr('style', 'display:block');
        },
        complete: function () {
            $('.wait').attr('style', 'display:none');
            $("#AssignModal").modal('hide');
        },
        type: 'Post',
        url: "/Register/SignOut",
        async: false,
        error: function (jqXHR, textStatus, errorThrown) {
            $("#message").html(
                "<div class='alert alert-block'>" +
                "<button type='button' class='close' data-dismiss='alert'>&times;</button>" +
                "<h4>@Resource.Error</h4>" +
                "<p>@Resource.ErrorConServ</p></div>");
        },
        success: function (response) {
            window.location.href = response.Url;
        }
    });
}

function SignIn() {
    var data = {
        username: $('#Username').val(),
        password: $('#Password').val()
    };
    $.ajax({
        beforeSend: function () {
            $('.wait').attr('style', 'display:block');
        },
        complete: function () {
            $('.wait').attr('style', 'display:none');
            $("#AssignModal").modal('hide');
        },
        type: 'Post',
        url: "/Register/Login",
        data: postData(data),
        async: false,
        error: function (jqXHR, textStatus, errorThrown) {
            $("#message").html(
                "<div class='alert alert-block'>" +
                "<button type='button' class='close' data-dismiss='alert'>&times;</button>" +
                "<h4>@Resource.Error</h4>" +
                "<p>@Resource.ErrorConServ</p></div>");
        },
        success: function (response) {
            window.location.href = response.Url;
        }
    });
}