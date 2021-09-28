$(function () {
    $.ajaxSetup({ cache: false });
    $("#addBtn").click(function (e) {
        e.preventDefault();
        $.get($(this).attr('data-handler'), function (data) {
            ModalShow(data);
        });
    });
    $("#editBtn").click(function (e) {
        e.preventDefault();
        $.get($(this).attr('data-handler') + "/" + $(".active").attr("id"), function (data) {
            ModalShow(data);
        });
    });
    $("#dropBtn").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("data-handler");
        var dataId = $(".active").attr("id");
        $.ajax({
            type: "POST",
            url: url + "/" + dataId,
            data: dataId,
            success: function (data) {
                if (Boolean(data)) {
                    $("#" + dataId).remove();
                }
            }
        })
    });
    $("#addBtnSem").click(function (e) {
        e.preventDefault();
        $.get($(this).attr('data-handler'), function (data) {
            ModalShow(data);
        });
    });
    $("#editBtnSem").click(function (e) {
        e.preventDefault();
        $.get($(this).attr('data-handler') + "/" + $('#semester').val(), function (data) {
            ModalShow(data);
        });
    });
    $("#dropBtnSem").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("data-handler");
        var dataId = $('#semester').val();
        $.ajax({
            type: "POST",
            url: url + "/" + dataId,
            data: dataId,
            success: function (data) {
                if (Boolean(data)) {
                    $("[value = " + dataId + "]").remove();
                }
            }
        });
    });
    //$("#createBtn").click(function (e) {
    //    e.preventDefault();
    //    var url = $(this).attr("data-handler");
    //    var semesterId = $("#semester").val();
    //    var data = { semesterId };
    //    $.ajax({
    //        type: "POST",
    //        url: url,
    //        data: data,
    //        success: function () {
    //            alert("schedule created");
    //        }
    //    });
    //});
    $("#NumOfWeeksBtn").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("data-handler");
        var groupId = $('#group').val();
        var semesterId = $('#semester').val();
        var data = { groupId, semesterId }
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (data) {
                ModalShow(data);
            }
        });
    });
    InitTable();

});

function ModalShow(data) {
    $('#dialogContent').html(data);
    $('#modDialog').modal('show');
    $(".send").click(function () {
        $('#modDialog').modal('hide');
        ChangeParameter();
    });
}
function InitTable() {
    $("tr").each(function (index, element) {
        $(element).dblclick(function (e) {
            $.get($("#editBtn").attr('data-handler') + "/" + $(this).attr("id"), function (data) {
                ModalShow(data);
            });
        });
        $(element).click(function (e) {
            $(".active").removeClass("active");
            $(this).addClass("active");
        })
    });
}

