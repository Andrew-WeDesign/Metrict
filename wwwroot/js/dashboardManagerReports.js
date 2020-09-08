var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Managers/GetAllEmployeeReports/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "campaignName", "width": "24%" },
            { "data": "applicationUserName", "width": "24%" },
            { "data": "submissionDate", "width": "24%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-success text-white' style='cursor:pointer; width:90px;'
                            onclick=Details('/Dashboard/ReportDetails?id='+${data})>
                            Details
                        </a>
                        &nbsp;
                        </div>`;
                }, "width": "28%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

