$("tr").each(function (index, element) {
    element.dblclick(function (e) {
        $.get($(this).attr('data-handle')+"/"+$(this).id, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
});