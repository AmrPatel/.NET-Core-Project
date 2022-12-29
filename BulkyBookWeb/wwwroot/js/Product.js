var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/admin/product/getall"
        },
        "columns": [
            { "data": "title", "with": "15%" },
            { "data": "isbn", "with": "15%" },
            { "data": "price", "with": "15%" },
            { "data": "author", "with": "15%" },
            { "data": "category.name", "with": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="w-50 btn-group" role="group">
                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary"><i class="bi bi-pencil-square"></i>&nbsp; Edit</a>
                            <a  OnClick=Delete('/Admin/Product/Delete/${data}') class="btn btn-danger"><i class="bi bi-trash3-fill"></i>&nbsp; Delete</a>
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