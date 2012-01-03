function GenerateSubSeriesAbbr(subseries, txtID) {
    var txt = $("#" + txtID);

    if (subseries != null && subseries != '') {
        if (subseries.substring(10, 11) == '0')
            txt.val(subseries.substring(7, 10));
        else
            txt.val(subseries.substring(7, 11));
    }
    else {
        txt.val('');
    }
}