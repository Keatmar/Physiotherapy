$('.datepicker').datepicker({
    dateFormat: 'dd/mm/yy',
    changeYear: true,
    changeMonth: true,
    regional: "el",
    yearRange: '1950:2100',
    minDate: new Date(1950, 0, 1),
    maxDate: '0',
    dayNames: [, "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi"],
    dayNamesMin: ["Di", "Lu", "Ma", "Me", "Je", "Ve", "Sa"],
    firstDay: 1,
    monthNames: ["Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", "August", "September", "Oktober", "November", "December"],
    monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dec"],
});