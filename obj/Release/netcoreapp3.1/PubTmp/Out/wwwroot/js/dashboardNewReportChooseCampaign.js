var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Reports/GetCampaignsForReports/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "campaignName", "width": "50%" },
            {
                "data": "campaignId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-success text-white' style='cursor:pointer; width:120px;'
                            onclick=StartReport('/Dashboard/ReportCreate?id='+${data})>
                            Start a Report
                        </a>
                        &nbsp;
                        </div>`;
                }, "width": "50%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
