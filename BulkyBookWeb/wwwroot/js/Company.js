var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "with": "15%" },
            { "data": "streetAddress", "with": "15%" },
            { "data": "city", "with": "15%" },
            { "data": "state", "with": "15%" },
            { "data": "phoneNumber", "with": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="w-50 btn-group" role="group">
                            <a href="/Admin/Company/Upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>&nbsp; Edit</a>
                            <a  OnClick=Delete('/Admin/Company/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash3-fill"></i>&nbsp; Delete</a>
                        </div>`
                },
                "with": "15%"
            },
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}