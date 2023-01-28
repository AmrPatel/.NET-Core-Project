﻿var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")) {
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').dataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "with": "5%" },
            { "data": "name", "with": "25%" },
            { "data": "phoneNumber", "with": "15%" },
            { "data": "applicationUser.email", "with": "15%" },
            { "data": "orderStatus", "with": "15%" },
            { "data": "orderTotal", "with": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="w-50 btn-group" role="group">
                            <a href="/Admin/Order/Details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                        </div>`
                },
                "with": "5%"
            },
        ]
    });
}