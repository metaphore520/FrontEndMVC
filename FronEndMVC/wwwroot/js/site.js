// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $("#StudentName").keyup(function () {
        $("#StudentName").val($("#StudentName").val().toUpperCase());
        $("#StudentNameLabel").text('Please Insert In Capital Letter');
    });
    $("#StudentNameEdit").keyup(function () {
        $("#StudentNameEdit").val($("#StudentNameEdit").val().toUpperCase());
        $("#StudentNameEditLabel").val('Please Insert In Capital Letter');
    });
    $("#CourseName").keyup(function () {
        $("#CourseName").val($("#CourseName").val().toUpperCase());
        $("#CourseNameLabel").val('Please Insert In Capital Letter');
    });
    $("#CourseNameEdit").keyup(function () {
        $("#CourseNameEdit").val($("#CourseNameEdit").val().toUpperCase());
        $("#StudentNameEditLabel").val('Please Insert In Capital Letter');
    });



});


