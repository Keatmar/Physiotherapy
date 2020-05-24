(function ($) {
    $.fn.GradeMask = function (options) {
        var params = $.extend({
            format: 'xx,xx',
            international: false,
        }, options);

        if (params.format === 'xx,xx') {
            $(this).bind('paste', function (e) {
                e.preventDefault();
                var inputValue = e.originalEvent.clipboardData.getData('Text');
                if (!$.isNumeric(inputValue)) {
                    return false;
                } else {
                    inputValue = String(inputValue.replace(/(\d{3})(\d{3})(\d{4})/, "$1-$2-$3"));
                    $(this).val(inputValue);
                    $(this).val('');
                    inputValue = inputValue.substring(0, 12);
                    $(this).val(inputValue);
                }
            });
            $(this).on('keydown touchend', function (e) {
                if (e.which != 8 && e.which != 0 && ((e.which < 48 || e.which > 57) && (e.which < 96 || e.which > 105))) {
                    return false;
                }
                var curchr = this.value.length;
                var curval = $(this).val();
                if (curchr == 1 && e.which != 8 && e.which != 0) {
                    if (curval != "1" || (e.which != 48 && e.which != 96))
                        $(this).val(curval + ".");
                }
                if (curval == "1" && (e.which == 48 || e.which == 96)) {
                    $(this).attr('maxlength', '2');
                } else if (curval != "10"){
                    $(this).attr('maxlength', '4');
                }
            });
        }
    }
}(jQuery));