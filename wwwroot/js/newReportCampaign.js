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
                        <a href="/Reports/Create?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:200px;'>
                            Start Report
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

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}