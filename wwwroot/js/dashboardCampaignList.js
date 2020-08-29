var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/Campaigns/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "startDate", "width": "20%" },
            { "data": "campaignActive", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a class='btn btn-success text-white' style='cursor:pointer; width:120px;'
                            onclick=Dashboard('/Dashboard/CampaignDashboard?id='+${data})>
                            Dashboard
                        </a>
                        &nbsp;
                        <a class='btn btn-success text-white' style='cursor:pointer; width:100px;'
                            onclick=Edit('/Dashboard/CampaignUpsert?id='+${data})>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:100px;'
                            onclick=Delete('/Campaigns/Delete?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%"
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

function Dashboard(url) {
    $("#main").load(url);
};

function Edit(url) {
    $("#main").load(url);
};
