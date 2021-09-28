$(function () {
    /*$.ajaxSetup({ cache: false });*/
    $("#createBtn").click(function (e) {
        e.preventDefault();
        let url = $(this).attr('data-handler') + "/" + $('#semester').val()
        $.get($(this).attr('data-handler')+"/" + $('#semester').val(), function (data) {
            alert("Начало генерации")
            document.location.replace(url);
        });
    });
});