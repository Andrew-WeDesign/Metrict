//$("#StatusWorkInProgress").click(function () {
//    loadDataTable();
//});

function StatusWorkInProgress(id) {
    var url = "/EmployeeTasks/TaskStatusToWorkInProgress?id="
    $.post(url.concat(id))
};

function StatusReview(id) {
    var url = "/EmployeeTasks/TaskStatusToReview?id="
    $.post(url.concat(id))
};

function StatusCompleted(id) {
    var url = "/EmployeeTasks/TaskStatusToCompleted?id="
    $.post(url.concat(id))
};