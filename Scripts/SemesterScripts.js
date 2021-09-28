$(function () {
    $.ajaxSetup({ cache: false });
    ChangeParameter();
    $("#group").change(ChangeParameter);
    $("#semester").change(ChangeParameter);
    $("#modDialog").on("show.bs.modal", function () {
        $("#GroupId option[value=" + $('#group').val() + "]").prop('selected', true);
        $("#SemesterId option[value=" + $('#semester').val() + "]").prop('selected', true);
    });
});

function ShowTable(data) {
    $('#table').html(data);
}
function ShowNumberOfWeeks(data) {
    $("#numberOfWeeks").html(data);
}
function ChangeParameter() {
    var groupId = $('#group').val();
    var semesterId = $('#semester').val();
    var data = {groupId, semesterId}
    $.ajax({
        type: "POST",
        url: $("#pathSpan").attr("Data-url"),
        data: data,
        success: function (data) {
            ShowTable(data);
            InitTable();
        }
    });
    $.ajax({
        type: "POST",
        url: $("#WeekPathSpan").attr("Data-url"),
        data: data,
        success: function (data) {
            ShowNumberOfWeeks(data);
        }
    });
}