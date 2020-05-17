document.addEventListener("keyup", function (event) {
    // If "caps lock" is pressed, display the warning text
    if (event.getModifierState("CapsLock")) {
        $('.CapsLock').removeClass('text-hide');
    } else {
        $('.CapsLock').addClass('text-hide');
    }
});

function ShowPassword(value) {
    var element = $("#" + value);
    if (element.attr('type') == "password") {
        element.removeAttr('type');
        element.attr('type', 'text');
        $("#" + value + "_icon").removeClass("fa-eye-slash");
        $("#" + value + "_icon").addClass("fa-eye");
    } else {
        element.removeAttr('type');
        element.attr('type', 'password');
        $("#" + value + "_icon").removeClass("fa-eye");
        $("#" + value + "_icon").addClass("fa-eye-slash");
    }
}