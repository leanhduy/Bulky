$(document).ready(function () {
    loadTable();
});

function loadTable() {
    dataTable = $('#productTable').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { "data": 'isbn', "width": "5%" },
            { "data": 'title', "width": "20%" },
            { "data": 'author', "width": "10%" },
            { "data": 'listPrice', "width": "5%" },
            { "data": 'description', "width": "25%" },
            { "data": 'category.name', "width": "5%" },
            // Edit button
            {
                "data": 'id',
                "render": function (data) {
                    return `
                    <div class=w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2">
                    <i class="bi bi-pencil-square"></i>Edit</a>
                    <a href="/admin/product/delete?id=${data}" asp-controller="Product" asp-action="Delete" class="btn btn-danger mx-2">
                    <i class="bi bi-trash"></i>Delete</a>
                    </div>
                    `;
                },
                "width": "30%"
            }
        ]
    });
}